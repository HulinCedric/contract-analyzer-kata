using System;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class UnderAgeRule : Rule
    {
        public override void Check(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Today.AddYears(-18))
            {
                _violation = new UnderAgeViolation();
            }
        }
    }
}