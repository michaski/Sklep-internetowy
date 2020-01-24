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
            koszyk = new Koszyk(this, id);
        }

        public void DodajDoKoszyka(Produkt p, int ile)
        {
            try
            {
                koszyk.DodajProdukt(p, ile);
            }
            catch(BrakProduktuNaMagazynieException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Kup()
        {
            int wybor = 0;
            SpsobDostawy dostawa;
            while (wybor < 1 || wybor > 4)
            {
                Console.WriteLine("Proszę wybrać sposób dostawy:");
                Console.WriteLine("1. Odbiór osobisty w magazynie");
                Console.WriteLine("2. Paczkomat");
                Console.WriteLine("3. Kurier");
                Console.WriteLine("4. Kurier za pobraniem");
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Podano złą liczbę.");
                }
            }
            switch(wybor)
            {
                case 1:
                    dostawa = SpsobDostawy.OdbiorOsobisty;
                    break;
                case 2:
                    dostawa = SpsobDostawy.Paczkomat;
                    break;
                case 3:
                    dostawa = SpsobDostawy.Kurier;
                    break;
                case 4:
                    dostawa = SpsobDostawy.KurierZaPobraniem;
                    break;
                default:
                    dostawa = SpsobDostawy.OdbiorOsobisty;
                    break;
            }
            Zamowienie z = koszyk.ZlozZamowienie(dostawa);
            Console.WriteLine(z.Podsumowanie());
        }

        public void Zaplac()
        {
            Platnosci.ZaplaconoZamowienie(koszyk.Zamowienie);
        }

        public override string TextToPrint()
        {
            return String.Format($"Klient {imie} {nazwisko} (nr klienta {id})");
        }
    }
}
