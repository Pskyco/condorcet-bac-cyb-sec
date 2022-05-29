namespace medical_data.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string StudyCode { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public bool HasEverDrank { get; set; }
        public bool HasEverSmoked { get; set; }
    }
}