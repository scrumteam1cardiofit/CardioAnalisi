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
            try
            {
                int freq_max_normale = 220 - eta;
                int minimo_perc = 70;
                int max_perc = 90;
                float freq_min_allenamento = (float)(minimo_perc / freq_max_normale) * 100;
                //freq_min_allenamento = (float)Math.Round(freq_min_allenamento, 2);
                float freq_max_allenamento = (max_perc / freq_max_normale) * 100;
                return $"La tua frequenza cardiaca in un buon allenamento deve essere compresa tra {freq_min_allenamento} e {freq_max_allenamento}.";
            }
            catch (Exception)
            {
                return "Inserire dati validi.";
            }
        }
        public static string CalorieConsumateCorsaCamminata(double km, double peso)
        {
            double corsa = 0.9 * km * peso;
            double camminata = 0.50 * km * peso;
            string risultato = $"In corsa consumi: {corsa} KCal, In camminata consumi: {camminata} KCal.";
            return risultato;
        }

        public static string SituazioneCardiaca(int frequenza)
        {
            if (frequenza < 5)
            {
                return "valore inserito non valido!!";
            }
            if (frequenza < 60 && frequenza >= 5)
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

