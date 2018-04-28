using P04SimuladorElevador.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04SimuladorElevador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = null;
        public Edificio Edificio { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Edificio = new Edificio(3, 8);
            this.DataContext = Edificio;
            Edificio.ActualizarPersonasEsperando(); 

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();            
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Edificio.Simular();

            SimulacionText.Text = Edificio.PersonasEsperando.Count.ToString();
            if (Edificio.PersonasEsperando.Count == 0 && Edificio.Elevador.Personas.Count == 0)
            {
                timer.Stop();
                SimulacionText.Text = "Simulación terminada...";
            }

            AnimarElevador();
        }

        private void AnimarElevador()
        {
            double inicio = Edificio.Elevador.PisoActual == 1 ? 444 : Edificio.Elevador.PisoActual == 2 ? 254 : 64;
            double destino = inicio;

            Canvas.SetTop(Elevador, destino);            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(Elevador, 444);

            Edificio = new Edificio(3, 8);
            this.DataContext = Edificio;
            Edificio.ActualizarPersonasEsperando();

            timer.Start();
        }
    }
}
