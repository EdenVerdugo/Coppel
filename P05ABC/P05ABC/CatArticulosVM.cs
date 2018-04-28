using P05ABC.DA;
using P05ABC.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P05ABC
{

    public class CatArticulosVM : System.ComponentModel.INotifyPropertyChanged
    {
        DACatArticulos _Datos = null;

        public CatArticulosVM()
        {
            this._Datos = new DACatArticulos();

            this.Lista = new List<CatArticulosModel>();
            this.ItemSeleccionado = null;
        }

        private List<CatArticulosModel> _Lista;
        public List<CatArticulosModel> Lista
        {
            get
            {
                return _Lista;
            }
            set
            {
                _Lista = value;
                OnPropertyChanged("Lista");
            }
        }

        private CatArticulosModel _ItemSeleccionado;
        public CatArticulosModel ItemSeleccionado
        {
            get
            {
                return _ItemSeleccionado;
            }
            set
            {
                _ItemSeleccionado = value;
                OnPropertyChanged("ItemSeleccionado");
            }
        }


        private System.Windows.Input.ICommand _NuevoItemCommand;
        public System.Windows.Input.ICommand NuevoItemCommand
        {
            get
            {
                if (_NuevoItemCommand == null)
                {
                    _NuevoItemCommand = new RelayCommand<Object>(p => NuevoItem(p));
                }

                return _NuevoItemCommand;
            }
        }

        private void NuevoItem(Object o)
        {
            CatArticulosDetView view = new CatArticulosDetView();
            view.DataContext = this;
            view.ShowDialog();
        }



        private System.Windows.Input.ICommand _ModificarItemCommand;
        public System.Windows.Input.ICommand ModificarItemCommand
        {
            get
            {
                if (_ModificarItemCommand == null)
                {
                    _ModificarItemCommand = new RelayCommand<Object>(p => ModificarItem(p));
                }

                return _ModificarItemCommand;
            }
        }

        private void ModificarItem(Object o)
        {
            if (MessageBox.Show("¿Deseas guardar los cambios?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
        }



        private System.Windows.Input.ICommand _BorrarItemCommand;
        public System.Windows.Input.ICommand BorrarItemCommand
        {
            get
            {
                if (_BorrarItemCommand == null)
                {
                    _BorrarItemCommand = new RelayCommand<Object>(p => BorrarItem(p));
                }

                return _BorrarItemCommand;
            }
        }

        private void BorrarItem(Object o)
        {
            if (MessageBox.Show("¿Deseas eliminar el articulo?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
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
            o.Close();
        }



        private System.Windows.Input.ICommand _GuardarCommand;
        public System.Windows.Input.ICommand GuardarCommand
        {
            get
            {
                if (_GuardarCommand == null)
                {
                    _GuardarCommand = new RelayCommand<System.Windows.Window>(p => Guardar(p));
                }

                return _GuardarCommand;
            }
        }

        private void Guardar(System.Windows.Window o)
        {
            if(MessageBox.Show("¿Deseas guardar el articulo?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

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
