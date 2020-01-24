using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class BrakProduktuNaMagazynieException : Exception
    {
        public BrakProduktuNaMagazynieException() : base("Przepraszamy, brak wystarczającej liczby produktów na magazynie")   { }
    }
}
