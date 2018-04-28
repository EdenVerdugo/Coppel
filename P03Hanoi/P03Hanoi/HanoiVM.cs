using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P03Hanoi
{

    public class HanoiVM : System.ComponentModel.INotifyPropertyChanged
    {

        private StackPanel _Torre1;
        public StackPanel Torre1
        {
            get
            {
                return _Torre1;
            }
            set
            {
                _Torre1 = value;
                OnPropertyChanged("Torre1");
            }
        }


        private StackPanel _Torre2;
        public StackPanel Torre2
        {
            get
            {
                return _Torre2;
            }
            set
            {
                _Torre2 = value;
                OnPropertyChanged("Torre2");
            }
        }


        private StackPanel _Torre3;
        public StackPanel Torre3
        {
            get
            {
                return _Torre3;
            }
            set
            {
                _Torre3 = value;
                OnPropertyChanged("Torre3");
            }
        }

        public HanoiVM(StackPanel stack1, StackPanel stack2, StackPanel stack3)
        {
            this.Torre1 = stack1;
            this.Torre2 = stack2;
            this.Torre3 = stack3;

            this.InicializarDiscos(4);
                        
        }

        private void InicializarDiscos(int numDiscos)
        {
            int minWidth = 40;
            for(int i = 0; i < numDiscos; i++)
            {
                Rectangle r = new Rectangle();
                r.Fill = Brushes.Black;
                r.Width = minWidth;
                r.Margin = new System.Windows.Thickness(10, 0, 10, 0);

                this.Torre1.Children.Add(r);

                minWidth += 20;

            }
        }

        #region Miembros de INotifyPropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
