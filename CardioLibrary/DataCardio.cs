using System;
using System.IO;
using System.Collections.Generic;
namespace CardioLibrary
{

    public class DataCardio
    {
        public static readonly string DIRECTORY = Directory.GetCurrentDirectory();
        public const string FILE = @"\dati_battiti_cardiaci_in_un_giorno.txt";

        public static string BattitiMinimiMassimiinTraining(int eta)
        {
            int freq_max_normale = 220 - eta;
            int minimo_perc = 70;
            int max_perc = 90;
            float freq_min_allenamento = (float)(minimo_perc / freq_max_normale) * 100;
            float freq_max_allenamento = (max_perc / freq_max_normale) * 100;
            return $"La tua frequenza cardiaca in un buon allenamento deve essere compresa tra {freq_min_allenamento} e {freq_max_allenamento}.";
        }
        public static string CalorieConsumateCorsaCamminata(double km, double peso)
        {
            double corsa = 0.9 * km * peso;
            double camminata = 0.50 * km * peso;
            string risultato = $"In corsa consumi: {corsa} KCal, In camminata consumi: {camminata} KCal.";
            return risultato;
        }
        public static float CalorieBruciateUomo(int f, float p, uint eta, float t)
        {
            float caloriebruciate = (float)((eta * 0.2017) + (p * 0.199) + (f * 0.6309) - 55.0969);
            return caloriebruciate;
        }
        public static float CalorieBruciateDonna(int f, float p, uint eta, float t)
        {
            float caloriebruciate = (float)((eta * 0.074) + (p * 0.126) + (f * 0.4472) - 20.4022);
            return caloriebruciate;
        }
        public static string SituazioneCardiaca(int frequenza)
        {
            if (frequenza < 5)
            {
                return "valore inserito non valido!!";
            }
            else if (frequenza < 60 && frequenza >= 5)
            {
                return "Bradicardia";
            }
            else if (frequenza >= 60 && frequenza <= 100)
            {
                return "Normale";
            }
            else
            {
                return "Tachicardia";
            }
        }
    }
}

