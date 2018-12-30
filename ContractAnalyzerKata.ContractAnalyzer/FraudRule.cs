namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class FraudRule
    {
        private Violation _violation;
        public Violation Violation => _violation;
        public bool HasViolation => Violation != null;
        private readonly IFraudDetector _fraudDetector;

        public FraudRule() : this(new FraudDetectorAdapter()) { }
        public FraudRule(IFraudDetector fraudDetector) => _fraudDetector = fraudDetector;

        public void Check(Contract contract)
        {
            if (_fraudDetector.IsFraudDetected(contract))
            {
                _violation = new FraudViolation();
            }
        }
    }
}