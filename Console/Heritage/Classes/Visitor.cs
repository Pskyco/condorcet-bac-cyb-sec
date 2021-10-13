namespace Heritage.Classes
{
    public class Visitor : Person
    {
        public Visitor(string identificationNumber) : base(identificationNumber)
        {
        }

        public Visitor(string identificationNumber, string lastName, string firstName) : base(identificationNumber,
            lastName, firstName)
        {
        }

        public Visitor(string lastName, string firstName) : base(lastName, firstName)
        {
        }
    }
}