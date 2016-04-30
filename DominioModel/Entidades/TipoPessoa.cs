using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public enum TipoPessoa
    {
        [Display(Name = "Fisica")]
        Fisica = 1,
        [Display(Name = "Jurídica")]
        Juridica = 2
    }
}