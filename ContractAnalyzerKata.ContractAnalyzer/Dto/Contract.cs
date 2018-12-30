namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class Contract
    {
        public Contract(string name, User user) => (Name, User) = (name, user);

        public string Name { get; }
        public User User { get; }
    }
}
