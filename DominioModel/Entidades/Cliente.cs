using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioModel.Entidades
{
    public class Cliente
    {

        public int ClienteID { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataModificacao { get; set; }

        public string Nome { get; set; }
        
        public DateTime DataNascimento { get; set; }

        public Veiculo Veiculo { get; set; }

        public List<Posto> PostoFavoritos { get; set; }

        public Endereco Endereco { get; set; }

        public List<FormaPagamento> FormasPagamento { get; set; }

        public List<Servico> ServicosUtilizados { get; set; }

        public FrequenciaCompra FrequenciaCompra { get; set; }

        public EstadoCliente Estado { get; set; }

        public RamoAtividade RamoAtividade { get; set; }

        public TipoPessoa Tipo { get; set; }

        public Marca MarcaPreferida { get; set; }
    }
}
