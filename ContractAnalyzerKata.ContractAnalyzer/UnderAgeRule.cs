using System;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class UnderAgeRule
    {
        private Violation _violation;
        public Violation Violation => _violation;
        public bool HasViolation => Violation != null;
        public void Check(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                _violation = new UnderAgeViolation();
            }
        }
    }
}