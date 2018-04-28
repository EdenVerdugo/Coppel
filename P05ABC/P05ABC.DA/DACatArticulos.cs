using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01ConexionBD;
using P05ABC.EN;
using System.Xml.Linq;

namespace P05ABC.DA
{
    public class DACatArticulos
    {
        ConexionBD _conexion = null;

        public List<String> Instrucciones { get; set; }

        public DACatArticulos()
        {
            this._conexion = new ConexionBD(EConexionBDTipoConexion.MSSQLServer, Globales.Conexion.DataSource, Globales.Conexion.DataBase, Globales.Conexion.UserID, Globales.Conexion.Password);

            this.InicializarDB();
        }

        //estas acciones deberian de estar en un DAConfiguracion
        public ResultadoModel InicializarDB()
        {
            ResultadoModel r = new ResultadoModel();
            try
            {
                XDocument instrucciones = XDocument.Load(Globales.Path + @"\SQL\mssql.xml");

                var createdb = instrucciones.Element("InstruccionesBD").Elements("Instruccion").FirstOrDefault();
                if(createdb != null)
                {
                    string consulta = createdb.Value;
                    this._conexion.EjecutarConsulta(consulta);
                }

                _conexion = new ConexionBD(EConexionBDTipoConexion.MSSQLServer, Globales.Conexion.DataSource, "Pruebas", Globales.Conexion.UserID, Globales.Conexion.Password);

                foreach (var i in instrucciones.Element("InstruccionesBD").Elements("Instruccion"))
                {
                    string consulta = i.Value;
                    this._conexion.EjecutarConsulta(consulta);
                }
            }
            catch(Exception ex)
            {
                r.Valor = false;
                r.Mensaje = ex.Message;
            }

            return r;            
        }
    }
}
