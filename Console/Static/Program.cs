using System;
using Static.Classes;
using Static.Extensions;
using Static.Helpers;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var person = new Person()
            {
                FirstName = "Ludwig",
                LastName = "Lebrun",
                NationalNumber = "00000011122"
            };
            
            person.Print();

            // var dataFormatter = new DataFormatter();
            // Console.WriteLine(dataFormatter.PrettyPrintNationalNumber(person.NationalNumber));

            Console.WriteLine(DataFormatter.PrettyPrintNationalNumber(person.NationalNumber));
            
            Console.WriteLine(person.NationalNumber.PrettyPrintNationalNumber());
        }
    }
}