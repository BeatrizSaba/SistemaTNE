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
using System.Net;
using System.Web;
using System.Web.Mvc;
using DominioModel.Utils;
using System.ComponentModel.DataAnnotations;

namespace SistemaTNE.Controllers
{
    public class ClientesController : Controller
    {
        public ClientesController()
        {
            context = new SADContext();
            clientRepo = new ClienteRepositorio(context);
        }

        SADContext context;
        IClienteRepositorio clientRepo;

        // GET: Cliente
        [CustomAuthorize(Roles = "Administrador,Gestor,Frentista")]
        public ActionResult NovoEditar()
        {
            return PartialView();
        }

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Lista()
        {        
            return PartialView();
        }

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        [HttpPost]
        public ActionResult Pesquisar()
        {
            try
            {
                var clientes = clientRepo.Todos();

                return Json(ClienteView.ParseList(clientes));
            }
            catch(Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }


        public ActionResult Novo()
        {
            CriarSelects();

            return PartialView();
        }

        [HttpPost]
        public ActionResult Novo(ClienteModal model)
        {
            try
            {

                if (!(Enum.GetValues(typeof(TipoPessoa)) as TipoPessoa[]).Contains(model.TipoPessoa))
                {
                    ModelState.AddModelError("TipoPessoa", "Selecione um valor para o campo Tipo de poessoa");
                }

                if (!(Enum.GetValues(typeof(EstadoCliente)) as EstadoCliente[]).Contains(model.Estado))
                {
                    ModelState.AddModelError("Estado", "Selecione um valor para o campo Estado");
                }

                if (ModelState.IsValid)
                {
                    clientRepo.Inserir(model.Parse(context));

                    return Json(RespostaRequisicao.SimpleText("Cliente cadastrado."));
                }
                else
                {
                    ModelState.AddModelError("Summary", "Corriga os erros abaixo antes de salvar.");
                    return Json(RespostaRequisicao.FromModelState(ModelState));
                }
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }


        public ActionResult Contato()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Contato(ContatoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(RespostaRequisicao.SimpleOK());
            }
            else
                return Json(RespostaRequisicao.FromModelState(ModelState));
        }

        private void CriarSelects()
        {
            SADContext context = new SADContext();


            IList<SelectListItem> selectRamosAtiv = (from ramo in context.RamosAtividades
                                                     select new SelectListItem()
                                                     {
                                                         Text = ramo.Descricao,
                                                         Value = ramo.RamoAtividadeID.ToString()
                                                     }).ToList();

            selectRamosAtiv.Insert(0, new SelectListItem()
            {
                Text = "Selecionar...",
                Value = "0"
            });

            ViewBag.RamosAtividade = selectRamosAtiv;


            IList<SelectListItem> selectPostos = (from posto in context.Postos
                                                  select new SelectListItem()
                                                  {
                                                      Text = posto.Nome,
                                                      Value = posto.PostoID.ToString()
                                                  }).ToList();


            ViewBag.Postos = selectPostos;


            IList<SelectListItem> selectServicos = (from servico in context.Servicos
                                                    select new SelectListItem()
                                                    {
                                                        Text = servico.Descricao,
                                                        Value = servico.ServicoID.ToString()
                                                    }).ToList();

            ViewBag.Servicos = selectServicos;


            IList<SelectListItem> selectMarcas = (from marca in context.Marcas
                                                  select new SelectListItem()
                                                  {
                                                      Text = marca.Nome,
                                                      Value = marca.MarcaID.ToString()
                                                  }).ToList();

            ViewBag.Marcas = selectMarcas;
        }

    }
}