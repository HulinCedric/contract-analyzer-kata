namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class FraudRule : Rule
    {
        private readonly IFraudDetector _fraudDetector;

        public FraudRule() : this(new FraudDetectorAdapter()) { }
        public FraudRule(IFraudDetector fraudDetector) => _fraudDetector = fraudDetector;

        public override void Check(Contract contract)
        {
            if (_fraudDetector.IsFraudDetected(contract))
            {
                _violation = new FraudViolation();
            }
        }
    }
}