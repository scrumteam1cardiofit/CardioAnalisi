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
            battiti.Sort();
            Console.WriteLine("Benvenuto in CardioFit!");
            Console.WriteLine("Digita 1 per continuare o 0 per chiudere la Console: ");
            string continua = Console.ReadLine();
            while (continua == "1")
            {
                Console.WriteLine("Scegli quale funzione vuoi eseguire: \n'Training bpm'--'Consumo Calorie'--'Calorie Uomo'--'Calorie Donne'--'Situazione Cardiaca'--'MediaBpm'--'RestBpm'--'VariabilityBpm'");
                string scelta = Console.ReadLine().ToLower();
                Console.WriteLine();
                switch (scelta)
                {
                    case "training bpm":
                        try
                        {
                            Console.WriteLine("Digitare la tua eta: ");
                            int eta = int.Parse(Console.ReadLine());
                            Console.WriteLine(DataCardio.RangeBpmTraining(eta));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "consumo calorie":
                        try
                        {
                            Console.WriteLine("Inserisci chilometri percorsi: ");
                            double km = double.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tuo peso(kg): ");
                            double peso = double.Parse(Console.ReadLine());
                            Console.WriteLine(DataCardio.CalorieConsumateCorsaCamminata(km, peso));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "calorie uomo":
                        try
                        {
                            Console.WriteLine("Inserisci la tua frequenza cardiaca(bpm): ");
                            int frequenza_cardiaca_uomo = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tuo peso(kg): ");
                            float peso_uomo = float.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci la tua eta: ");
                            uint eta_calorie_uomo = uint.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tempo di allenamento (minuti): ");
                            int tempo_uomo = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "calorie donna":
                        try
                        {
                            Console.WriteLine("Inserisci la tua frequenza cardiaca: ");
                            int frequenza_cardiaca_donna = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tuo peso: ");
                            float peso_donna = float.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci la tua eta: ");
                            uint eta_calorie_donna = uint.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tempo di allenamento in minuti: ");
                            int tempo_donna = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "situazione cardiaca":
                        try
                        {
                            Console.WriteLine("Inserisci la tua frequenza cardiaca: ");
                            int frequenza_cardiaca = int.Parse(Console.ReadLine());
                            string situazione_cardiaca = DataCardio.SituazioneCardiaca(frequenza_cardiaca);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "mediabpm":
                        try
                        {
                            int somma = 0;
                            int j = 0;
                            for (; j < battiti.Count; j++)
                            {
                                somma += battiti[j];
                            }
                            Console.WriteLine($"La tua media giornaliera è : {somma / j}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case "restbpm":
                        try
                        {
                            int somma = 0;
                            int j = 0;
                            for (; j < battiti.Count; j++)
                            {
                                somma += battiti[j];
                            }
                            float media = somma / j;
                            bool rest = DataCardio.RestBpm(media);
                            if (rest)
                            {
                                Console.WriteLine("Sei in riposo.");
                            }
                            else
                            {
                                Console.WriteLine("Non sei in riposo.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "variabilitybpm":
                        try
                        {
                            Console.WriteLine($"La variabilità dei tuoi battiti è: {battiti[battiti.Count] - battiti[0]}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("FUNZIONE INESISTENTE!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Digita '1' per usare un'altra funzione o 0 per chiudere la Console: ");
                continua = Console.ReadLine();
            }
        }
    }
}
