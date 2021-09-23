using System;

namespace Heritage.Classes
{
    public class Student : Person
    {
        // 'private set' is not required in this case. If we remove it, it'll also works, because CurrentSchoolYear is only set in our constructor.
        public int CurrentSchoolYear { get; private set; }

        public Student(int curentSchoolYear, string lastName, string firstName, string identificationNumber) : base(
            lastName, firstName, identificationNumber)
        {
            CurrentSchoolYear = curentSchoolYear;
        }

        public override void Print()
        {
            Console.WriteLine($"Je suis un étudiant avec les propriétés suivantes : " +
                              $"Prénom: {FirstName}, Nom: {LastName}, N° identification: {IdentificationNumber}");
        }

        public override string ToString()
        {
            return $"{CurrentSchoolYear};{FirstName};{LastName};{IdentificationNumber}";
        }

        // By default, Equals() method checks all properties. Here, we just want to check whether we have the same Identification Number.
        public override bool Equals(object? obj)
        {
            if (obj is Student)
                return IdentificationNumber == ((Student) obj).IdentificationNumber;

            return base.Equals(obj);
        }
    }
}