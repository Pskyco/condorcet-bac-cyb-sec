using System;

namespace Constructors.Classes
{
    public class Person
    {
        private string FirstName { get; }
        private string LastName { get; }
        public string Reference { get; private set; }
        private decimal Score { get; }

        private Person()
        {
            Console.WriteLine("ctor #1");
            SetReference();
        }

        private Person(string reference)
        {
            Console.WriteLine("ctor #2");
            Reference = reference;
        }

        public Person(string firstName, string lastName) : this("référence de test")
        {
            Console.WriteLine("ctor #3");
            FirstName = firstName;
            LastName = lastName;
        }

        public Person(string firstName, decimal score) : this()
        {
            Console.WriteLine("ctor #4");
            FirstName = firstName;
            Score = score;
        }

        public Person(string firstName, string lastName, decimal score)
        {
            Console.WriteLine("ctor #5");
            FirstName = firstName;
            LastName = lastName;
            Score = score;
            SetReference();
        }

        private void SetReference()
        {
            Reference = string.Empty;
            if (!string.IsNullOrWhiteSpace(FirstName))
                Reference += FirstName.Substring(0, FirstName.Length >= 2 ? 2 : FirstName.Length);
            if (!string.IsNullOrWhiteSpace(LastName))
                Reference += LastName.Substring(0, LastName.Length >= 2 ? 2 : LastName.Length);
        }
    }
}