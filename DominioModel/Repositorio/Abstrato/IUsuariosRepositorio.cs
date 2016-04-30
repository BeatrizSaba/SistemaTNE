using DominioModel.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace DominioModel.Repositorio.Abstrato
{
    public interface IUsuariosRepositorio
    {
        IQueryable<Usuario> Usuarios { get; }


        void Inserir(Usuario usuario);

        void Alterar(Usuario usuario);

        void BloquearUsuario(int id, bool bloqueado);


        Usuario Autenticar(Usuario usuario);

        Usuario RetornarPorID(int id);

        ICollection<Usuario> Todos();    
    }
}
