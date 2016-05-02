using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioModel.Repositorio.Concreto
{
    public class BloqueioException : Exception
    {
        public BloqueioException() : base("Usuário bloqueado não pode ter acesso ao sistema") { }
    }
}
