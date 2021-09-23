namespace Heritage.Classes
{
    public class Teacher : Person
    {
        int Seniority { get; set; }

        public Teacher(string identificationNumber) : base(identificationNumber)
        {
        }

        public Teacher(string identificationNumber, string lastName, string firstName) : base(identificationNumber,
            lastName, firstName)
        {
        }

        public Teacher(string lastName, string firstName) : base(lastName, firstName)
        {
        }
    }
}