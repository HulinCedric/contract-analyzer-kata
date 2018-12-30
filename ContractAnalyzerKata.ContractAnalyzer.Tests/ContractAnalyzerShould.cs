using System;
using System.Linq;
using Moq;
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
            var mockFraudDetector = new Mock<IFraudDetector>();
            mockFraudDetector.Setup(f => f.IsFraudDetected(It.IsAny<Contract>())).Returns(false);
            var contractAnalyzer = new ContractAnalyzer(mockFraudDetector.Object);
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
            var mockFraudDetector = new Mock<IFraudDetector>();
            mockFraudDetector.Setup(f => f.IsFraudDetected(It.IsAny<Contract>())).Returns(false);
            var contractAnalyzer = new ContractAnalyzer(mockFraudDetector.Object);
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-21) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.Empty(contractAnalyzer.Violations);
        }

        [Fact]
        public void ContainsEmptyViolationsWhenUserAgeIsEqual18YearsOld()
        {
            var mockFraudDetector = new Mock<IFraudDetector>();
            mockFraudDetector.Setup(f => f.IsFraudDetected(It.IsAny<Contract>())).Returns(false);
            var contractAnalyzer = new ContractAnalyzer(mockFraudDetector.Object);
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-18) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.Empty(contractAnalyzer.Violations);
        }

        [Fact]
        public void ContainsAFraudViolationWhenFraudIsDetected()
        {
            var mockFraudDetector = new Mock<IFraudDetector>();
            mockFraudDetector.Setup(f => f.IsFraudDetected(It.IsAny<Contract>())).Returns(true);
            var contractAnalyzer = new ContractAnalyzer(mockFraudDetector.Object);
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-21) };
            var contract = new Contract { User = user };

            contractAnalyzer.Analyze(contract);

            Assert.NotEmpty(contractAnalyzer.Violations);
            Assert.NotEmpty(contractAnalyzer.Violations.OfType<FraudViolation>());
            Assert.Single(contractAnalyzer.Violations.OfType<FraudViolation>());
        }

        [Fact]
        public void ContainsOnlyViolationsOfTheLastAnalyzedContract()
        {
            var mockFraudDetector = new Mock<IFraudDetector>();
            mockFraudDetector.Setup(f => f.IsFraudDetected(It.IsAny<Contract>())).Returns(true);
            var contractAnalyzer = new ContractAnalyzer(mockFraudDetector.Object);
            var userUnder18 = new User { DateOfBirth = DateTime.Today.AddYears(-17) };
            var contractOne = new Contract { User = userUnder18 };
            var userOver18 = new User { DateOfBirth = DateTime.Today.AddYears(-21) };
            var contractTwo = new Contract { User = userOver18 };

            contractAnalyzer.Analyze(contractOne);
            contractAnalyzer.Analyze(contractTwo);

            Assert.NotEmpty(contractAnalyzer.Violations);
            Assert.NotEmpty(contractAnalyzer.Violations.OfType<FraudViolation>());
            Assert.Single(contractAnalyzer.Violations.OfType<FraudViolation>());
            Assert.Empty(contractAnalyzer.Violations.OfType<UnderAgeViolation>());
        }
    }
}
