using System;

namespace Lecture06._1_Tankas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("|Sveiki atvyke i Tanku zaidima!|");
            Console.WriteLine("--------------------------------");

            var tankas = new Tankas(10, 100);
            var salyga = true;

            while (salyga)
            {
                Console.Write("\nPasirinkite ejima: \n" +
                    "1 - judeti pirmyn; \n" +
                    "2 - judeti atgal; \n" +
                    "3 - judeti kairen; \n" +
                    "4 - judeti desinen; \n" +
                    "5 - suvis; \n" +
                    "6 - pateikti statistika; \n" +
                    "0 - nutraukti zaidima. \n\n");

                Console.Write("Jusu ejimas: ");
                var ejimas = Convert.ToInt32(Console.ReadLine());

                switch (ejimas)
                {
                    case 1:
                        tankas.Pirmyn();
                        break;
                    case 2:
                        tankas.Atgal();
                        break;
                    case 3:
                        Console.WriteLine($"Tankas pasuka i kaire.");
                        tankas.Kairen();
                        break;
                    case 4:
                        Console.WriteLine($"Tankas pasuka i desine.");
                        tankas.Desinen();
                        break;
                    case 5:
                        tankas.Suvis();
                        break;
                    case 6:
                        Console.WriteLine($"Zaidimo statistika");
                        tankas.Info();
                        break;
                    case 0:
                        salyga = false;
                        break;
                    default:
                        Console.WriteLine("Nera tokio ejimo! Bandykite dar karta!");
                        break;
                }
                //salyga = tankas.EjimuSk <= Apribojimai.MaxEjimuSk ? true : false;
            }

            //Console.WriteLine();

            //tankas.Info();

            //Console.WriteLine();

            //Console.WriteLine("--------------------------------");
            //Console.WriteLine("|GAME OVER!|");
            //Console.WriteLine("--------------------------------");
        }
    }
}
