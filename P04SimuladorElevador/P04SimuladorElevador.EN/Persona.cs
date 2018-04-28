using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04SimuladorElevador.EN
{

    public class Persona : System.ComponentModel.INotifyPropertyChanged
    {
        private int PisosEdificio = 0;

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
        
        private int _PlantaViajar;
        public int PlantaViajar
        {
            get
            {
                return _PlantaViajar;
            }
            set
            {
                _PlantaViajar = value;
                OnPropertyChanged("PlantaViajar");
            }
        }


        private int _PlantaActual;
        public int PlantaActual
        {
            get
            {
                return _PlantaActual;
            }
            set
            {
                _PlantaActual = value;
                OnPropertyChanged("PlantaActual");
            }
        }

        public Persona(int pisosEdificio)
        {            
            this.PisosEdificio = pisosEdificio;

            this.Peso = Edificio.Random.Next(20, 100);           

            this.PlantaActual = Edificio.Random.Next(1, pisosEdificio);

            if(this.PlantaActual == 1)
            {
                this.PlantaViajar = Edificio.Random.Next(2, pisosEdificio);
            }
            else if(this.PlantaActual == pisosEdificio)
            {
                this.PlantaViajar = Edificio.Random.Next(1, pisosEdificio - 1);
            }
            else
            {
                this.PlantaViajar = Edificio.Random.Next(1, pisosEdificio);
                
                if(this.PlantaViajar == this.PlantaActual)
                {
                    this.PlantaViajar += 1;
                }
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
