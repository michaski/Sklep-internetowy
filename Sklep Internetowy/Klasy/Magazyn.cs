using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Magazyn
    {
        private List< Pair<Produkt, int> > stanMagazynu;

        public Magazyn()
        {
            stanMagazynu = new List< Pair<Produkt, int> >();
        }

        public void DodajProdukt(Produkt p, int ile)
        {
            foreach(var produkt in stanMagazynu)
            {
                if(produkt.First == p)
                {
                    produkt.Second += ile;
                    return;
                }
            }

            stanMagazynu.Add(new Pair<Produkt, int>(p, ile));
        }

        public void WydajProdukt(Produkt p, int ile)
        {
            foreach(var produkt in stanMagazynu)    // szukamy wśród listy produktów tego, który mamy wydać
            {
                if(produkt.First == p)
                {
                    if(ile <= produkt.Second)    // ilość produktów na stanie jest wystarczająca - po prostu ubywa ilość
                    {
                        produkt.Second -= ile;
                        return;
                    }
                    else
                    {
                        throw new BrakProduktuNaMagazynieException(p);   // za mało produktów na magazynie, aby zrealizować zamówienie - zgłaszamy wyjątek
                    }
                }
            }

            throw new BrakProduktuNaMagazynieException(p); // brak takiego produktu na magazynie - zgłaszamy wyjątek
        }

        public List<Produkt> WszystkieProdukty()
        {
            List<Produkt> produkty = new List<Produkt>();
            foreach(var para in stanMagazynu)
            {
                produkty.Add(para.First);
            }

            return produkty;
        }

        public List<Produkt> DostepneProdukty()
        {
            List<Produkt> produkty = new List<Produkt>();
            foreach (var para in stanMagazynu)
            {
                if (para.Second > 0)
                {
                    produkty.Add(para.First);
                }
            }

            return produkty;
        }
    }
}
