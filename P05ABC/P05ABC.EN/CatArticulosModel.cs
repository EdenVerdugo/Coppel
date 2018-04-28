using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05ABC.EN
{

    public class CatArticulosModel : System.ComponentModel.INotifyPropertyChanged
    {
        private int _CatArticulosID;
        public int CatArticulosID
        {
            get
            {
                return _CatArticulosID;
            }
            set
            {
                _CatArticulosID = value;
                OnPropertyChanged("CatArticulosID");
            }
        }


        private string _Descripcion;
        public string Descripcion
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


        private decimal _Precio;
        public decimal Precio
        {
            get
            {
                return _Precio;
            }
            set
            {
                _Precio = value;
                OnPropertyChanged("Precio");
            }
        }


        private decimal _Costo;
        public decimal Costo
        {
            get
            {
                return _Costo;
            }
            set
            {
                _Costo = value;
                OnPropertyChanged("Costo");
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
