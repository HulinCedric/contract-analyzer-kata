using System;
using System.Collections.Generic;
using System.Linq;
using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private readonly IList<Violation> _violations;

        public ContractAnalyzer()
        {
            _violations = new List<Violation>();
        }

        public IEnumerable<Violation> Violations => _violations;

        public void Analyze(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                _violations.Add(new UnderAgeViolation());
            }

            var fraudDetector = new FraudDetector();
            if (fraudDetector.IsCustomerFraudDetected(contract.User.FirstName,
                                                      contract.User.LastName,
                                                      contract.User.DateOfBirth))
            {
                _violations.Add(new FraudViolation());
            }
        }
    }
}
