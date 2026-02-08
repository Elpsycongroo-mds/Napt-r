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

            static void NaptarMegjelenites()
            {
                Console.WriteLine("\n--- ESEMÉNYEK LISTÁJA ---");
                Console.WriteLine("(Jelmagyarázat: [M] = Mentett/Saját, [G] = Generált/Ideiglenes)\n");

                foreach (Esemeny e in esemenyLista)
                {
                    string jelolo = e.MenteniKell ? "[M]" : "[G]";
                    Console.WriteLine("{0} {1} - {2}: {3} perc",
                        jelolo, e.Idopont.ToString("yyyy.MM.dd HH:mm"), e.Tulajdonos, e.Idotartam);
                }
                Console.WriteLine("\nNyomj egy gombot...");
                Console.ReadKey();
            }

            static void UjEsemenyRogzitese()
            {
                Console.WriteLine("\n--- ÚJ ESEMÉNY ---");
                Esemeny uj = new Esemeny();

                Console.Write("Kié az esemény (Apa/Anya)? ");
                uj.Tulajdonos = Console.ReadLine();

                int nap = 0;
                bool sikeresNap = false;
                do
                {
                    Console.Write("Nap (1-29): ");
                    string bemenet = Console.ReadLine();
                    bool sikerult = int.TryParse(bemenet, out nap);

                    if (sikerult && nap >= 1 && nap <= 29)
                    {
                        sikeresNap = true;
                    }
                    else
                    {
                        Console.WriteLine("Hiba! Vagy nem számot írtál, vagy nincs 1 és 29 között.");
                    }
                } while (!sikeresNap);

                int ora = 0;
                bool sikeresOra = false;
                do
                {
                    Console.Write("Óra (8-20): ");
                    string bemenet = Console.ReadLine();
                    bool sikerult = int.TryParse(bemenet, out ora);

                    if (sikerult && ora >= 8 && ora <= 20)
                    {
                        sikeresOra = true;
                    }
                    else
                    {
                        Console.WriteLine("Hiba! 8 és 20 közötti számot adj meg.");
                    }
                } while (!sikeresOra);

                int perc = 0;
                bool sikeresPerc = false;
                do
                {
                    Console.Write("Perc (0-59): ");
                    string bemenet = Console.ReadLine();
                    bool sikerult = int.TryParse(bemenet, out perc);

                    if (sikerult && perc >= 0 && perc < 60)
                    {
                        sikeresPerc = true;
                    }
                    else
                    {
                        Console.WriteLine("Hiba! 0 és 59 közötti számot adj meg.");
                    }
                } while (!sikeresPerc);

                uj.Idopont = new DateTime(2028, 2, nap, ora, perc, 0);

                // időtartama
                int idotartam = 0;
                bool sikeresIdo = false;
                do
                {
                    Console.Write("Időtartam (perc): ");
                    string bemenet = Console.ReadLine();
                    bool sikerult = int.TryParse(bemenet, out idotartam);

                    if (sikerult && idotartam > 0)
                    {
                        sikeresIdo = true;
                    }
                    else
                    {
                        Console.WriteLine("Hiba! Pozitív számot adj meg.");
                    }
                } while (!sikeresIdo);

                uj.Idotartam = idotartam;
                uj.MenteniKell = true;

                esemenyLista.Add(uj);
                Console.WriteLine("Rögzítve! Ez az esemény kilépéskor el lesz mentve.");

            }

            static void LegkozelebbiEsemeny()
            {
                int vNap = veletlen.Next(1, 30);
                int vOra = veletlen.Next(8, 20);
                DateTime most = new DateTime(2028, 2, vNap, vOra, 0, 0);

                Console.WriteLine("\nGenerált viszonyítási időpont: " + most.ToString());

                Esemeny legkozelebbi = null;

                foreach (Esemeny e in esemenyLista)
                {
                    // Ha az esemény a jövőben van (nagyobb mint a most)
                    if (e.Idopont > most)
                    {
                        // Ha még nincs találatunk VAGY ez az esemény korábbi mint az eddigi legjobb
                        if (legkozelebbi == null || e.Idopont < legkozelebbi.Idopont)
                        {
                            legkozelebbi = e;
                        }
                    }
                }

                if (legkozelebbi != null)
                {
                    Console.WriteLine("A legközelebbi esemény: {0} - {1}",
                        legkozelebbi.Tulajdonos, legkozelebbi.Idopont);
                }
                else
                {
                    Console.WriteLine("Nincs későbbi esemény ebben a hónapban.");
                }
            }








        }
    }
}
