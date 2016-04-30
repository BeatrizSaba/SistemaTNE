using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{
    public enum FrequenciaCompra
    {
        [Display(Name = "Selecionar ...")]
        Nulo = 0,
        [Display(Name = "Diária")]
        Diaria = 1,
        [Display(Name = "Semanal")]
        Semanal = 2,
        [Display(Name = "Quinzenal")]
        Quinzenal = 3,
        [Display(Name = "Mensal")]
        Mensal = 4
    }
}