using System;
using Cirque.Enums;

namespace Cirque.Classes
{
    public class Spectateur
    {
        public string Nom { get; set; }

        public void Reagir(Tour tour)
        {
            if(tour.TypeTour == TypeTour.Acrobatie)
                Console.WriteLine($"Le spectateur {Nom} applaudit au tour '{tour.Nom}'");
                
            if(tour.TypeTour == TypeTour.Musique)
                Console.WriteLine($"Le spectateur {Nom} siffle au tour '{tour.Nom}'");
        }
    }
}