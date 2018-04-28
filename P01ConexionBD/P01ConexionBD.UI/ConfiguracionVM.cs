using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01ConexionBD;

namespace P01ConexionBD.UI
{
    public class ConfiguracionVM : System.ComponentModel.INotifyPropertyChanged
    {

        private EConexionBDTipoConexion _TipoConexion;
        public EConexionBDTipoConexion TipoConexion
        {
            get
            {
                return _TipoConexion;
            }
            set
            {
                _TipoConexion = value;
                OnPropertyChanged("TipoConexion");
            }
        }


        private String _ServidorText;
        public String ServidorText
        {
            get
            {
                return _ServidorText;
            }
            set
            {
                _ServidorText = value;
                OnPropertyChanged("ServidorText");
            }
        }


        private string _BDText;
        public string BDText
        {
            get
            {
                return _BDText;
            }
            set
            {
                _BDText = value;
                OnPropertyChanged("BDText");
            }
        }


        private string _UsuarioText;
        public string UsuarioText
        {
            get
            {
                return _UsuarioText;
            }
            set
            {
                _UsuarioText = value;
                OnPropertyChanged("UsuarioText");
            }
        }


        private string _PasswordText;
        public string PasswordText
        {
            get
            {
                return _PasswordText;
            }
            set
            {
                _PasswordText = value;
                OnPropertyChanged("PasswordText");
            }
        }

        public bool Resultado { get; set; }

        public ConfiguracionVM()
        {
            this.TipoConexion = EConexionBDTipoConexion.MSSQLServer;
            this.UsuarioText = string.Empty;
            this.PasswordText = string.Empty;
            this.BDText = string.Empty;
            this.ServidorText = string.Empty;

        }

        public bool Show()
        {
            ConfiguracionView frm = new ConfiguracionView();
            frm.DataContext = this;
            
            frm.ShowDialog();

            return Resultado;
        }


        private System.Windows.Input.ICommand _CerrarCommand;
        public System.Windows.Input.ICommand CerrarCommand
        {
            get
            {
                if (_CerrarCommand == null)
                {
                    _CerrarCommand = new RelayCommand<System.Windows.Window>(p => Cerrar(p));
                }

                return _CerrarCommand;
            }
        }

        private void Cerrar(System.Windows.Window o)
        {
            this.Resultado = false;
            //acciones
            o.Close();
        }


        private System.Windows.Input.ICommand _AceptarCommand;
        public System.Windows.Input.ICommand AceptarCommand
        {
            get
            {
                if (_AceptarCommand == null)
                {
                    _AceptarCommand = new RelayCommand<System.Windows.Window>(p => Aceptar(p), p => PuedeAceptar());
                }

                return _AceptarCommand;
            }
        }

        private bool PuedeAceptar()
        {
            return this.ServidorText != string.Empty &&
                    this.BDText != string.Empty &&
                    this.UsuarioText != string.Empty 
                    ;

        }

        private void Aceptar(System.Windows.Window o)
        {
            this.Resultado = true;
            ConfiguracionView view = (ConfiguracionView)o;

            this.PasswordText = view.PasswordText.Password;
            //acciones
            o.Close();
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
