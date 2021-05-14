using System;
using System.IO;
namespace CardioFitConsole
{
    class Program
    {
        public static readonly string DIRECTORY = Directory.GetCurrentDirectory();
        public const string FILE = "dati_battiti_cardiaci_in_un_giorno.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto in CardioFit");
            Console.WriteLine("Scegli quale funzione vuoi eseguire \n'Training bpm'--'Consumo Calorie'--'Calorie Uomo'--'Calorie Donne'--'Situazione Cardiaca'--'DailyBpm'--'RestBpm'--'VariabilityBpm'");
            string scelta = Console.ReadLine();
            string continuo = "1";
            while (continuo != "1")
            {
                switch (scelta)
                {
                    case "Training bpm":
                        break;

                    case "Consumo Calorie":
                        break;

                    case "Calorie Uomo":
                        break;

                    case "Calorie Donna":
                        break;

                    case "Situazione Cardiaca":
                        break;

                    case "DailyBpm":
                        break;

                    case "RestBpm":
                        break;

                    case "VariabilityBpm":
                        break;

                    default:
                        Console.WriteLine("FUNZIONE INESISTENTE!");
                        break;
                }
                Console.WriteLine("Per continuare e usare un'altra funzione digitare '1'. \nPer stoppare la console digitare qualsiasi tasto(!=1).");
                continuo = Console.ReadLine();
            }
        }
    }
}
