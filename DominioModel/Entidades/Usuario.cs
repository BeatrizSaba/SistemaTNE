using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Usuario
    {

        public int UsuarioID { get; set; }

        [Required]
        [StringLength(30)]
        public string Login { get; set; }

        [Required]
        [StringLength(30)]
        public string Senha { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        public PapelUsuario Papel { get; set; }
    }
}
