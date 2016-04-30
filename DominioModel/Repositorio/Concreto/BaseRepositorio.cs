using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioModel.Repositorio.Concreto
{
    public class BaseRepositorio
    {
        protected SADContext context;

        public BaseRepositorio(SADContext context)
        {
            this.context = context;
        }
    }
}
