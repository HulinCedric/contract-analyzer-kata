using System;
using System.Collections.Generic;
using System.Linq;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private IEnumerable<Rule> _rules;
        private readonly IFraudDetector _fraudDetector;

        public ContractAnalyzer() : this(new FraudDetectorAdapter()) { }

        public ContractAnalyzer(IFraudDetector fraudDetector)
        {
            _fraudDetector = fraudDetector;
            ResetRules();
        }

        public IEnumerable<Violation> Violations => _rules.Where(rule => rule.HasViolation).Select(rule => rule.Violation);

        public void Analyze(Contract contract)
        {
            ResetRules();
            CheckRules(contract);
        }

        private void CheckRules(Contract contract)
        {
            foreach (var rule in _rules)
            {
                rule.Check(contract);
            }
        }

        private void ResetRules()
        {
            _rules = RuleFactory.GetRules(_fraudDetector);
        }
    }
}
