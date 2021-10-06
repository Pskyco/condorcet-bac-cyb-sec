using System;
using System.Collections.Generic;
using System.Linq;

namespace Cirque.Classes
{
    public abstract class Animal
    {
        public List<Tour> Tours { get; set; }

        public Animal()
        {
            Tours = new List<Tour>();
        }

        public void DemontrerSesTours(Spectateur spectateur)
        {
            if (Tours == null || !Tours.Any())
                return;
            
            foreach (var tour in Tours)
            {
                tour.Exécuter(this);
                spectateur.Reagir(tour);
            }
            
            UneFoisLesToursFinis();
            UneFoisLesToursFinis2();
        }

        public abstract void UneFoisLesToursFinis();

        public virtual void UneFoisLesToursFinis2()
        {
            Console.WriteLine("L'animal s'en va");
        }
    }
}