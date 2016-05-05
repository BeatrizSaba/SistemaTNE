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
            cliente.DataModificacao = DateTime.Now;
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Inserir(Cliente cliente)
        {
            cliente.DataCriacao = DateTime.Now;
            cliente.DataModificacao = DateTime.Now;

            var endereco = (from end in context.Enderecos
                           where (end.CEP.Equals(cliente.Enderecos.CEP))
                           select end).SingleOrDefault();

            if (endereco != null)
            {
                if (!EnderecoIguais(endereco, cliente.Enderecos))
                    throw new Exception("Eexiste um endereço diferente cadastrado com este CEP.");

                cliente.Enderecos = endereco;                          
            }
            else
                cliente.Enderecos = BuscarComplementosEndereco(cliente.Enderecos);

            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        private Endereco BuscarComplementosEndereco(Endereco endereco)
        {
            var uf = context.UFs.Where(e => e.Nome.Equals(endereco.UFs.Nome)).SingleOrDefault();

            if (uf != null)
            {
                endereco.UFs = uf;
            }

            var cidade = context.Cidades.Where(e => e.Nome.Equals(endereco.Cidades.Nome)).SingleOrDefault();

            if (cidade != null)
            {
                endereco.Cidades = cidade;
            }

            endereco.Cidades.UFs = endereco.UFs;

            var bairro = context.Bairros.Where(e => e.Nome.Equals(endereco.Bairros.Nome)).SingleOrDefault();

            if (bairro != null)
            {
                endereco.Bairros = bairro;
            }

            endereco.Bairros.Cidades = endereco.Cidades;

            endereco.Bairros.Enderecos = null;
            endereco.Cidades.Bairros = null;              
            endereco.Cidades.Enderecos = null;
            endereco.UFs.Cidades = null;
            endereco.Cidades.UFs.Enderecos = null;

            return endereco;
        }

        private bool EnderecoIguais(Endereco end1, Endereco end2)
        {
            return (
                end1.CEP.Equals(end2.CEP) &&
                end1.Logradouro.Equals(end2.Logradouro) &&
                end1.Bairros.Nome.Equals(end2.Bairros.Nome) &&
                end1.Cidades.Nome.Equals(end2.Cidades.Nome) &&
                end1.UFs.Nome.Equals(end2.UFs.Nome)
                );
        }

        public void MudarEstado(int id, MudancaEstadoCliente estado)
        {
            var cliente = RetornarPorID(id);
            cliente.MudancasEstado.Add(estado);
            context.SaveChanges();
        }

        public Cliente RetornarPorID(int id)
        {
            return context.Clientes.Find(id);
        }

        public ICollection<Cliente> Todos()
        {
            return Clientes.ToList();
        }
    }
}
