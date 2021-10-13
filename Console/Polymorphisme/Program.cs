using System;
using Polymorphisme.Classes;

namespace Polymorphisme
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle()
            {
                Length = 6,
                Width = 4
            };

            Console.WriteLine(
                $"Mon rectangle de {rectangle.Length}cm sur {rectangle.Width}cm a une aire de {rectangle.GetArea()}cm² et un périmètre de {rectangle.GetPerimeter()}cm");

            Console.ReadKey();
        }
    }
}