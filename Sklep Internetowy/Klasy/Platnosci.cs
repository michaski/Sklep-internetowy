using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    static class Platnosci
    {
        private static Dictionary<Zamowienie, bool> listaZamowien;  // false - nie opłacone, true - opłacone

        public static void DodajZamowienie(Zamowienie z)
        {
            listaZamowien.Add(z, false);
        }

        public static void ZaplaconoZamowienie(Zamowienie z)
        {
            z.Zrealizuj();
            listaZamowien.Remove(z);
        }

        public static bool CzyZaplacono(Zamowienie z)
        {
            return listaZamowien[z];
        }
    }
}
