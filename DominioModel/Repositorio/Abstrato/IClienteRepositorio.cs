using DominioModel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioModel.Repositorio.Abstrato
{
    public interface IClienteRepositorio
    {
        IQueryable<Cliente> Clientes { get; }


        void Inserir(Cliente cliente);

        void Alterar(Cliente cliente);

        void MudarEstado(int id, MudancaEstadoCliente estado);


        Cliente RetornarPorID(int id);

        ICollection<Cliente> Todos();
    }
}
