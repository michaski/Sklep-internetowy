using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Zamowienie : IPrintable
    {
        private int id;
        private Klient klient;
        private Koszyk koszyk;
        private SpsobDostawy dostawa;

        public Zamowienie(int id, Klient klient, Koszyk koszyk, SpsobDostawy dostawa)
        {
            this.klient = klient;
            this.koszyk = koszyk;
            this.id = id;
            this.dostawa = dostawa;
        }

        public void Zrealizuj()
        {
            foreach(var produkt in koszyk.Produkty)
            {
                Magazyn.WydajProdukt(produkt.Key, produkt.Value);
            }
            koszyk.Oproznij();
        }

        public string Podsumowanie()
        {
            return "Podsumowanie\n" + TextToPrint();
        }

        public string TextToPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Zamowienie nr " + id.ToString() + "\n");
            sb.Append(klient.TextToPrint() + "\n");
            sb.Append("Lista produktów:\n");
            foreach(var produkt in koszyk.Produkty)
            {
                sb.Append(produkt.Key.TextToPrint() + " x" + produkt.Value + "szt. = " + produkt.Key.Cena * produkt.Value + "\n");
            }
            sb.Append("Razem " + koszyk.Wartosc().ToString() + "zł\n");
            sb.Append("Sposób dostawy: " + dostawa);

            return sb.ToString();
        }
    }
}
