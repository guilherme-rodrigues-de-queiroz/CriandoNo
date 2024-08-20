using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace criandoNo
{
    internal class No
    {
        private decimal valor;
        private No proximo;

       public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public No Proximo
        {
            get { return proximo; }
            set { proximo = value; }
        }
    }
}
