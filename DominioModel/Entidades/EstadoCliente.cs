using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public enum EstadoCliente
    {
        [Display(Name = "Potencial")]
        Potencial = 1,
        [Display(Name = "Ativo")]
        Ativo = 2,
        [Display(Name = "Ex-Cliente")]
        ExCliente = 3
    }
}