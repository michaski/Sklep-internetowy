using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class BrakProduktuNaMagazynieException : Exception
    {
        private Produkt produkt;
        public BrakProduktuNaMagazynieException() : base("Brak wystarczającej liczby produktów na magazynie")   { }

        public BrakProduktuNaMagazynieException(Produkt p) : base("Brak wystarczającej liczby produktów na magazynie")
        {
            produkt = p;
        }

        public string InformacjeOProdukcie()
        {
            return produkt.ToString();
        }
    }
}
