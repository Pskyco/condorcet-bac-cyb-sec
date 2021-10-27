using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Entities;
using WebApplication.Entities.Enums;

namespace WebApplication.Models
{
    public class PcrTestViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le champ 'Code' est requis.")]
        [StringLength(10, ErrorMessage = "Code length can't be more than 10.")]
        public string Code { get; set; }

        public string Comment { get; set; }

        public DateTime? ReceptionDate { get; set; }

        public DateTime? AnalysisDate { get; set; }

        public ResultEnum Result { get; set; }
        
        public Person PerformerPerson { get; set; }

        public Guid? PerformerPersonId { get; set; }
        
        public List<SelectListItem> SliPersons { get; set; }
    }
}