using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
    public class Observation
    {
        public Guid Id { get; set; }

        [Required] public DateTime DateTime { get; set; }

        [Required] public string Comment { get; set; }

        public Guid PcrTestId { get; set; }

        public PcrTest PcrTest { get; set; }
    }
}