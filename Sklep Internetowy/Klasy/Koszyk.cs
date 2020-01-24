using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Koszyk : IPrintable
    {
        private double wartosc;
        private int idKoszyka;
        private Klient wlasciciel;
        public Zamowienie Zamowienie { get; private set; }
        public Dictionary<Produkt, int> Produkty { get; private set; }

        public Koszyk(Klient wlasciciel, int id)
        {
            idKoszyka = id;
            this.wlasciciel = wlasciciel;
            Produkty = new Dictionary<Produkt, int>();
            wartosc = 0.0;
        }

        public void DodajProdukt(Produkt p, int ile=1)
        {
            if (Magazyn.IleDostepnych(p) >= ile)
            {
                Produkty.Add(p, ile);
                wartosc += p.Cena * ile;
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
                wartosc -= p.Cena * Produkty[p];
                Produkty.Remove(p);
            }
            else
            {
                Produkty[p] -= ile;
                wartosc -= p.Cena * ile;
            }
        }

        public void Oproznij()
        {
            Produkty.Clear();
        }

        public Zamowienie ZlozZamowienie(SpsobDostawy dostawa)
        {
            Zamowienie z = new Zamowienie(idKoszyka, wlasciciel, this, dostawa);
            Platnosci.DodajZamowienie(z);
            Zamowienie = z;
            return z;
        }

        public double Wartosc()
        {
            return wartosc;
        }

        public string TextToPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Koszyk:\n");
            foreach (var produkt in Produkty)
            {
                sb.Append(produkt.Key.TextToPrint() + " x" + produkt.Value + "szt. = " + produkt.Key.Cena * produkt.Value + "\n");
            }
            sb.Append("Razem " + Wartosc().ToString() + "zł\n");

            return sb.ToString();
        }
    }
}
