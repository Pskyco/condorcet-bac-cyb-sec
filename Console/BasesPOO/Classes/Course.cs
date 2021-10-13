using System;

namespace BasesPOO.Classes
{
    public class Course
    {
        public int Ects { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public Course()
        {
        }

        public override string ToString()
        {
            return $"{Name} ({Ects} ECTS), du {StartDate:dd'/'MM'/'yyyy} au {EndDate:dd'/'MM'/'yyyy}";
        }
    }
}