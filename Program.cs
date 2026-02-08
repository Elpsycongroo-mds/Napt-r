using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Naptár
{
    internal class Program
    {
        static void Main(string[] args)
        {
            class Esemeny
        {
            public string Tulajdonos;
            public DateTime Idopont;
            public int Idotartam;
            public bool MenteniKell;
        }

        class Program
        {
            static List<Esemeny> esemenyLista = new List<Esemeny>();
            static Random veletlen = new Random();
            static string fajlNev = "mentett_naptar.txt";

            static void Main(string[] args)
            {
                FajlbolBetoltes();
                KezdetiFeltoltes();

                string menupont = "";

                do
                {
                    Console.Clear();
                    Console.WriteLine("--- CSaládi Naptár: 2028 Február ---");
                    Console.WriteLine("1. Naptár megjelenítése");
                    Console.WriteLine("2. Új esemény rögzítése");
                    Console.WriteLine("3. Legközelebbi esemény keresése");
                    Console.WriteLine("4. Kilépés és mentés");
                    Console.Write("\nVálassz menüpontot: ");

                    menupont = Console.ReadLine();

                    switch (menupont)
                    {
                        case "1": NaptarMegjelenites(); break;
                        case "2": UjEsemenyRogzitese(); break;
                        case "3": LegkozelebbiEsemeny(); break;
                        case "4": FajlbaMentes(); break;
                        default: break;
                    }

                } while (menupont != "4");
            }

            // függvények

            static void KezdetiFeltoltes()
            {
                for (int i = 0; i < 10; i++)
                {
                    Esemeny uj = new Esemeny();
                    uj.Tulajdonos = "Apa";
                    uj.Idopont = new DateTime(2028, 2, veletlen.Next(1, 30), veletlen.Next(8, 20), veletlen.Next(0, 60), 0);
                    uj.Idotartam = veletlen.Next(30, 121);
                    uj.MenteniKell = false;
                    esemenyLista.Add(uj);
                }

                for (int i = 0; i < 10; i++)
                {
                    Esemeny uj = new Esemeny();
                    uj.Tulajdonos = "Anya";
                    uj.Idopont = new DateTime(2028, 2, veletlen.Next(1, 30), veletlen.Next(8, 20), veletlen.Next(0, 60), 0);
                    uj.Idotartam = veletlen.Next(30, 121);
                    uj.MenteniKell = false;
                    esemenyLista.Add(uj);
                }
            }



        }
    }
}
