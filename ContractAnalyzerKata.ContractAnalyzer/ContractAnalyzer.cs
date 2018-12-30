using System;
using System.Collections.Generic;
using System.Linq;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private readonly IList<Violation> _violations;
        private readonly FraudDetector _fraudDetector;

        public ContractAnalyzer() : this(new FraudDetector())
        {
        }

        public ContractAnalyzer(FraudDetector fraudDetector)
        {
            _violations = new List<Violation>();
            _fraudDetector = fraudDetector;
        }

        public IEnumerable<Violation> Violations => _violations;

        public void Analyze(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                _violations.Add(new UnderAgeViolation());
            }

            if (_fraudDetector.IsCustomerFraudDetected(contract.User.FirstName,
                                                      contract.User.LastName,
                                                      contract.User.DateOfBirth))
            {
                _violations.Add(new FraudViolation());
            }
        }
    }
}
