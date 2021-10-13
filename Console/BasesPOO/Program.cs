using System;
using System.Collections.Generic;
using BasesPOO.Classes;
using BasesPOO.Enums;

namespace BasesPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            var course1 = new Course();
            course1.Name = "Complément Application";
            course1.Ects = 4;
            course1.StartDate = new DateTime(2021, 09, 15);
            course1.EndDate = new DateTime(2021, 11, 10);

            var course2 = new Course()
            {
                Name = "Programmation Sécurisée",
                Ects = 5,
                StartDate = new DateTime(2021, 11, 17),
                EndDate = new DateTime(2021, 01, 19)
            };

            var courses = new List<Course>();
            courses.Add(course1);
            courses.Add(course2);

            var teacher = new Teacher("Lebrun", GenderEnum.Male, new List<Course>()
            {
                course1,
                course2
            }, new DateTime(1996, 04, 07));

            Console.WriteLine(teacher);
            Console.ReadKey();
        }
    }
}