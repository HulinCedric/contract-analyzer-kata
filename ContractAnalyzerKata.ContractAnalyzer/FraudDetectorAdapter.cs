using ExternalLibrary.FraudDetector;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class FraudDetectorAdapter : IFraudDetector
    {
        private readonly FraudDetector _fraudDetector = new FraudDetector();

        public bool IsFraudDetected(Contract contract) =>
        _fraudDetector.IsCustomerFraudDetected(contract.User.FirstName,
                                               contract.User.LastName,
                                               contract.User.DateOfBirth);
    }
}