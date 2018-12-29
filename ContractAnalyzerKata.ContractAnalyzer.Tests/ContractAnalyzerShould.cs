using Xunit;

namespace ContractAnalyzerKata.ContractAnalyzer.Tests
{
    public class ContractAnalyzerShould
    {
        [Fact]
        public void BeNotNull()
        {
            var contractAnalyzer = new ContractAnalyzer();

            Assert.NotNull(contractAnalyzer);
        }

        [Fact]
        public void ContainsEmptyViolationsByDefault()
        {
            var contractAnalyzer = new ContractAnalyzer();

            Assert.NotNull(contractAnalyzer.Violations);
            Assert.Empty(contractAnalyzer.Violations);
        }
    }
}
