using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01ConexionBD.UI
{       
    public class MainWindowVM : System.ComponentModel.INotifyPropertyChanged
    {
        private ConexionBD conexion = null;
        
        private DataTable _DataSource;
        public DataTable DataSource
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                OnPropertyChanged("DataSource");
            }
        }
        
        private string _ConsultaText;
        public string ConsultaText
        {
            get
            {
                return _ConsultaText;
            }
            set
            {
                _ConsultaText = value;
                OnPropertyChanged("ConsultaText");
            }
        }

        public MainWindowVM(System.Windows.Window w)
        {
            //this.conexion = new ConexionBD(EConexionBDTipoConexion.PostgreSQL, "localhost", "postgres", "postgres", "123");            
            //this.conexion = new ConexionBD(EConexionBDTipoConexion.MSSQLServer, "localhost", "Refaccionaria", "sa", "123");

            ConfiguracionVM vm = new ConfiguracionVM();
            if (!vm.Show())
            {
                w.Close();
            }

            this.conexion = new ConexionBD(vm.TipoConexion, vm.ServidorText, vm.BDText, vm.UsuarioText, vm.PasswordText);
            
        }

        private System.Windows.Input.ICommand _EjecutarConsultaCommand;
        public System.Windows.Input.ICommand EjecutarConsultaCommand
        {
            get
            {
                if (_EjecutarConsultaCommand == null)
                {
                    _EjecutarConsultaCommand = new RelayCommand<Object>(p => EjecutarConsulta(p));
                }

                return _EjecutarConsultaCommand;
            }
        }

        private void EjecutarConsulta(Object o)
        {
            try
            {
                this.DataSource = this.conexion.EjecutarConsultaResultados(this.ConsultaText);
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }
                        
        }



        private System.Windows.Input.ICommand _NuevaConexionCommand;
        public System.Windows.Input.ICommand NuevaConexionCommand
        {
            get
            {
                if (_NuevaConexionCommand == null)
                {
                    _NuevaConexionCommand = new RelayCommand<System.Windows.Window>(p => NuevaConexion(p));
                }

                return _NuevaConexionCommand;
            }
        }

        private void NuevaConexion(System.Windows.Window o)
        {
            ConfiguracionVM vm = new ConfiguracionVM();
            
            if (vm.Show())
            {
                this.ConsultaText = string.Empty;
                this.DataSource = null;
            }

            this.conexion = new ConexionBD(vm.TipoConexion, vm.ServidorText, vm.BDText, vm.UsuarioText, vm.PasswordText);
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
