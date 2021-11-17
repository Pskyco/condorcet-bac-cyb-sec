using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication.Entities.Enums;

namespace WebApplication.Entities
{
    public class PcrTest
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Unique code of pcr test
        /// </summary>
        [MaxLength(10)] [Required] public string Code { get; set; }

        [MaxLength(512)] public string Comment { get; set; }

        public DateTime? ReceptionDate { get; set; }

        public DateTime? AnalysisDate { get; set; }

        public ResultEnum Result { get; set; }

        public Guid? PerformerPersonId { get; set; }

        public Person PerformerPerson { get; set; }

        public ICollection<Observation> Observations { get; set; }
    }
}