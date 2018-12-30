using System;
using System.Collections.Generic;
using System.Linq;

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
        }
    }
}
