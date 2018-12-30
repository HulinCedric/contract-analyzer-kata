namespace ContractAnalyzerKata.ContractAnalyzer
{
    public abstract class Rule
    {
        protected Violation _violation;
        public Violation Violation => _violation;
        public bool HasViolation => Violation != null;
        public abstract void Check(Contract contract);
    }
}