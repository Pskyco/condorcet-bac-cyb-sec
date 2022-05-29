using System;
using DataProtection.Models;

namespace DataProtection.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonViewModel ToViewModel(string encryptedId)
        {
            return new PersonViewModel()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                EncryptedId = encryptedId
            };
        }
    }
}