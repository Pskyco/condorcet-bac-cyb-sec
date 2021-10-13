using System;

namespace Heritage.Interfaces
{
    // We can't instantiate interfaces.
    public interface IPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}