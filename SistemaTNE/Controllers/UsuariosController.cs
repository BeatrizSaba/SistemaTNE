using DominioModel.Entidades;
using DominioModel.Repositorio;
using DominioModel.Repositorio.Abstrato;
using DominioModel.Repositorio.Concreto;
using SistemaTNE.Controllers.Mensagem;
using SistemaTNE.Controllers.Seguranca;
using SistemaTNE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominioModel.Utils;
using System.ComponentModel.DataAnnotations;
using System.Net;

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

                    if (!(Enum.GetValues(typeof(PapelUsuario)) as PapelUsuario[]).Contains(model.Papel))
                    {
                        ModelState.AddModelError("Papel", "Selecione o tipo de usuário");
                    }


                    //Check login está sendo usado
                    var result = from urs in userRep.Usuarios
                                 where urs.Login.Equals(model.Login)
                                 select urs;

                    if (result.ToList().Count > 0)
                    {
                        ModelState.AddModelError("Login", "Este login já está sendo utilizado");

                    }


                    if (!ModelState.IsValid)
                        return Json(RespostaRequisicao.FromModelState(ModelState));



                    Usuario usuario = new Usuario()
                    {
                        Nome = model.Nome,
                        Login = model.Login,
                        Senha = model.Senha,
                        Papel = model.Papel
                    };

                    userRep.Inserir(usuario);


                    return Json(RespostaRequisicao.SimpleOK());
                }
                else
                    return Json(RespostaRequisicao.FromModelState(ModelState));
            }
            catch
            {
                return Json(RespostaRequisicao.DefaultInternalError());
            }
        }

        [CustomAuthorize(Roles = "Administrador")]
        public ActionResult Lista()
        {
            return PartialView();
        }

        [CustomAuthorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Pesquisar()
        {
            var resultado = (from urs in userRep.Usuarios
                             select new { urs.UsuarioID, urs.Nome, urs.Login, urs.Papel, urs.Bloqueado }
                            ).ToList();

            List<VistaUsuarioModel> usuarios = new List<VistaUsuarioModel>();

            foreach (var urs in resultado)
            {
                usuarios.Add(new VistaUsuarioModel()
                {
                    UsuarioID = urs.UsuarioID,
                    Nome = urs.Nome,
                    Login = urs.Login,
                    Papel = urs.Papel.GetAttributeOfType<DisplayAttribute>().Name,
                    Bloqueado = urs.Bloqueado ? "Sim" : "Não"
                });
            }

            return Json(usuarios);
        }

        [CustomAuthorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult MudarBloqueio(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var usuario = userRep.RetornarPorID(id.GetValueOrDefault());

                    if (usuario != null)
                    {
                        userRep.BloquearUsuario(usuario.UsuarioID, !usuario.Bloqueado);

                        string msg;

                        if (usuario.Bloqueado)
                            msg = "Usuário desbloqueado.";
                        else
                            msg = "Usuario bloqueado.";


                        return Json(RespostaRequisicao.SimpleText(msg));
                    }
                    else
                    {
                        return Json(RespostaRequisicao.SimpleError("Usuário não encontrado."));
                    }
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}