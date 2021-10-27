using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public ICollection<PcrTest> PerformedPcrTests { get; set; }
    }
}