using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class RuleFactory
    {
        public static IEnumerable<Rule> GetRules(IFraudDetector fraudDetector)
        {
            return GetEnumerableOfType<Rule>(fraudDetector);
        }

        private static IEnumerable<T> GetEnumerableOfType<T>(IFraudDetector fraudDetector) where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                var constructorWithFraudDetector = type.GetConstructor(new[] { fraudDetector.GetType() });
                if (constructorWithFraudDetector != null)
                {
                    objects.Add((T)constructorWithFraudDetector.Invoke(new[] { fraudDetector }));
                }
                else
                {
                    objects.Add((T)Activator.CreateInstance(type));
                }
            }
            return objects;
        }
    }
}
