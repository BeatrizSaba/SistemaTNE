using DominioModel.Entidades;
using DominioModel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaTNE.Models
{
    public class ClienteView
    {
        public int ClienteID { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        public string DataNascimento { get; set; }

        [Display(Name = "Tipo de pessoa")]
        public string TipoPessoa { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Frequência que vai ao posto")]
        public string FrequenciaVisitaPosto { get; set; }

        [Display(Name = "Forma de pagamento mais utilizada")]
        public string FormaPagamentoUsada { get; set; }

        [Display(Name = "Ramo de atividade")]
        public string RamoAtividade { get; set; }

        [Display(Name = "Número/Complemento")]
        public string Residencia { get; set; }

        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        [Display(Name = "Modelo do veículo")]
        public string ModeloVeiculo { get; set; }

        [Display(Name = "Placa")]
        public string PlacaVeiculo { get; set; }

        public string Marcas { get; set; }

        [Display(Name = "Postos em que abastece")]
        public string Postos { get; set; }

        [Display(Name = "Serviços utilizadados")]
        public string Servicos { get; set; }
        
        public string Contatos { get; set; }

        public static ICollection<ClienteView> ParseList(ICollection<Cliente> clientes)
        {
            List<ClienteView> modelList = new List<ClienteView>();

            foreach (var cl in clientes)
            {
                ClienteView model = new ClienteView()
                {
                    Nome = cl.Nome,
                    DataNascimento = cl.DataNascimento.ToString("dd/MM/yyyy"),
                    ClienteID = cl.ClienteID,
                    FormaPagamentoUsada = cl.FormaPagamentoUsada == FormaPagamento.Nulo ? null : cl.FormaPagamentoUsada.GetAttributeOfType<DisplayAttribute>().Name,
                    FrequenciaVisitaPosto = cl.FrequenciaVisitaPosto == FrequenciaCompra.Nulo ? null : cl.FrequenciaVisitaPosto.GetAttributeOfType<DisplayAttribute>().Name,
                    TipoPessoa = cl.TipoPessoa.GetAttributeOfType<DisplayAttribute>().Name,
                    Residencia = cl.Residencia,
                    CEP = cl.Enderecos.CEP,
                    Logradouro = cl.Enderecos.Logradouro,
                    Bairro = cl.Enderecos.Bairros.Nome,
                    Cidade = cl.Enderecos.Cidades.Nome,
                    UF = cl.Enderecos.UFs.Nome,
                    Estado = cl.Estado.GetAttributeOfType<DisplayAttribute>().Name,
                };

                if (cl.RamoAtividade != null)
                {
                    model.RamoAtividade = cl.RamoAtividade.Descricao;
                }

                var veiculo = cl.Veiculos.FirstOrDefault();

                if (veiculo != null)
                {
                    model.ModeloVeiculo = veiculo.Modelo;
                    model.PlacaVeiculo = veiculo.Placa;
                }

                foreach (var m in cl.Marcas)
                {
                    if (model.Marcas != null)
                        model.Marcas += ",";

                    model.Marcas += m.Nome;
                }

                foreach (var s in cl.Servicos)
                {
                    if (model.Servicos != null)
                        model.Servicos += ",";

                    model.Servicos += s.Descricao;
                }

                foreach (var p in cl.Postos)
                {
                    if (model.Postos != null)
                        model.Postos += ",";

                    model.Postos += p.Nome;
                }

                foreach(var c in cl.Contatos)
                {
                    if (model.Contatos != null)
                        model.Contatos += " / ";

                    if (!String.IsNullOrEmpty(c.Nome))
                        model.Contatos += String.Format("{0}: ", c.Nome);

                    model.Contatos += c.Telefone;
                }

                modelList.Add(model);
            }

            return modelList;
        }
    }
}