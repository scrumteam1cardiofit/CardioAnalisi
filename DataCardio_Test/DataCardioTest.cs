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
        public void BattitiMinimiMassimiinTraining_Test()
        {
            int eta = 55;
            string resp = DataCardio.BattitiMinimiMassimiinTraining(eta);
            string valore_aspettato = "La tua frequenza cardiaca in un buon allenamento deve essere compresa tra 42.42 e 54.54.";
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void SpesaEnergeticaCorsaCamminata_Test()
        {
            double km = 10;
            double peso = 55;
            string valore_aspettato = "In corsa consumi: 495 KCal, In camminata consumi: 275 KCal.";
            string resp = DataCardio.CalorieConsumateCorsaCamminata(km, peso);
            Assert.AreEqual(valore_aspettato, resp);
        }
        [TestMethod]
        public void CalorieUomo_Test()
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
        public void CalorieDonna_Test()
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
        public void SituazioneCardiaca_Test()
        {
            int frequenza = 0;
            string valore_aspettato = "valore inserito non valido!!";
            string resp = DataCardio.SituazioneCardiaca(frequenza);
            Assert.AreEqual(valore_aspettato, resp);
        }
    }
}
