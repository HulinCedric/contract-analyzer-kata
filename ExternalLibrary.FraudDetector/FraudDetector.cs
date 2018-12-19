
using System;

namespace ExternalLibrary.FraudDetector
{
    /// <summary>
    /// DO NOT TOUCH: It is an external library
    /// </summary>
    public sealed class FraudDetector
    {
        public bool IsCustomerFraudDetected(string firstName, string lastName, DateTime DateOfBirth)
        {
           return new Random().Next() % 2 == 0;
        }
    }
}
