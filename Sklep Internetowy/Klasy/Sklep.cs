using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Sklep
    {
        private List<Pracownik> pracownicy;
        private List<Klient> klienci;
        private string nazwa;

        public Sklep(string nazwa)
        {
            this.nazwa = nazwa;
        }

        public void DodajPracownika(Pracownik p)
        {
            pracownicy.Add(p);
        }

        public string ListaProduktowTxt()
        {
            var produkty = Magazyn.WszystkieProdukty();
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Wszystkie produkty (nazwa - cena - dostepna ilość):");
            int i = 0;
            foreach(var produkt in produkty)
            {
                sb.Append(String.Format($"{++i}. {produkt.Key} - {produkt.Key.Cena} - {produkt.Value}"));
            }

            return sb.ToString();
        }

        public Pair<Produkt, int> ProduktZKategorii(string kategoria)
        {
            var produkty = Magazyn.WszystkieProdukty();
            var listaProduktow = new List<Produkt>();
            Console.WriteLine($"Kategoria {kategoria} (nazwa - cena - dostepna ilość):");
            int i = 0;
            foreach (var produkt in produkty)
            {
                if (produkt.Key.Kategoria == kategoria)
                {
                    Console.WriteLine(String.Format($"{++i}. {produkt.Key} - {produkt.Key.Cena} - {produkt.Value}"));
                    listaProduktow.Add(produkt.Key);
                }
            }

            char odp = '0';
            while (Char.ToLower(odp) == 't' || Char.ToLower(odp) == 'n')
            {
                Console.WriteLine("Czy chcesz coś kupić? (t/n)");
                odp = Console.ReadLine()[0];
            }
            if(Char.ToLower(odp) == 'n')
            {
                return null;
            }
            int wybor = 0, ile = 0;
            while(wybor < 1 || wybor > listaProduktow.Count)
            {
                Console.Write("Podaj nr produktu: ");
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Podano zły numer");
                }
            }
            while (ile < 1)
            {
                Console.Write("Podaj ilosc: ");
                try
                {
                    ile = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("To nie jest poprawna wartość");
                }
            }

            return new Pair<Produkt, int>(listaProduktow[wybor-1], ile);
        }
    }
}
