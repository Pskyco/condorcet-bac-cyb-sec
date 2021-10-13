using System;

namespace Heritage.Interfaces
{
    public interface IIdentifiable
    {
        public string IdentificationNumber { get; set; }

        public void WriteIdentificationNumber()
        {
            Console.WriteLine($"Numéro d'identification: {IdentificationNumber}");
        }
    }
}