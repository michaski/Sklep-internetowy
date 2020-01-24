using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep_Internetowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Sklep sklep = new Sklep("Sklep-ze-wszyskim");
            Klient klient = sklep.DodajKlienta("Jan", "Kowalski");
            Pracownik p1 = sklep.DodajPracownika("Adam", "Jankowski", "Elektronika"),
                      p2 = sklep.DodajPracownika("Tomasz", "Adamczyk", "Sport"),
                      p3 = sklep.DodajPracownika("Filip", "Malinowski", "Książki");

            sklep.Kategorie.Add("Elektronika");
            sklep.Kategorie.Add("Sport");
            sklep.Kategorie.Add("Książki");
            p1.DodajNowyProdukt("Smartfon", 3500);
            p1.DodajNowyProdukt("Laptop", 4000);
            p2.DodajNowyProdukt("Piłka", 150);
            p2.DodajNowyProdukt("Buty", 300);
            p3.DodajNowyProdukt("Książka kucharska", 99.99);
            p3.DodajNowyProdukt("Wiedźmin", 44.99);

            int wyborMenu = -1;
            while(true)
            {
                wyborMenu = Menu(sklep);
                if (wyborMenu == 0)
                    return;

                if (wyborMenu == sklep.Kategorie.Count + 1)
                {
                    try
                    {
                        klient.Kup();
                    }
                    catch(BrakProduktuNaMagazynieException e)
                    {
                        
                    }
                    klient.Zaplac();
                }
                else if (wyborMenu == sklep.Kategorie.Count + 2)
                {
                    Console.WriteLine(klient.ZawartoscKoszyka());
                }
                else
                {
                    var zakup = sklep.ProduktZKategorii(sklep.Kategorie[wyborMenu - 1]);
                    if (zakup != null)
                    {
                        try
                        {
                            klient.DodajDoKoszyka(zakup.First, zakup.Second);
                        }
                        catch (BrakProduktuNaMagazynieException e)
                        {
                            Console.WriteLine(e.Message);
                            continue;
                        }
                        Console.WriteLine("Dodano do koszyka");
                    }
                }
            }
        }

        static int Menu(Sklep sklep)
        {
            int wybor = -1;
            Console.WriteLine("Witamy w sklepie internetowym " + sklep.Nazwa);
            while (wybor < 0 || wybor > sklep.Kategorie.Count+2)
            {
                Console.WriteLine("Wybierz kategorię produktów: ");
                int i = 0;
                foreach (string kategoria in sklep.Kategorie)
                {
                    Console.WriteLine($"{++i}. {kategoria}");
                }
                Console.WriteLine($"{++i}. Przejdz do zakupu");
                Console.WriteLine($"{++i}. Wyświetl koszyk");
                Console.WriteLine("0. Wyjście");
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Źle wprowadzono liczbe");
                }
            }

            return wybor;
        }
    }
}
