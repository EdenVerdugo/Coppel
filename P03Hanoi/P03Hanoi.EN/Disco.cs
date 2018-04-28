using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace P03Hanoi.EN
{

    public class Disco : System.ComponentModel.INotifyPropertyChanged
    {

        private int _Numero;
        public int Numero
        {
            get
            {
                return _Numero;
            }
            set
            {
                _Numero = value;
                OnPropertyChanged("Numero");
            }
        }


        private String _Color;
        public String Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                OnPropertyChanged("Color");
            }
        }


        private Rectangle _Rectangulo;
        public Rectangle Rectangulo
        {
            get
            {
                return _Rectangulo;
            }
            set
            {
                _Rectangulo = value;
                OnPropertyChanged("Rectangulo");
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
