using System;
using Constructors.Classes;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("new Person(\"Ludwig\", \"Lebrun\")");
            var person = new Person("Ludwig", "Lebrun");
            Console.WriteLine($"Référence: {person.Reference}");

            Console.WriteLine("new Person(\"Ludwig\", 2.0m)");
            person = new Person("Ludwig", 2.0m);
            Console.WriteLine($"Référence: {person.Reference}");

            Console.WriteLine("new Person(\"Ludwig\", \"Lebrun\", 2.0m)");
            person = new Person("Ludwig", "Lebrun", 2.0m);
            Console.WriteLine($"Référence: {person.Reference}");
        }
    }
}