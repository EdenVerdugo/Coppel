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
        }

        public ResultadoModel CatArticulosGuardar(CatArticulosModel a)
        {
            ResultadoModel r = new ResultadoModel();

            try
            {
                ConexionBDParametros parametros = new ConexionBDParametros();
                parametros.Agregar("@pCatArticulosID", System.Data.DbType.Int32, a.CatArticulosID);
                parametros.Agregar("@pDescripcion", System.Data.DbType.String, a.Descripcion);
                parametros.Agregar("@pPrecio", System.Data.DbType.Decimal, a.Precio);
                parametros.Agregar("@pCosto", System.Data.DbType.Decimal, a.Costo);
                parametros.Agregar("@pResultado", System.Data.DbType.Byte, System.Data.ParameterDirection.Output);
                parametros.Agregar("@pMsg", System.Data.DbType.String, 300, System.Data.ParameterDirection.Output);

                _conexion.EjecutarConsulta("CatArticulosGuardar", parametros);

                r.Valor = parametros.Value("@pResultado").ToBool();
                r.Mensaje = parametros.Value("@pMsg").ToString();
            }
            catch(Exception ex)
            {
                r.Valor = false;
                r.Mensaje = ex.Message;
            }            

            return r;
        }

        public ResultadoModel CatArticulosEliminar(CatArticulosModel a)
        {
            ResultadoModel r = new ResultadoModel();

            try
            {
                ConexionBDParametros parametros = new ConexionBDParametros();
                parametros.Agregar("@pCatArticulosID", System.Data.DbType.Int32, a.CatArticulosID);                
                parametros.Agregar("@pResultado", System.Data.DbType.Byte, System.Data.ParameterDirection.Output);
                parametros.Agregar("@pMsg", System.Data.DbType.String, 300, System.Data.ParameterDirection.Output);

                _conexion.EjecutarConsulta("CatArticulosEliminar", parametros);

                r.Valor = parametros.Value("@pResultado").ToBool();
                r.Mensaje = parametros.Value("@pMsg").ToString();
            }
            catch (Exception ex)
            {
                r.Valor = false;
                r.Mensaje = ex.Message;
            }            

            return r;
        }

        public ResultadoModel CatArticulosBuscar()
        {
            ResultadoModel r = new ResultadoModel();

            try
            {                
                var lst = _conexion.EjecutarConsultaResultados<CatArticulosModel>("CatArticulosBuscar");

                r.Valor = true;
                r.Mensaje = string.Empty;
                r.Datos = lst;                                
            }
            catch (Exception ex)
            {
                r.Valor = false;
                r.Mensaje = ex.Message;
            }            

            return r;
        }

    }
}
