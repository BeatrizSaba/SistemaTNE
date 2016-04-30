using DominioModel.Entidades;
using DominioModel.Repositorio;
using DominioModel.Repositorio.Abstrato;
using DominioModel.Repositorio.Concreto;
using SistemaTNE.Controllers.Seguranca;
using SistemaTNE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTNE.Controllers
{
    public class UsuariosController : Controller
    {

        IUsuariosRepositorio userRep = new UsuariosRepositorio(new SADContext());

        [CustomAuthorize(Roles = "Administrador")]
        public ActionResult Novo()
        {
            return PartialView();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador")]
        public ActionResult Novo(CriarUsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!model.Senha.Equals(model.ConfirmarSenha))
                    {
                        ModelState.AddModelError("ConfirmarSenha", "As senhas não conferem");
                    }
                    else
                    {
                        Usuario usuario = new Usuario()
                        {
                            Nome = model.Nome,
                            Login = model.Login,
                            Senha = model.Senha,
                            Papel = model.Papel
                        };

                        userRep.Inserir(usuario);

                        return Json("{Resultado: OK}");
                    }
                }
            }
            catch
            {
                return Json("{Resultado: Erro, Mensagem: [{Campo: Valor}]}");
            }

            return PartialView();
        }

        [CustomAuthorize(Roles = "Administrador")]
        public ActionResult Lista()
        {
            return PartialView();
        }
    }
}