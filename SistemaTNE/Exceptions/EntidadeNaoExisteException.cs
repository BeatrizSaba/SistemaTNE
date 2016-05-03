using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTNE.Exceptions
{
    public class EntidadeNaoExisteException : Exception
    {
        public EntidadeNaoExisteException() : base() { }

        public EntidadeNaoExisteException(string msg) : base(msg) { }
    }
}