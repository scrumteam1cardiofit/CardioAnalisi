using System;
using System.IO;
using System.Collections.Generic;
using CardioLibrary;
namespace CardioFitConsole
{
    class Program
    {
        public static readonly string DIRECTORY = Directory.GetCurrentDirectory();
        public const string FILE = "dati_battiti_cardiaci_in_un_giorno.txt";
        static void Main(string[] args)
        {
            int i = 0;
            Random r = new Random();
            int n;
            using (StreamWriter sw_battiti = new StreamWriter(FILE))
            {
                while (i < 24)
                {
                    sw_battiti.WriteLine(n = r.Next(30, 170));
                    i++;
                }
                sw_battiti.Flush();
            }
            List<int> battiti = new List<int>();
            using (StreamReader sr_battiti = new StreamReader(FILE))
            {
                string line;
                while ((line = sr_battiti.ReadLine()) != null)
                {
                    battiti.Add(int.Parse(line));
                }
            }
            Console.WriteLine("Benvenuto in CardioFit!");
            Console.WriteLine("Scegli quale funzione vuoi eseguire \n'Training bpm'--'Consumo Calorie'--'Calorie Uomo'--'Calorie Donne'--'Situazione Cardiaca'--'DailyBpm'--'RestBpm'--'VariabilityBpm'");
            string scelta;
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "Training bpm":
                    Console.WriteLine("Digitare la tua eta: ");
                    int eta = int.Parse(Console.ReadLine());
                    Console.WriteLine(DataCardio.BattitiMinimiMassimiinTraining(eta));
                    break;

                case "Consumo Calorie":
                    Console.WriteLine("Inserisci chilometri percorsi: ");
                    double km = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il tuo peso(kg): ");
                    double peso = double.Parse(Console.ReadLine());
                    Console.WriteLine(DataCardio.CalorieConsumateCorsaCamminata(km, peso));
                    break;

                case "Calorie Uomo":
                    Console.WriteLine("Inserisci la tua frequenza cardiaca(bpm): ");
                    int frequenza_cardiaca_uomo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il tuo peso(kg): ");
                    float peso_uomo = float.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la tua eta: ");
                    uint eta_calorie_uomo = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il tempo di allenamento (minuti): ");
                    int tempo_uomo = int.Parse(Console.ReadLine());
                    break;

                case "Calorie Donna":
                    Console.WriteLine("Inserisci la tua frequenza cardiaca: ");
                    int frequenza_cardiaca_donna = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il tuo peso: ");
                    float peso_donna = float.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la tua eta: ");
                    uint eta_calorie_donna = uint.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il tempo di allenamento in minuti: ");
                    int tempo_donna = int.Parse(Console.ReadLine());
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
        }
    }
}
