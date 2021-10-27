using System.ComponentModel.DataAnnotations;

namespace WebApplication.Entities.Enums
{
    public enum ResultEnum
    {
        [Display(Name = "Non réalisé", Order = 1)]
        NotDone = 0,
        [Display(Name = "Positif", Order = 2)]
        Positive = 1,
        [Display(Name = "Négatif", Order = 3)]
        Negative = 2,
        [Display(Name = "Non concluant", Order = 4)]
        NonConclusive = 3,
        [Display(Name = "Autre", Order = 6)]
        Other = 4,
        [Display(Name = "Perdu", Order = 5)]
        Lost = 5,
    }
}