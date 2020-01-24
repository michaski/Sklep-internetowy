using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Koszyk
    {
        public Dictionary<Produkt, int> Produkty { get; private set; }

        public Koszyk()
        {
            Produkty = new Dictionary<Produkt, int>();
        }

        public Koszyk(Produkt p, int ile=1)
        {
            Produkty = new Dictionary<Produkt, int>();
            DodajProdukt(p, ile);
        }

        public void DodajProdukt(Produkt p, int ile=1)
        {
            if (Magazyn.IleDostepnych(p) >= ile)
            {
                Produkty.Add(p, ile);
            }
            else
            {
                throw new BrakProduktuNaMagazynieException();
            }
        }

        public void UsunProdukt(Produkt p, int ile=0)
        {
            if(ile > 0)
            {
                Produkty.Remove(p);
            }
            else
            {
                Produkty[p] -= ile;
            }
        }

        public Zamowienie ZlozZamowienie()
        {

        }
    }
}
