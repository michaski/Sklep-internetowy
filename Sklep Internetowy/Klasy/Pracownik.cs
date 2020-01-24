using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Pracownik : Osoba
    {
        private string dzial;
        public Pracownik(int id, string imie, string nazwisko, string dzial)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dzial = dzial;
        }

        public void DodajNowyProdukt(string nazwa, double cena)
        {
            Produkt p = new Produkt(nazwa, cena, dzial);
            Magazyn.DodajProdukt(p, 100);
        }

        public void UzupelnijTowar(Produkt p)
        {
            Magazyn.DodajProdukt(p, 100);
        }

        public override string TextToPrint()
        {
            return String.Format($"Pracownik {imie} {nazwisko} (nr pracownika {id})");
        }
    }
}
