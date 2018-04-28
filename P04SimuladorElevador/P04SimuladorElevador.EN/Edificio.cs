using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04SimuladorElevador.EN
{

    public class Edificio : System.ComponentModel.INotifyPropertyChanged
    {
        public static Random Random { get; set; } = new Random();

        private Elevador _Elevador;
        public Elevador Elevador
        {
            get
            {
                return _Elevador;
            }
            set
            {
                _Elevador = value;
                OnPropertyChanged("Elevador");
            }
        }


        private List<int> _Pisos;
        public List<int> Pisos
        {
            get
            {
                return _Pisos;
            }
            set
            {
                _Pisos = value;
                OnPropertyChanged("Pisos");
            }
        }


        private List<Persona> _PersonasEsperando;
        public List<Persona> PersonasEsperando
        {
            get
            {
                return _PersonasEsperando;
            }
            set
            {
                _PersonasEsperando = value;
                OnPropertyChanged("PersonasEsperando");
            }
        }

        public Edificio(int numPisos, int numPersonas)
        {
            this.Elevador = new Elevador();
            this.Pisos = new List<int>();
            this.PersonasEsperando = new List<Persona>();

            for(int i=0; i < numPisos; i++)
            {
                this.Pisos.Add(i + 1 );
            }

            Random r = new Random();
            for(int i=0; i < numPersonas; i++)
            {
                this.PersonasEsperando.Add(new Persona(numPisos));
            }
        }


        private String _Descripcion;
        public String Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }


        private string _Suben;
        public string Suben
        {
            get
            {
                return _Suben;
            }
            set
            {
                _Suben = value;
                OnPropertyChanged("Suben");
            }
        }


        private int _PersonasElevador;
        public int PersonasElevador
        {
            get
            {
                return _PersonasElevador;
            }
            set
            {
                _PersonasElevador = value;
                OnPropertyChanged("PersonasElevador");
            }
        }


        private int _PersonasPiso1;
        public int PersonasPiso1
        {
            get
            {
                return _PersonasPiso1;
            }
            set
            {
                _PersonasPiso1 = value;
                OnPropertyChanged("PersonasPiso1");
            }
        }


        private int _PersonasPiso2;
        public int PersonasPiso2
        {
            get
            {
                return _PersonasPiso2;
            }
            set
            {
                _PersonasPiso2 = value;
                OnPropertyChanged("PersonasPiso2");
            }
        }


        private int _PersonasPiso3;
        public int PersonasPiso3
        {
            get
            {
                return _PersonasPiso3;
            }
            set
            {
                _PersonasPiso3 = value;
                OnPropertyChanged("PersonasPiso3");
            }
        }

        public void ActualizarPersonasEsperando()
        {
            this.PersonasPiso1 = this.PersonasEsperando.Where(x => x.PlantaActual == 1).Count();
            this.PersonasPiso2 = this.PersonasEsperando.Where(x => x.PlantaActual == 2).Count();
            this.PersonasPiso3 = this.PersonasEsperando.Where(x => x.PlantaActual == 3).Count();
        }

        public async Task Simular()
        {           
            // las personas salen del elevador y liberan espacio
            this.Descripcion = String.Format("Bajan {0} personas." , Elevador.Personas.RemoveAll(x => x.PlantaViajar == Elevador.PisoActual));            
            Elevador.Peso = Elevador.Personas.Sum(x => x.Peso);

            this.PersonasElevador = this.Elevador.Personas.Count;

            this.ActualizarPersonasEsperando();

            await Task.Delay(TimeSpan.FromSeconds(1));
                        
            // verificar si hay personas en el piso actual  
            var personas = PersonasEsperando.Where(x => x.PlantaActual == Elevador.PisoActual).ToList();

            if (Elevador.PisoActual == this.Pisos.Count)
            {
                this.Elevador.Movimiento = -1;
            }
            else if (Elevador.PisoActual == 1)
            {
                this.Elevador.Movimiento = 1;
            }

            // verificar si las personas van al piso que corresponde el movimiento del elevador
            // movimiento hacia arriba
            if (Elevador.Movimiento == 1)
            {
                // personas que suben de planta
                var subir = personas.Where(x => x.PlantaActual < x.PlantaViajar).ToList();

                int count = 0;
                foreach (var p in subir)
                {
                    // si el peso del elevador es menor a 150 suben
                    if ((this.Elevador.Peso + p.Peso) < 150)
                    {
                        this.Elevador.Personas.Add(p);
                        this.Elevador.Peso += p.Peso;

                        PersonasEsperando.Remove(p);
                        count++;
                    }
                }

                this.PersonasElevador = this.Elevador.Personas.Count;
                this.Suben = String.Format("Suben {0} personas.", count);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            else
            {

                var bajar = personas.Where(x => x.PlantaActual > x.PlantaViajar).ToList();

                int count = 0;
                foreach (var p in bajar)
                {
                    // si el peso del elevador es menor a 150 suben
                    if ((this.Elevador.Peso + p.Peso) < 150)
                    {
                        this.Elevador.Personas.Add(p);
                        this.Elevador.Peso += p.Peso;

                        PersonasEsperando.Remove(p);
                        count++;
                    }
                }

                this.Suben = String.Format("Suben {0} personas.", count);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            this.ActualizarPersonasEsperando();

            if (this.PersonasEsperando.Count > 0 || this.Elevador.Personas.Count > 0)
            {
                this.Elevador.PisoActual += Elevador.Movimiento;
                this.Suben = string.Empty;
                this.Descripcion = string.Empty;
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
