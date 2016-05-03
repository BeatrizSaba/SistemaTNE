using DominioModel.Repositorio.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioModel.Entidades;
using System.Data.Entity;

namespace DominioModel.Repositorio.Concreto
{
    public class UsuariosRepositorio : BaseRepositorio, IUsuariosRepositorio
    {
        public UsuariosRepositorio(SADContext context) : base(context)
        {
        }

        public IQueryable<Usuario> Usuarios
        {
            get
            {
                return context.Usuarios;
            }
        }

        public void Alterar(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            context.Entry(usuario).Property(u => u.Login).IsModified = false;
            context.Entry(usuario).Property(u => u.Bloqueado).IsModified = false;
            context.SaveChanges();
        }

        public Usuario Autenticar(Usuario usuario)
        {
            var userAuth = (from urs in Usuarios
                            where urs.Login.Equals(usuario.Login) && urs.Senha.Equals(usuario.Senha)
                            select urs).SingleOrDefault();

            if ((userAuth != null) &&  (userAuth.Bloqueado))
                throw new BloqueioException();

            return (userAuth);
        }

        public void BloquearUsuario(int id, bool bloqueado)
        {
            var usuario = RetornarPorID(id);

            if (usuario == null)
                throw new Exception("Usuário não existe");

            usuario.Bloqueado = bloqueado;
            context.Entry(usuario).Property(u => u.Bloqueado).IsModified = true;
            context.SaveChanges();
        }

        public void Inserir(Usuario usuario)
        {
            usuario.Bloqueado = false;
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public Usuario RetornarPorID(int id)
        {
            var usuario = context.Usuarios.Find(id);

            return usuario;
        }

        public ICollection<Usuario> Todos()
        {
            return Usuarios.ToList();
        }
    }
}
