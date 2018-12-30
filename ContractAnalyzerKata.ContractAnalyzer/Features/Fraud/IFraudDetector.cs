namespace ContractAnalyzerKata.ContractAnalyzer
{
    public interface IFraudDetector
    {
        bool IsFraudDetected(Contract contract);
    }
}