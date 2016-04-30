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
    public class HomeController : Controller
    {
        IUsuariosRepositorio userRep = new UsuariosRepositorio(new SADContext());


        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Index()
        {
            CustomPrincipal user = System.Web.HttpContext.Current.User as CustomPrincipal;

            if (user != null)
            {
                ViewBag.NomeUsuario = user.Nome;
                ViewBag.PapelUsuario = user.Papel;
                return View();
            }
            else
                return RedirectToAction("Autenticacao");
        }

        [AllowAnonymous]
        public ActionResult Autenticacao()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Autenticacao(AutenticacaoModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = userRep.Autenticar(new Usuario() { Login = model.Login, Senha = model.Senha });

                if (usuario != null)
                {
                    CustomPrincipalSerializeModel securityModel = new CustomPrincipalSerializeModel()
                    {
                        UsuarioID = usuario.UsuarioID,
                        Nome = usuario.Nome,
                        Papel = usuario.Papel
                    };

                    WizardSecurity.SignIn(this, securityModel);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Autenticacao", "Login ou senha inválido.");
                }
            }

            return View();
        }


        [CustomAuthorize(Roles = "Administrador,Gestor,Frentista")]
        public ActionResult Desautenticar()
        {
            WizardSecurity.SignOut();

            return RedirectToAction("Autenticacao");
        }

        [CustomAuthorize(Roles = "Administrador,Gestor,Frentista")]
        public ActionResult AcessoNegado()
        {
            return View();
        }
    }
}