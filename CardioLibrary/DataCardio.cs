using System;
using System.IO;
using System.Collections.Generic;
namespace CardioLibrary
{

    public class DataCardio
    {
        public static string BattitiMinimiMassimiinTraining(int eta)
        {
            float freq_max_normale = 220 - eta;
            float minimo_perc = 70;
            float max_perc = 90;
            float freq_min_allenamento = (float)(minimo_perc / freq_max_normale) * 100;
            float freq_max_allenamento = (float)(max_perc / freq_max_normale) * 100;
            return $"La tua frequenza cardiaca in un buon allenamento deve essere compresa tra {freq_min_allenamento} e {freq_max_allenamento}.";
        }
        public static string CalorieConsumateCorsaCamminata(double km, double peso)
        {
            double corsa = 0.9 * km * peso;
            double camminata = 0.50 * km * peso;
            return $"In corsa consumi: {corsa} KCal, In camminata consumi: {camminata} KCal.";
        }
        public static float CalorieBruciateUomo(int f, float p, uint eta, float t)
        {
            return (float)(((eta * 0.2017) + (p * 0.199) + (f * 0.6309) - 55.0969) * t / 4.184);
        }
        public static float CalorieBruciateDonna(int f, float p, uint eta, float t)
        {
            return (float)(((eta * 0.074) + (p * 0.126) + (f * 0.4472) - 20.4022) * t / 4.184);
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
        public static int MediaDailyBpm(string file)
        {
            List<int> battiti = new List<int>();
            int c_battiti = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    battiti.Add(int.Parse(line));
                    c_battiti++;
                }
            }
            int somma = 0;
            for (int i = 0; i < battiti.Count; i++)
            {
                somma += battiti[i];
            }
            return somma / c_battiti;
        }
        public static bool RestBpm(string file)
        {
            int media = MediaDailyBpm(file);
            if(media >= 60 && media <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

