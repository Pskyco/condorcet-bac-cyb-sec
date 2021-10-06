using System;
using System.Collections.Generic;

namespace Cirque.Classes
{
    public class Singe
    {
        public List<Tour> Tours { get; set; }

        public Singe()
        {
            Tours = new List<Tour>();
        }

        public void DemontrerSesTours(Spectateur spectateur)
        {
            foreach (var tour in Tours)
            {
                tour.Exécuter(this);
                spectateur.Reagir(tour);
            }
        }
    }
}