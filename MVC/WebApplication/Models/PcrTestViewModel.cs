using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PcrTestViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Le champ 'Code' est requis.")]
        [StringLength(8, ErrorMessage = "Code length can't be more than 8.")]
        public string Code { get; set; }
        public string Comment { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public DateTime? AnalysisDate { get; set; }
    }
}