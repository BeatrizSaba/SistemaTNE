
using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public enum PapelUsuario
    {
        [Display(Name = "Administrador")]
        Administrador = 1,
        [Display(Name = "Gestor")]
        Gestor = 2,
        [Display(Name = "Frentista")]
        Frentista = 3
    }
}
