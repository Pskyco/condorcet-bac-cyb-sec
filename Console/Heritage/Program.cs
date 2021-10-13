using System;
using Heritage.Classes;

namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            // can't call empty constructor since it's declared as 'private'.
            // var person = new Person();
            // person.Print();

            var person2 = new Person("Lebrun", "Ludwig");
            person2.Print();
            
            var person3 = new Person("01010124964");
            person3.Print();
            
            var person4 = new Person("01010124964", "Lebrun", "Ludwig");
            person4.Print();

            var student = new Student(2, "Lebrun", "Ludwig", "00112229534");
            student.Print();
            // will call 'Print' function in Student, because it has been override.
            Console.WriteLine(student.ToString());

            var student2 = new Student(3, "Lebrun", "Ludwig", "00112229534");
            Console.WriteLine($"Mes objets sont-ils égaux ? {student.Equals(student2)}");
            // since we have override 'Equals' method, only identification number will be compared.
            
            Console.WriteLine("Hello World!");
        }
    }
}