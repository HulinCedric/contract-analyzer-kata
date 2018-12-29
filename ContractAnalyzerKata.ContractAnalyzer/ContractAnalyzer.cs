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
            Violations.Add(new UnderAgeViolation());
        }
    }
}
