using System;
using System.Collections.Generic;
using System.Linq;
using BasesPOO.Enums;

namespace BasesPOO.Classes
{
    public class Teacher
    {
        private string LastName { get; }
        private GenderEnum GenderEnum { get; }
        private DateTime? BirthDate { get; }
        private List<Course> Courses { get;  }

        public Teacher(string lastName, GenderEnum gender, List<Course> courses, DateTime? birthDate = null)
        {
            LastName = lastName;
            GenderEnum = gender;
            Courses = courses;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            var genderPrefix = string.Empty;
            var birthDatePrefix = string.Empty;

            switch (GenderEnum)
            {
                case GenderEnum.Female:
                    genderPrefix = "Mme.";
                    birthDatePrefix = "née";
                    break;
                case GenderEnum.Male:
                    genderPrefix = "Mr.";
                    birthDatePrefix = "né";
                    break;
                case GenderEnum.Unknown:
                    genderPrefix = "Mr./Mme";
                    birthDatePrefix = "né·e";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // var genderPrefix = GenderEnum == GenderEnum.Male ? "Mr." :
            //     GenderEnum == GenderEnum.Female ? "Mme." : "Mr./Mme";
            //
            // var birthDatePrefix =
            //     GenderEnum == GenderEnum.Male ? "né" : GenderEnum == GenderEnum.Female ? "née" : "né·e";

            if (BirthDate.GetValueOrDefault() != DateTime.MinValue)
                return
                    $"{genderPrefix} {LastName}, {birthDatePrefix} le {BirthDate:dd'/'MM'/'yyyy}, donne les cours suivants : {GetGivenCourses()}";

            return
                $"{genderPrefix} {LastName}, {birthDatePrefix} à une date inconnue, donne les cours suivants : {GetGivenCourses()}";
        }

        private string GetGivenCourses()
        {
            if (Courses == null || !Courses.Any())
                return "aucun cours donné.";

            return string.Join(", ", Courses);
        }
    }
}