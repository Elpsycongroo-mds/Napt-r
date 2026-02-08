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





        }
    }
}
