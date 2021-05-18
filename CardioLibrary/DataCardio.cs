using System;
using System.IO;
using System.Collections.Generic;
namespace CardioLibrary
{

    public class DataCardio
    {
        public static string RangeBpmTraining(int eta)
        {
            float frequenza_max = 220 - eta;
            float frequenza_70_perc = (frequenza_max * 70) / 100;
            float frequenza_90_perc = (frequenza_max * 90) / 100;
            return $"La tua frequenza cardiaca in un buon allenamento deve essere compresa tra {frequenza_70_perc} e {frequenza_90_perc}.";
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
        public static float MediaDailyBpm(int somma, int c_battiti)
        {
            return somma / c_battiti;
        }
        public static bool RestBpm(float media)
        {
            if (media >= 60 && media <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int Variabilita(int min, int max)
        {
            return max - min;
        }
    }
}

