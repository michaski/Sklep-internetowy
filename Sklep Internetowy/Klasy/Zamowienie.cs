using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Zamowienie : IPrintable
    {
        private Klient klient;
        private Pracownik pracownik;
        private Koszyk koszyk;
        private SpsobDostawy dostawa;

        public void Zrealizuj()
        {
            foreach(var produkt in koszyk.Produkty)
            {
                Magazyn.WydajProdukt(produkt.Key, produkt.Value);
            }
        }

        public string Podsumowanie()
        {
            throw new NotImplementedException();
        }

        public string TextToPrint()
        {
            throw new NotImplementedException();
        }
    }
}
