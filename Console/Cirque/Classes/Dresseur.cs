namespace Cirque.Classes
{
    public class Dresseur
    {
        public Animal Animal { get; set; }

        public void FaireLeShow(Spectateur spectateur)
        {
            Animal.DemontrerSesTours(spectateur);
        }

        // public void FaireLeShow(List<Spectateur> spectateurs)
        // {
        //     foreach (var tour in Singe.Tours)
        //     {
        //         Console.WriteLine($"Mon singe exécute {tour}");
        //
        //         foreach (var spectateur in spectateurs)
        //         {
        //             spectateur.Reagir(tour);
        //         }
        //     }
        // }
    }
}