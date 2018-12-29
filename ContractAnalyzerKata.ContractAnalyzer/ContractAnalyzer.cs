using System.Collections.Generic;
using System.Linq;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class ContractAnalyzer
    {
        public ContractAnalyzer()
        {
            Violations = Enumerable.Empty<object>();
        }

        public IEnumerable<object> Violations { get; }
    }
}
