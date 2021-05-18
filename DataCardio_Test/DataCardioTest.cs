using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using CardioLibrary;

namespace DataCardio_Test
{
    [TestClass]
    public class DataCardioTest
    {
        [TestMethod]
        public void RangeBpmTraining_Test1()
        {
            int eta = 55;
            string resp = DataCardio.RangeBpmTraining(eta);
            string valore_aspettato = "La tua frequenza cardiaca in un buon allenamento deve essere compresa tra 115.5 e 148.5.";
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void RangeBpmTraining_Test2()
        {
            int eta = 0;
            string resp = DataCardio.RangeBpmTraining(eta);
            string valore_aspettato = "La tua frequenza cardiaca in un buon allenamento deve essere compresa tra 154 e 198.";
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SpesaEnergeticaCorsaCamminata_Test1()
        {
            double km = 10;
            double peso = 55;
            string valore_aspettato = "In corsa consumi: 495 KCal, In camminata consumi: 275 KCal.";
            string resp = DataCardio.CalorieConsumateCorsaCamminata(km, peso);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SpesaEnergeticaCorsaCamminata_Test2()
        {
            double km = 5;
            double peso = 68;
            string valore_aspettato = "In corsa consumi: 306 KCal, In camminata consumi: 170 KCal.";
            string resp = DataCardio.CalorieConsumateCorsaCamminata(km, peso);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SpesaEnergeticaCorsaCamminata_Test3()
        {
            double km = -20;
            double peso = 75;
            string valore_aspettato = "In corsa consumi: -1350 KCal, In camminata consumi: -750 KCal.";
            string resp = DataCardio.CalorieConsumateCorsaCamminata(km, peso);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void CalorieUomo_Test1()
        {
            int f = 70;
            float p = 90;
            uint eta = 20;
            float t = 60;
            float risp = DataCardio.CalorieBruciateUomo(f, p, eta, t);
            float valore_aspettato = (float)157.8886233269598;
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void CalorieDonna_Test1()
        {
            int f = 75;
            float p = 65;
            uint eta = 30;
            float t = 60;
            float risp = DataCardio.CalorieBruciateUomo(f, p, eta, t);
            float valore_aspettato = (float)160.7065;
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void SituazioneCardiaca_Test1()
        {
            int frequenza = 0;
            string valore_aspettato = "valore inserito non valido!!";
            string resp = DataCardio.SituazioneCardiaca(frequenza);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SituazioneCardiaca_Test2()
        {
            int frequenza = 20;
            string valore_aspettato = "Bradicardia";
            string resp = DataCardio.SituazioneCardiaca(frequenza);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SituazioneCardiaca_Test3()
        {
            int frequenza = 180;
            string valore_aspettato = "Tachicardia";
            string resp = DataCardio.SituazioneCardiaca(frequenza);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void MediaDailyBpm_Test1()
        {
            int somma = 4000, c_battiti = 50;
            float valore_aspettato = 80;
            float risp = DataCardio.MediaDailyBpm(somma, c_battiti);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void MediaDailyBpm_Test2()
        {
            int somma = -6000, c_battiti = 10;
            float valore_aspettato = -600;
            float risp = DataCardio.MediaDailyBpm(somma, c_battiti);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void MediaDailyBpm_Test3()
        {
            int somma = 0, c_battiti = 10;
            float valore_aspettato = 0;
            float risp = DataCardio.MediaDailyBpm(somma, c_battiti);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void RestBpm_Test1()
        {
            float media = 400;
            bool valore_aspettato = false;
            bool risp = DataCardio.RestBpm(media);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void RestBpm_Test2()
        {
            float media = 90;
            bool valore_aspettato = true;
            bool risp = DataCardio.RestBpm(media);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void RestBpm_Test3()
        {
            float media = -90;
            bool valore_aspettato = false;
            bool risp = DataCardio.RestBpm(media);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void Variabilita_Test1()
        {
            int min = 60, max = 110;
            int valore_aspettato = 50;
            int risp = DataCardio.Variabilita(min, max);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void Variabilita_Test2()
        {
            int min = -60, max = -110;
            int valore_aspettato = -50;
            int risp = DataCardio.Variabilita(min, max);
            Assert.AreEqual(valore_aspettato, risp);
        }
        [TestMethod]
        public void Variabilita_Test3()
        {
            int min = 0, max = 200;
            int valore_aspettato = 200;
            int risp = DataCardio.Variabilita(min, max);
            Assert.AreEqual(valore_aspettato, risp);
        }
    }
}
