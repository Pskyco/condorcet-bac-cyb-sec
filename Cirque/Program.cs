using System;
using System.Collections.Generic;
using Cirque.Classes;
using Cirque.Enums;

namespace Cirque
{
    class Program
    {
        static void Main(string[] args)
        {
            var tour1 = new Tour();
            tour1.Nom = "Faire des jonglages";
            tour1.TypeTour = TypeTour.Acrobatie;
            
            // var tour1 = new Tour
            // {
            //     Nom = "Faire des jonglages",
            //     TypeTour = TypeTour.Acrobatie
            // };

            // var tour1 = new Tour("Faire des jonglages", TypeTour.Acrobatie);

            var tour2 = new Tour();
            tour2.Nom = "Faire de la batterie";
            tour2.TypeTour = TypeTour.Musique;

            var tour3 = new Tour();
            tour3.Nom = "Faire du saut à l'élastique";
            tour3.TypeTour = TypeTour.Acrobatie;

            var singe1 = new Singe();
            // 'Tours' has been init in empty ctor
            singe1.Tours.Add(tour2);
            singe1.Tours.Add(tour3);
            
            var singe2 = new Singe();
            // 'Tours' has been init in empty ctor
            singe2.Tours.Add(tour2);
            singe2.Tours.Add(tour1);

            var dresseur1 = new Dresseur();
            dresseur1.Singe = singe1;

            var dresseur2 = new Dresseur();
            dresseur2.Singe = singe2;

            var spectateur1 = new Spectateur();
            spectateur1.Nom = "Ludwig";

            var spectateur2 = new Spectateur();
            spectateur2.Nom = "Bruno";
            
            dresseur1.FaireLeShow(spectateur1);
            dresseur1.FaireLeShow(spectateur1);
            
            dresseur2.FaireLeShow(spectateur1);
            dresseur2.FaireLeShow(spectateur2);

            Console.WriteLine("Hello World!");
        }
    }
}