using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Klient : Osoba
    {
        private Koszyk koszyk;

        public Klient(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            koszyk = new Koszyk();
        }

        public void DodajDoKoszyka(Produkt p, int ile)
        {
            try
            {
                koszyk.DodajProdukt(p, ile);
            }
            catch(BrakProduktuNaMagazynieException e)
            {
                Console.WriteLine("Przepraszamy, brak wystarczającej ilości towaru na magazynie.");
            }
        }

        public override string TextToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
