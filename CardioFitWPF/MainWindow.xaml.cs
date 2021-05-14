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

namespace CardioFitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBpmTraining_Click(object sender, RoutedEventArgs e)
        {
            BattitiTraining battititraining = new BattitiTraining();
            battititraining.Show();
        }

        private void btnConsumoCalorie_Click(object sender, RoutedEventArgs e)
        {
            ConsumoCalorie consumocalorie = new ConsumoCalorie();
            consumocalorie.Show();
        }

        private void btnSituazioneCardiaca_Click(object sender, RoutedEventArgs e)
        {
            SituazioneCardiaca situazionecardiaca = new SituazioneCardiaca();
            situazionecardiaca.Show();
        }

        private void btnCalorieGenere_Click(object sender, RoutedEventArgs e)
        {
            CalorieGenere caloriegenere = new CalorieGenere();
            caloriegenere.Show();
        }

        private void btnFunzioniSpeciali_Click(object sender, RoutedEventArgs e)
        {
            FunzioniSpeciali funzionispeciali = new FunzioniSpeciali();
            funzionispeciali.Show();
        }
    }
}
