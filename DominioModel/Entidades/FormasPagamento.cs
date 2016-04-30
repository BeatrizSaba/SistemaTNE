

using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public enum FormaPagamento
    {
        [Display(Name = "Selecionar ...")]
        Nulo = 0,
        [Display(Name = "Dinheiro")]
        Dinheiro = 1,
        [Display(Name = "Crédito")]
        Credito = 2,
        [Display(Name = "Débito")]
        Debito = 3,
        [Display(Name = "A prazo")]
        Prazo = 4 
    }
}
