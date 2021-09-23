using System;
using PcrAnalysis.Classes;
using PcrAnalysis.Enums;

namespace PcrAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var analysis1 = new Analysis();
            analysis1.Id = Guid.NewGuid();
            analysis1.Reason = "Festival";
            
            Console.WriteLine(analysis1.ToString());
            
            analysis1.ReceptionDate = DateTime.Now.AddDays(-2).AddHours(-3).AddMinutes(-15);
            analysis1.AnalysisDate = DateTime.Now.AddMinutes(-20);
            analysis1.Result = ResultEnum.Negative;
            Console.WriteLine(analysis1.ToString());
            
            Console.WriteLine("Hello World!");
        }
    }
}