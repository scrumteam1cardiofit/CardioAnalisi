using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using CardioLibrary;

namespace CardioFitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly string DIRECTORY = Directory.GetCurrentDirectory();
        public const string FILE = "dati_battiti_cardiaci_in_un_giorno.txt";
        List<string> funzioni = new List<string>() { "Training bpm", "Consumo Calorie", "Calorie Uomo/Donna", "Situazione Cardiaca", "MediaBpm", "RestBpm", "VariabilityBpm" };
        List<int> battiti = DataCardio.LetturaScritturaFILE(DIRECTORY, FILE);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cbxFunzione_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < funzioni.Count; i++)
            {
                cbxFunzione.Items.Add(funzioni[i]);
            }
        }
        private void btnMostra_Click(object sender, RoutedEventArgs e)
        {
            if (cbxFunzione.SelectedIndex != -1)
            {
                try
                {
                    int eta = Math.Abs(int.Parse(txbEta.Text));
                    double km = Math.Abs(double.Parse(txbKm.Text));
                    float peso = Math.Abs(float.Parse(txbPeso.Text));
                    int frequenza_Cardiaca = Math.Abs(int.Parse(txbFrequenzaCardiaca.Text));
                    float tempo_Allenamento = Math.Abs(float.Parse(txbTempoMin.Text));
                    if (cbxFunzione.SelectedIndex == 0)
                    {
                        MessageBox.Show(DataCardio.RangeBpmTraining(eta), "", MessageBoxButton.OK);
                    }
                    else if (cbxFunzione.SelectedIndex == 1)
                    {
                        MessageBox.Show(DataCardio.CalorieConsumateCorsaCamminata(km, peso), "", MessageBoxButton.OK);
                    }
                    else if (cbxFunzione.SelectedIndex == 2)
                    {
                        float calorie_Uomo = DataCardio.CalorieBruciateUomo(frequenza_Cardiaca, peso, eta, tempo_Allenamento);
                        float calorie_Donna = DataCardio.CalorieBruciateDonna(frequenza_Cardiaca, peso, eta, tempo_Allenamento);
                        MessageBox.Show($"Se sei uomo hai bruciato: {calorie_Uomo} Calorie, se sei donna hai bruciato: {calorie_Donna} Calorie", "", MessageBoxButton.OK);
                    }
                    else if (cbxFunzione.SelectedIndex == 3)
                    {
                        string situazione_cardiaca = DataCardio.SituazioneCardiaca(frequenza_Cardiaca);
                        MessageBox.Show($"La tua situazione cardiaca è: {situazione_cardiaca}", "", MessageBoxButton.OK);
                    }
                    else if (cbxFunzione.SelectedIndex == 4)
                    {
                        int somma = 0;
                        int j = 0;
                        for (; j < battiti.Count; j++)
                        {
                            somma += battiti[j];
                        }
                        MessageBox.Show($"La tua media giornaliera è : {somma / j}.");
                    }
                    else if (cbxFunzione.SelectedIndex == 5)
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
                            MessageBox.Show("Sei in riposo.", "", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Non sei in riposo.", "", MessageBoxButton.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"La variabilità dei tuoi battiti è: {battiti[battiti.Count - 1] - battiti[0]}", "", MessageBoxButton.OK);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Valore inserito non valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Selezionare una funzione", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnGeneraFrequenza_Click(object sender, RoutedEventArgs e)
        {
            int somma = 0, j = 0;
            for (; j < battiti.Count; j++)
            {
                somma += battiti[j];
            }
            float media = somma / j;
            txbFrequenzaCardiaca.Text = $"{media}";
        }
    }
}
