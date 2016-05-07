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
