using DominioModel.Entidades;
using DominioModel.Repositorio;
using SistemaTNE.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DominioModel.Utils;
using System.Web.Script.Serialization;

namespace SistemaTNE.Models
{
    public class ClienteModal
    {
        public int ClienteID { get; set; }

        [Required]
        [StringLength(70)]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "Tipo de pessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public EstadoCliente Estado { get; set; }

        [Required]
        [Display(Name = "Frequência que vai ao posto")]
        public FrequenciaCompra FrequenciaVisitaPosto { get; set; }

        [Required]
        [Display(Name = "Forma de pagamento mais utilizada")]
        public FormaPagamento FormaPagamentoUsada { get; set; }

        [Display(Name = "Ramo de atividade")]
        public string RamoAtividadeID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Número/Complemento")]
        public string Residencia { get; set; }

        //[Required]
        //public int EnderecoID { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string UF { get; set; }


        [Display(Name = "Modelo do veículo")]
        public string ModeloVeiculo { get; set; }


        [Display(Name = "Placa")]
        public string PlacaVeiculo { get; set; }

        public string Contatos { get; set; }

        public string Marcas { get; set; }

        [Display(Name = "Postos em que abastece")]
        public string Postos { get; set; }

        [Display(Name = "Serviços utilizadados")]
        public string Servicos { get; set; }


        public Cliente Parse(SADContext context)
        {
            Cliente cliente = new Cliente()
            {
                Nome = this.Nome,
                DataNascimento = this.DataNascimento,
                TipoPessoa = this.TipoPessoa,
                Estado = this.Estado,
                FrequenciaVisitaPosto = this.FrequenciaVisitaPosto,
                FormaPagamentoUsada = this.FormaPagamentoUsada,
                Residencia = this.Residencia,
            };


            UF uf = new UF();
            uf.Nome = this.UF;

            Cidade cid = new Cidade();
            cid.Nome = this.Cidade;
            uf.Cidades.Add(cid);

            Bairro bai = new Bairro();
            bai.Nome = this.Bairro;
            cid.Bairros.Add(bai);

            Endereco end = new Endereco();
            end.Logradouro = this.Logradouro;
            end.CEP = this.CEP;
            end.Bairros = bai;
            end.Cidades = cid;
            end.UFs = uf;

            cliente.Enderecos = end;

            try
            {
                int ramoId = Int32.Parse(RamoAtividadeID);

                var ramoAtiv = context.RamosAtividades.Find(ramoId);

                if (ramoAtiv == null)
                    throw new EntidadeNaoExisteException("Ramo de atividade não encontrado");

                cliente.RamoAtividade = ramoAtiv;
            }
            catch (Exception e)
            {
                cliente.RamoAtividadeID = (int?)null;
            }
         

            if (this.Postos != null)
            {
                var postos = this.Postos.Split(',');
                foreach (var postoID in postos)
                {
                    var p = context.Postos.Find(Int32.Parse(postoID));

                    if (p == null)
                        throw new EntidadeNaoExisteException("Posto não encontrado");

                    cliente.Postos.Add(p);
                }
            }

            if (this.Marcas != null)
            {
                var marcas = this.Marcas.Split(',');
                foreach (var marcaID in marcas)
                {
                    var m = context.Marcas.Find(Int32.Parse(marcaID));

                    if (m == null)
                        throw new EntidadeNaoExisteException("Marca não encontrada");

                    cliente.Marcas.Add(m);
                }
            }

            if (this.Servicos != null)
            {
                var servicos = this.Servicos.Split(',');
                foreach (var servID in servicos)
                {
                    var s = context.Servicos.Find(Int32.Parse(servID));

                    if (s == null)
                        throw new EntidadeNaoExisteException("Serviço não encontrado");

                    cliente.Servicos.Add(s);
                }
            }

            if ((this.ModeloVeiculo != null) || (this.PlacaVeiculo != null))
            {
                Veiculo veic = new Veiculo()
                {
                    Modelo = this.ModeloVeiculo,
                    Placa = this.PlacaVeiculo
                };

                cliente.Veiculos.Add(veic);
            }

            JavaScriptSerializer json = new JavaScriptSerializer();

            if (this.Contatos != null)
            {
                 var contatos = json.Deserialize<List<ContatoModel>>(this.Contatos);

                foreach(var cont in contatos)
                {
                    cliente.Contatos.Add(new Contato()
                    {
                        Nome = cont.Nome,
                        Telefone = cont.Telefone
                    });
                }
            }

            return cliente;
        }

    }
}