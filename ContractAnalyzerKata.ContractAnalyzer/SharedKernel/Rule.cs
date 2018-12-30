namespace ContractAnalyzerKata.ContractAnalyzer
{
    public abstract class Rule
    {
        protected Violation _violation = new NoViolation();
        public Violation Violation => _violation;
        public bool HasViolation => !(Violation is NoViolation);
        public abstract void Check(Contract contract);
    }
}