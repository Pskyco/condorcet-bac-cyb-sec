using System;

namespace Heritage.Classes
{
    // if our application doesn't need to instantiate 'Person', this class can be made abstract.
    public class Person : object // : object is an implicit inheritance, all objects inherits from object.
    {
        protected string IdentificationNumber { get; set; }
        protected string LastName { get; set; }
        protected string FirstName { get; set; }

        private Person()
        {
        }

        // ctor1
        public Person(string identificationNumber)
        {
            // if IdentificationNumber have not been already set, set it.
            if (string.IsNullOrWhiteSpace(IdentificationNumber) && identificationNumber.Length == 11)
                IdentificationNumber = identificationNumber;
            Console.WriteLine("ctor1");
        }

        // ctor2
        public Person(string identificationNumber, string lastName, string firstName) :
            this(lastName, firstName) // ctor3 will be called BEFORE executing current ctor code thanks to 'this(..)'
        {
            if (identificationNumber.Length == 11)
                IdentificationNumber = identificationNumber;
            Console.WriteLine("ctor2");
        }

        // ctor3
        public Person(string lastName, string firstName) :
            this("00000014387") // ctor1 will be called BEFORE executing current ctor code thanks to 'this(..)'
        {
            if (lastName.Length > 5)
                LastName = lastName;
            if (firstName.Length > 5)
                FirstName = firstName;
            Console.WriteLine("ctor3");
        }

        // 'virtual' means that children can override this method
        public virtual void Print()
        {
            Console.WriteLine($"Je suis une personne avec les propriétés suivantes : " +
                              $"Prénom: {FirstName}, Nom: {LastName}, N° identification: {IdentificationNumber}");
        }
    }
}