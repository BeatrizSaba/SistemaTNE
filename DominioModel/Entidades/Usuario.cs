using System.ComponentModel.DataAnnotations;

namespace DominioModel.Entidades
{

    public partial class Usuario
    {
        public int UsuarioID { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public PapelUsuario Papel { get; set; }

        public bool Bloqueado { get; set; }


        public override bool Equals(object obj)
        {
            Usuario usr = (Usuario)obj;

            return(usr.Login.Equals(this.Login) || (usr.UsuarioID == this.UsuarioID));
        }
    }
}
