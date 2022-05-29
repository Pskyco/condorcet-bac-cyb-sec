using System;

namespace medical_data.ViewModels
{
    public class ParticipantViewModel
    {
        public string StudyCode { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public bool HasEverDrank { get; set; }
        public bool HasEverSmoked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
    }
}