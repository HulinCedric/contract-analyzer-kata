using System;

namespace ContractAnalyzerKata.ContractAnalyzer
{
    public class User
    {
        public User(string firstName, string lastName, DateTime dateOfBirth) =>
        (FirstName, LastName, DateOfBirth) = (firstName, lastName, dateOfBirth);
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }
    }
}
