using System;
using System.Collections.Generic;
using System.Linq;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private readonly IList<Violation> _violations = new List<Violation>();
        private readonly IEnumerable<Rule> _rules;

        public ContractAnalyzer() : this(new FraudDetectorAdapter()) { }

        public ContractAnalyzer(IFraudDetector fraudDetector) => _rules = new List<Rule> {
            new UnderAgeRule(),
            new FraudRule(fraudDetector)
        };

        public IEnumerable<Violation> Violations => _violations;

        public void Analyze(Contract contract)
        {
            foreach (var rule in _rules)
            {
                rule.Check(contract);
                if (rule.HasViolation)
                {
                    _violations.Add(rule.Violation);
                }
            }
        }
    }
}
