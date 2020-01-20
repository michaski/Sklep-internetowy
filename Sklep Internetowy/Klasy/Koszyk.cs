using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Koszyk
    {
        private List<Produkt> produkty;

        public Koszyk()
        {
            produkty = new List<Produkt>();
        }

        public Koszyk(Produkt p)
        {
            produkty = new List<Produkt>();
            produkty.Add(p);
        }

        public Koszyk(List<Produkt> produkty)
        {
            this.produkty = new List<Produkt>();
            this.produkty.AddRange(produkty);
        }
    }
}
