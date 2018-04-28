using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01ConexionBD
{
    public class ConexionBDParametros
    {
        public List<ConexionBDParametro> ListaParametros { get; set; }

        public ConexionBDParametros()
        {
            this.ListaParametros = new List<ConexionBDParametro>();
        }

        public void Agregar(string name, System.Data.DbType type, ParameterDirection direction)
        {
            this.ListaParametros.Add(new ConexionBDParametro() { Name = name, Type = type, Direction = direction });
        }

        public void Agregar(string name, System.Data.DbType type, object value)
        {
            this.ListaParametros.Add(new ConexionBDParametro() { Name = name, Type = type, Value = value });
        }

        public void Agregar(string name, System.Data.DbType type, object value, ParameterDirection direction)
        {
            this.ListaParametros.Add(new ConexionBDParametro() { Name = name, Type = type, Value = value, Direction = direction });
        }

        public void Agregar(string name, System.Data.DbType type, int size, ParameterDirection direction)
        {
            this.ListaParametros.Add(new ConexionBDParametro() { Name = name, Type = type, Size = size, Direction = direction });
        }

        public void Agregar(string name, System.Data.DbType type, object value, int size, ParameterDirection direction)
        {
            this.ListaParametros.Add(new ConexionBDParametro() { Name = name, Type = type, Value = value, Direction = direction, Size = size });
        }

        public ConexionBDCasteable Value(string name)
        {
            var p = this.ListaParametros.FirstOrDefault(x => x.Name == name);
            
            if(p == null)
            {
                throw new Exception("No se encontro el parametro");
            }

            return new ConexionBDCasteable(p.Value);
        }

        public class ConexionBDParametro
        {
            public string Name;
            public System.Data.DbType Type;
            public Object Value;
            public int Size;
            public ParameterDirection Direction;
        }        
    }
}
