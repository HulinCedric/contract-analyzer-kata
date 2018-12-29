using System;
using System.Linq;
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

        [Fact]
        public void ContainsAnUnderAgeViolationWhenUserAgeIsUnder18YearsOld()
        {
            var contractAnalyzer = new ContractAnalyzer();
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-17) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.NotEmpty(contractAnalyzer.Violations);
            Assert.NotEmpty(contractAnalyzer.Violations.OfType<UnderAgeViolation>());
            Assert.Single(contractAnalyzer.Violations.OfType<UnderAgeViolation>());
        }

        [Fact]
        public void ContainsEmptyViolationsWhenUserAgeIsOver18YearsOld()
        {
            var contractAnalyzer = new ContractAnalyzer();
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-21) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.Empty(contractAnalyzer.Violations);
        }

        [Fact]
        public void ContainsEmptyViolationsWhenUserAgeIsEqual18YearsOld()
        {
            var contractAnalyzer = new ContractAnalyzer();
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-18) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.Empty(contractAnalyzer.Violations);
        }
    }
}
