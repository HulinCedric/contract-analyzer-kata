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
    }
}
