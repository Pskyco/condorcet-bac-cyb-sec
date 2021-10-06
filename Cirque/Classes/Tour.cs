using System;
using Cirque.Enums;

namespace Cirque.Classes
{
    public class Tour
    {
        public string Nom { get; set; }
        public TypeTour TypeTour { get; set; }

        public Tour()
        {
            
        }
        
        public Tour(string nom, TypeTour typeTour)
        {
            Nom = nom;
            TypeTour = typeTour;
        }

        public void Exécuter(Animal animal)
        {
            Console.WriteLine($"Mon {animal.GetType().Name} exécute {ToString()}");
        }

        public override string ToString()
        {
            // return string.Format("le tour {0} de type {1}", Nom, TypeTour);
            // return "le tour " + Nom + " de type " + TypeTour; 
            return $"le tour {Nom} de type {TypeTour}";
        }
    }
}