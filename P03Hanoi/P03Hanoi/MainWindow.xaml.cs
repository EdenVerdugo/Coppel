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
using System.Windows.Threading;

namespace P03Hanoi
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// Autor : Eden Rodrigo Verdugo Garcia
    /// Fecha : 2018/04/24
    /// Descripcion: Interfaz para resolver las torres de hanoi de acuerdo al numero de discos dados, basado en el algoritmo encontrado en http://interactivepython.org/runestone/static/pythoned/Recursion/LasTorresDeHanoi.html

    public partial class MainWindow : Window
    {
        List<Rectangle> lst = null;

        public MainWindow()
        {
            InitializeComponent();

            int numDiscos = 3;
            DiscosText.Text = numDiscos.ToString();

            InicializarButton_Click(null, null);                        
        }         

        private void InicializarDiscos(int numDiscos)
        {            
            lst = new List<Rectangle>();
            Torre1.Children.Clear();
            Torre2.Children.Clear();
            Torre3.Children.Clear();

            Random rnd = new Random();

            for (int i=0; i<numDiscos; i++)
            {   
                Rectangle r = new Rectangle();
                r.Width = 25 + (Torre1.Children.Count * 10);
                r.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                r.Height = 20;
                r.Margin = new Thickness(10, 3, 10, 3);
                
                Torre1.Children.Add(r);
                lst.Add(r);
            }            
        }
        
        private static Action EmptyDelegate = delegate () { };

        private async Task HanoiUI(int altura, StackPanel origen, StackPanel destino, StackPanel auxiliar)
        {
            if (altura >= 1)
            {                
                await HanoiUI(altura - 1, origen, auxiliar, destino);
                //mover disco origen, destino
                var torre = origen.Children[0];

                origen.Children.RemoveAt(0);
                destino.Children.Insert(0, torre);

                this.NumMovimientoText.Text = (Convert.ToInt32(this.NumMovimientoText.Text) + 1).ToString();

                //System.Threading.Thread.Sleep(300);
                await Task.Delay(300);

                Window.Dispatcher.Invoke(DispatcherPriority.ContextIdle, EmptyDelegate);
                
                await HanoiUI(altura - 1, auxiliar, destino, origen);       
                
                if(altura == 1)
                {
                    //System.Threading.Thread.Sleep(300);
                    await Task.Delay(300);
                }
            }
        }

        private void Hanoi(int altura, string origen, string destino, string auxiliar, ref int numMov)
        {
            if(altura >= 1)
            {
                Hanoi(altura - 1, origen, auxiliar, destino, ref numMov);

                numMov += 1;
                
                Hanoi(altura - 1, auxiliar, destino, origen, ref numMov);
                                
            }
        }

        private void ResolverButton_Click(object sender, RoutedEventArgs e)
        {
            this.InicializarButton_Click(sender, e);

            HanoiUI(lst.Count, Torre1, Torre3, Torre2);
        }

        private void InicializarButton_Click(object sender, RoutedEventArgs e)
        {
            this.NumMovimientoText.Text = "0";
            int discos = 0;

            if (int.TryParse(DiscosText.Text, out discos))
            {
                this.InicializarDiscos(discos);

                int mov = 0;
                Hanoi(discos, "O", "D", "A", ref mov);

                MovimientosText.Text = mov.ToString();
            }
        }
    }
}
