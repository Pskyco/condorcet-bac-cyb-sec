using System;
using PcrAnalysis.Enums;

namespace PcrAnalysis.Classes
{
    public class Analysis
    {
        public Guid Id { get; set; }

        public string Reason { get; set; }

        public DateTime? AnalysisDate { get; set; }

        public DateTime? ReceptionDate { get; set; }

        // since `Result` prop isn't nullable, default value will be NotDone (= enum that has '0' value / first one by default)
        public ResultEnum Result { get; set; }

        public override string ToString()
        {
            var returnString = string.Empty;

            returnString = $"Id: {Id}, Reason: {Reason}";
            if (AnalysisDate.HasValue)
                returnString += $"\nAnalyzed on {AnalysisDate.Value:dd'/'MM'/'yyyy HH:mm:ss}"; // string interpolation

            // Differents kinds of 'string format'.
            // Console.WriteLine(string.Format("Analyzed on {0} {1} {2}", AnalysisDate.Value.ToString("dd'/'MM'/'yyyy")));
            // Console.WriteLine(string.Format("Analyzed on {0:dd'/'MM'/'yyyy}", AnalysisDate.Value));
            // Console.WriteLine("Analyzed on " + AnalysisDate.Value.ToString("dd'/'MM'/'yyyy") + " ... ");

            if (ReceptionDate.HasValue)
                returnString += $"\nReceived on {ReceptionDate.Value:dd'/'MM'/'yyyy  HH:mm:ss}";

            returnString += $"\nResult was {Result} ({((int) Result)})";

            return returnString;
        }
    }
}