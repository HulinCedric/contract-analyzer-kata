using System;
using System.Collections.Generic;
using System.Linq;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private readonly IEnumerable<Rule> _rules;

        public ContractAnalyzer() : this(new FraudDetectorAdapter()) { }

        public ContractAnalyzer(IFraudDetector fraudDetector) => _rules = RuleFactory.GetRules(fraudDetector);

        public IEnumerable<Violation> Violations => _rules.Where(rule => rule.HasViolation).Select(rule => rule.Violation);

        public void Analyze(Contract contract)
        {
            foreach (var rule in _rules)
            {
                rule.Check(contract);
            }
        }
    }
}
