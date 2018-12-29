using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        public ContractAnalyzer()
        {
            Violations = new List<UnderAgeViolation>();
        }

        public IList<UnderAgeViolation> Violations { get; }

        public void Analyze(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                Violations.Add(new UnderAgeViolation());
            }
        }
    }
}
