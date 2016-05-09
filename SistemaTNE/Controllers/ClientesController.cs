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
        SADContext context;
        IClienteRepositorio clientRepo;


        public ClientesController()
        {
            context = new SADContext();
            clientRepo = new ClienteRepositorio(context);
        }


        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Lista()
        {        
            return PartialView();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador,Gestor")]
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

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Novo()
        {
            try
            {
                CriarSelects();

                return PartialView();
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Novo(ClienteModel model)
        {
            try
            {

                if (!(Enum.GetValues(typeof(TipoPessoa)) as TipoPessoa[]).Contains(model.TipoPessoa))
                {
                    if (ModelState["TipoPessoa"].Errors.Count == 0)
                        ModelState.AddModelError("TipoPessoa", "Selecione um valor para o campo Tipo de pessoa");
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


        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Editar(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var cliente = clientRepo.RetornarPorID(id.GetValueOrDefault());

                    if (cliente != null)
                    {
                        CriarSelects();
                        return PartialView(ClienteEditModel.From(cliente));
                    }
                    else
                    {
                        return Json(RespostaRequisicao.SimpleError("Cliente não encontrado."));
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

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Editar(ClienteEditModel model)
        {
            try
            {
                if (!(Enum.GetValues(typeof(TipoPessoa)) as TipoPessoa[]).Contains(model.TipoPessoa))
                {
                    if (!ModelState.ContainsKey("TipoPessoa"))
                        ModelState.AddModelError("TipoPessoa", "Selecione um valor para o campo Tipo de pessoa");
                }

                if (ModelState.IsValid)
                {
                    clientRepo.Alterar(model.Parse(context));
                    return Json(RespostaRequisicao.SimpleText("Alterações realizadas com sucesso."));
                }
                else
                {
                    ModelState.AddModelError("Summary", "Corriga os erros abaixo antes de salvar.");
                    return Json(RespostaRequisicao.FromModelState(ModelState));
                }
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Contato()
        {
            return PartialView();
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult Contato(ContatoModel model)
        {
            if (ModelState.IsValid)
            {
                return Json(RespostaRequisicao.SimpleOK());
            }
            else
                return Json(RespostaRequisicao.FromModelState(ModelState));
        }

        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult MudancaEstado(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var cliente = clientRepo.RetornarPorID(id.GetValueOrDefault());

                    if (cliente != null)
                    {
                        var model = new ClienteEstadoModel()
                        {
                            ClienteID = cliente.ClienteID,
                            Estado = cliente.Estado
                        };

                        return PartialView(model);
                    }
                    else
                        return Json(RespostaRequisicao.SimpleError("Cliente não encontrado"));
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Administrador,Gestor")]
        public ActionResult MudancaEstado(ClienteEstadoModel model)
        {
            try
            {
                if ((model.Estado == EstadoCliente.ExCliente) && (String.IsNullOrEmpty(model.Observacao)))
                {
                    ModelState.AddModelError("Observacao", "Deve-se informar o motivo pelo qual o cliente se tornou um Ex-Cliente");
                }

                var cliente = clientRepo.RetornarPorID(model.ClienteID);

                if (cliente.Estado == model.Estado)
                {
                    ModelState.AddModelError("Estado", "Este já é o estado atual do cliente");
                }

                if (ModelState.IsValid)
                {                  
                    clientRepo.MudarEstado(model.ClienteID, model.Estado, model.Observacao);

                    return Json(RespostaRequisicao.SimpleText("Estado do cliente alterado com suceso"));
                }
                else
                {
                    return Json(RespostaRequisicao.FromModelState(ModelState));
                }
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
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