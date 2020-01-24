using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    static class Magazyn
    {
        private static Dictionary<Produkt, int> stanMagazynu = new Dictionary<Produkt, int>();

        public static void DodajProdukt(Produkt p, int ile)
        {
            if (stanMagazynu.ContainsKey(p))
            {
                stanMagazynu[p] += ile;
                return;
            }
            else
            {
                stanMagazynu.Add(p, ile);
            }
        }

        public static void WydajProdukt(Produkt p, int ile)
        {
            stanMagazynu[p] -= ile;
            if(stanMagazynu[p] == 0)
            {
                throw new BrakProduktuNaMagazynieException();
            }
        }

        public static Dictionary<Produkt, int> WszystkieProdukty()
        {
            return stanMagazynu;
        }

        public static List<Produkt> DostepneProdukty()
        {
            List<Produkt> produkty = new List<Produkt>();
            foreach (var produkt in stanMagazynu)
            {
                if (produkt.Value > 0)
                {
                    produkty.Add(produkt.Key);
                }
            }

            return produkty;
        }

        public static int IleDostepnych(Produkt p)
        {
            return stanMagazynu[p];
        }
    }
}
