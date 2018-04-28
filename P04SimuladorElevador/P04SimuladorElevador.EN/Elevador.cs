using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04SimuladorElevador.EN
{

    public class Elevador : System.ComponentModel.INotifyPropertyChanged
    {

        private int _Movimiento;
        public int Movimiento
        {
            get
            {
                return _Movimiento;
            }
            set
            {
                _Movimiento = value;
                OnPropertyChanged("Movimiento");
            }
        }

        private int _PisoDestino;
        public int PisoDestino
        {
            get
            {
                return _PisoDestino;
            }
            set
            {
                _PisoDestino = value;
                OnPropertyChanged("PisoDestino");
            }
        }

        private int _PisoActual;
        public int PisoActual
        {
            get
            {
                return _PisoActual;
            }
            set
            {
                _PisoActual = value;
                OnPropertyChanged("PisoActual");
            }
        }

        private decimal _Peso;
        public decimal Peso
        {
            get
            {
                return _Peso;
            }
            set
            {
                _Peso = value;
                OnPropertyChanged("Peso");
            }
        }

        private List<Persona> _Personas;
        public List<Persona> Personas
        {
            get
            {
                return _Personas;
            }
            set
            {
                _Personas = value;
                OnPropertyChanged("Personas");
            }
        }

        public Elevador()
        {
            this.PisoActual = 1;
            this.PisoDestino = 1;
            this.Movimiento = 1;
            this.Peso = 0;
            this.Personas = new List<Persona>();            
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
