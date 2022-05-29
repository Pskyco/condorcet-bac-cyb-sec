using System;

namespace DataProtection.Models
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string EncryptedId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}