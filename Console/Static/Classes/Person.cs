using System;

namespace Static.Classes
{
    public class Person
    {
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Print()
        {
            Console.WriteLine($"FirstName: {FirstName}");
        }
    }
}