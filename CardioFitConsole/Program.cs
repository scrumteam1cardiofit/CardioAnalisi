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
            Console.WriteLine("Digita '1' per continuare o '0' per chiudere la Console: ");
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
                            if (eta > 0 && eta < 140)
                                Console.WriteLine(DataCardio.RangeBpmTraining(eta));
                            else
                                Console.WriteLine("Eta non valida!");
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
                            if (km >= 0 && peso > 15)
                                Console.WriteLine(DataCardio.CalorieConsumateCorsaCamminata(km, peso));
                            else
                                Console.WriteLine("Valori inseriti non validi!");
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
                            Console.WriteLine("Inserisci la tua eta(y): ");
                            int eta_calorie_uomo = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tempo di allenamento (minuti): ");
                            int tempo_uomo = int.Parse(Console.ReadLine());
                            if (frequenza_cardiaca_uomo > 0 && peso_uomo > 15 && eta_calorie_uomo > 0 && tempo_uomo > 0)
                                Console.WriteLine($"Hai bruciato: {DataCardio.CalorieBruciateUomo(frequenza_cardiaca_uomo, peso_uomo, eta_calorie_uomo, tempo_uomo)} calorie!");
                            else
                                Console.WriteLine("Valori inseriti non validi!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "calorie donna":
                        try
                        {
                            Console.WriteLine("Inserisci la tua frequenza cardiaca(bpm): ");
                            int frequenza_cardiaca_donna = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tuo peso(kg): ");
                            float peso_donna = float.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci la tua eta(y): ");
                            int eta_calorie_donna = int.Parse(Console.ReadLine());
                            Console.WriteLine("Inserisci il tempo di allenamento(minuti): ");
                            int tempo_donna = int.Parse(Console.ReadLine());
                            if (frequenza_cardiaca_donna > 0 && peso_donna > 15 && eta_calorie_donna > 0 && tempo_donna > 0)
                                Console.WriteLine($"Hai bruciato: {DataCardio.CalorieBruciateDonna(frequenza_cardiaca_donna, peso_donna, eta_calorie_donna, tempo_donna)} calorie!");
                            else
                                Console.WriteLine("Valori inseriti non validi!");
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
                            Console.WriteLine(DataCardio.SituazioneCardiaca(frequenza_cardiaca));
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
                            Console.WriteLine($"La variabilità dei tuoi battiti è: {battiti[battiti.Count - 1] - battiti[0]}");
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
                Console.WriteLine("Digita '1' per usare un'altra funzione o '0' per chiudere la Console: ");
                continua = Console.ReadLine();
            }
        }
    }
}
