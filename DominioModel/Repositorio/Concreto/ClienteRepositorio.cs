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
    public class ClienteRepositorio : BaseRepositorio, IClienteRepositorio
    {
        public ClienteRepositorio(SADContext context) : base(context)
        {
        }

        public IQueryable<Cliente> Clientes
        {
            get
            {
                return context.Clientes;
            }
        }

        public void Alterar(Cliente cliente)
        {
            var persisCliente = RetornarPorID(cliente.ClienteID);

            persisCliente.Nome = cliente.Nome;
            persisCliente.DataNascimento = cliente.DataNascimento;
            persisCliente.FormaPagamentoUsada = cliente.FormaPagamentoUsada;
            persisCliente.FrequenciaVisitaPosto = cliente.FrequenciaVisitaPosto;
            persisCliente.RamoAtividade = cliente.RamoAtividade;
            persisCliente.TipoPessoa = cliente.TipoPessoa;
            persisCliente.Residencia = cliente.Residencia;

            
            var end = context.Enderecos.Where(e => e.CEP.Equals(cliente.Endereco.CEP)).SingleOrDefault();

            if (end != null)
                persisCliente.Endereco = end;
            else
            {
                persisCliente.Endereco = BuscarComplementosEndereco(cliente.Endereco);
            }


            //Está rotina trata apenas um veiculo.
            if ((cliente.Veiculos.Count == 0))
            {
                if (persisCliente.Veiculos.Count > 0)
                    persisCliente.Veiculos.Remove(persisCliente.Veiculos.First());
            }
            else
            {
                if (persisCliente.Veiculos.Count == 0)
                    persisCliente.Veiculos.Add(cliente.Veiculos.First());
                else
                {
                    persisCliente.Veiculos.First().Modelo = cliente.Veiculos.First().Modelo;
                    persisCliente.Veiculos.First().Placa = cliente.Veiculos.First().Placa;
                }
            }
            

            /*
            //Verificação para multiplos veiculos
            VerificarMundacaoList<Veiculo>(
                persisCliente.Veiculos,
                cliente.Veiculos,
                (v, v2) => v.VeiculoID == v2.VeiculoID,
                (persVeic, veic) =>
                {
                    persVeic.Modelo = veic.Modelo;
                    persVeic.Placa = veic.Placa;
                });
             */


            VerificarMundacaoList<Contato>(
                context.Contatos,
                persisCliente.Contatos,
                cliente.Contatos,
                (c, c2) => c.ContatoID == c2.ContatoID,
                (persCont, contat) =>
                {
                    //Contato já existe
                    persCont.Nome = contat.Nome;
                    persCont.Telefone = contat.Telefone;
                });


            VerificarMundacaoList<Marca>(
                null,
                persisCliente.Marcas,
                cliente.Marcas,
                (m, m2) => m.MarcaID == m2.MarcaID,
                (persMarca, marca) => { });


            VerificarMundacaoList<Posto>(
                null,
                persisCliente.Postos,
                cliente.Postos,
                (p, p2) => p.PostoID == p2.PostoID,
                (persPosto, posto) => { });


            VerificarMundacaoList<Servico>(
                null,
                persisCliente.Servicos,
                cliente.Servicos,
                (s, s2) => s.ServicoID == s2.ServicoID,
                (persServ, serv) => { });


            persisCliente.DataModificacao = DateTime.Now;

            context.Entry(persisCliente).State = EntityState.Modified;
            context.Entry(persisCliente).Property(e => e.DataCriacao).IsModified = false;
            context.Entry(persisCliente).Property(e => e.Estado).IsModified = false;

            context.SaveChanges();
        }

        public void Inserir(Cliente cliente)
        {
            cliente.DataCriacao = DateTime.Now;
            cliente.DataModificacao = DateTime.Now;

            var endereco = (from end in context.Enderecos
                           where (end.CEP.Equals(cliente.Endereco.CEP))
                           select end).SingleOrDefault();

            if (endereco != null)
            {
                if (!EnderecoIguais(endereco, cliente.Endereco))
                    throw new Exception("Eexiste um endereço diferente cadastrado com este CEP.");

                cliente.Endereco = endereco;                          
            }
            else
                cliente.Endereco = BuscarComplementosEndereco(cliente.Endereco);

            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        private Endereco BuscarComplementosEndereco(Endereco endereco)
        {
            var uf = context.UFs.Where(e => e.Nome.Equals(endereco.UF.Nome)).SingleOrDefault();

            if (uf != null)
            {
                endereco.UF = uf;
            }

            var cidade = context.Cidades.Where(e => e.Nome.Equals(endereco.Cidade.Nome)).SingleOrDefault();

            if (cidade != null)
            {
                endereco.Cidade = cidade;
            }


            var bairro = context.Bairros.Where(e => e.Nome.Equals(endereco.Bairro.Nome)).SingleOrDefault();

            if (bairro != null)
            {
                endereco.Bairro = bairro;
            }

            return endereco;
        }

        private bool EnderecoIguais(Endereco end1, Endereco end2)
        {
            return (
                end1.CEP.Equals(end2.CEP) &&
                end1.Logradouro.Equals(end2.Logradouro) &&
                end1.Bairro.Nome.Equals(end2.Bairro.Nome) &&
                end1.Cidade.Nome.Equals(end2.Cidade.Nome) &&
                end1.UF.Nome.Equals(end2.UF.Nome)
                );
        }

        public void MudarEstado(int id, EstadoCliente estado, string observacao)
        {
            var cliente = RetornarPorID(id);

            if (cliente.Estado != estado)
            {
                cliente.Estado = estado;
                context.Entry(cliente).Property(e => e.Estado).IsModified = true;


                cliente.MudancasEstado.Add(new MudancaEstadoCliente()
                {
                    ClienteID = id,
                    EstadoAnterior = cliente.Estado,
                    EstadoNovo = estado,
                    Observacao = observacao,
                    DataModificacao = DateTime.Now

                });               

                context.SaveChanges();
            }
        }

        public Cliente RetornarPorID(int id)
        {
            return context.Clientes.Find(id);
        }

        public ICollection<Cliente> Todos()
        {
            return Clientes.ToList();
        }


        /// <summary>
        /// Verificar se há modificações em uma lista a partir de outro e realizar as devidas modificações.
        /// </summary>
        /// <typeparam name="T">Tipo Generico</typeparam>
        /// <param name="db">DBSet necessário para remover dados do banco. Caso não queira que os dados sejam removidos devi-se para null para este paramêtro.</param>
        /// <param name="persisList">Lista que recebera as modificações (Desatulizada)</param>
        /// <param name="modifList">Lista que contém as modificações (Atualizada)</param>
        /// <param name="equalCondicao">Método que testa se dois objetos da lista são iguais.
        /// </param>
        /// <param name="updateMetodo">Método que realizar a atualização de dados de um objeto. O método contém dois paramêtros.
        /// arg0: Objeto que recebera as modificações
        /// arg1: Objeto com os dados atualizados
        /// </param>
        private void VerificarMundacaoList<T>(DbSet db, ICollection<T> persisList, ICollection<T> modifList, Func<T, T, bool> equalCondicao, Action<T, T> updateMetodo)
        {
            List<object> auxList = new List<object>();

            auxList.RemoveAll((e) => true);

            //Verificar se alguma objeto foi removida
            foreach (var obj in persisList)
            {
                if (modifList.ToList().Find(o => equalCondicao(o, obj)) == null)
                    auxList.Add(obj);
            }

            foreach (var o in auxList)
            {
                persisList.Remove((T)o);
                if (db != null)
                    db.Remove((T)o);
            }

            //Verificar novos objetos foram adicionadas
            foreach (var obj in modifList)
            {
                var persisObj = persisList.ToList().Find(o => equalCondicao(o, obj));

                if (persisObj == null)
                    persisList.Add(obj);
                else
                    updateMetodo(persisObj, obj);
            }
        }
    }
}
