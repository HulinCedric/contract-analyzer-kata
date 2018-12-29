using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        private readonly IList<UnderAgeViolation> _violations;

        public ContractAnalyzer()
        {
            _violations = new List<UnderAgeViolation>();
        }

        public IEnumerable<UnderAgeViolation> Violations => _violations;

        public void Analyze(Contract contract)
        {
            if (contract.User.DateOfBirth > DateTime.Now.AddYears(-18))
            {
                _violations.Add(new UnderAgeViolation());
            }
        }
    }
}
