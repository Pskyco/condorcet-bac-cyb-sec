using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities
{
    public class PcrTest
    {
        public Guid Id { get; set; }
        
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }
        
        [MaxLength(512)]
        public string Comment { get; set; }
        
        public DateTime? ReceptionDate { get; set; }
        
        public DateTime? AnalysisDate { get; set; }
    }
}