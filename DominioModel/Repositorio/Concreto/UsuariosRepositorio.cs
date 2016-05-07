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

        public void AlterarSenha(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            context.Entry(usuario).State = EntityState.Unchanged;
            context.Entry(usuario).Property(u => u.Senha).IsModified = true;
            context.SaveChanges();
        }

        public Usuario Autenticar(Usuario usuario)
        {
            var userAuth = this.Todos()
                .Where((usr) => 
                usr.Login.Equals(usuario.Login) && 
                BCrypt.Net.BCrypt.Verify(usuario.Senha, usr.Senha)
                ).SingleOrDefault();

            /*
            var userAuth = (from urs in Usuarios
                            where urs.Login.Equals(usuario.Login) && BCrypt.Net.BCrypt.Verify(usuario.Senha, urs.Senha)
                            select urs).SingleOrDefault();
                            */

            if ((userAuth != null) &&  (userAuth.Bloqueado))
                throw new BloqueioException();

            return (userAuth);
        }

        public void BloquearUsuario(int id, bool bloquear)
        {           
            var usuario = RetornarPorID(id);

            if (bloquear && (usuario.Papel == PapelUsuario.Administrador))
            {
                int adminCount = (from usr in Usuarios
                                  where usr.Papel == PapelUsuario.Administrador
                                  select usr).ToList().Count;
                 
                if (adminCount == 1)         
                    throw new Exception("Não é possível bloquear o único usuário do sistema.");
            }

            if (usuario == null)
                throw new Exception("Usuário não existe");

            usuario.Bloqueado = bloquear;
            context.Entry(usuario).Property(u => u.Bloqueado).IsModified = true;
            context.SaveChanges();
        }

        public void Inserir(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Bloqueado = false;
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public Usuario RetornarPorID(int id)
        {
            var usuario = context.Usuarios.Find(id);
            usuario.Senha = null;

            return usuario;
        }

        public ICollection<Usuario> Todos()
        {
            return Usuarios.ToList();
        }
    }
}
