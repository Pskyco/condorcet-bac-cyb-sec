using System;

namespace WebApplication.Models
{
    public class PcrTestViewModel
    {
        public string Code { get; set; }
        public string Comment { get; set; }
        public DateTime ReceptionDate { get; set; }
        public DateTime AnalysisDate { get; set; }
    }
}