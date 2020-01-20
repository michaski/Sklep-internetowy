using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Produkt
    {
        #region Właściwości
        public string Nazwa { get; private set; }
        public string Kategoria { get; private set; }
        public int Cena { get; private set; }
        #endregion

        public Produkt(string nazwa, int cena, string kategoria = "Inne")
        {
            this.Nazwa = nazwa;
            this.Kategoria = kategoria;
            this.Cena = cena;
        }
    }
}
