using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolaDePrueba
{
    class Numero : IComparable
    {
        public int valor { get; set; }

        public int CompareTo(object obj)
        {
            var temp = obj as Numero;

            if (this.valor == temp.valor)
            {
                return 0;
            }
            else if (this.valor > temp.valor)
            {
                return 1;
            }
            if (this.valor < temp.valor)
            {
                return -1;
            }

            return 2;
        }
    }
}
