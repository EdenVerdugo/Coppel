using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Npgsql;

namespace P01ConexionBD
{    
    //        Autor : Eden Rodrigo Verdugo Garcia
    //        Fecha : 2018/04/22
    //  Descripcion : Versión rápida para una clase que permita conexiones a bases de datos, no implementare transacciones por el momento aunque podria agregarlas despues.
    //          Uso : Instanciar el objeto de esta clase y usar los metodos EjecutarConsulta para consultas sin recordsets devueltos, EjecutarConsultaResultados para obtener un DataTable o EjecutarConsultaResultados<T> para obtener una Lista del tipo T.
    public class ConexionBD
    {
        EConexionBDTipoConexion _tipoConexion;
        IDbConnection _cnx = null;        
                
        public ConexionBD(EConexionBDTipoConexion tipoConexion, string servidor, string bd, string usuario, string password)
        {
            this._tipoConexion = tipoConexion;

            string cadenaConexion = "";

            switch (tipoConexion)
            {
                case EConexionBDTipoConexion.MSSQLServer:
                    SqlConnectionStringBuilder sqlbuilder = new SqlConnectionStringBuilder();

                    sqlbuilder.DataSource = servidor;
                    sqlbuilder.InitialCatalog = bd;
                    sqlbuilder.UserID = usuario;
                    sqlbuilder.Password = password;

                    _cnx = new SqlConnection(sqlbuilder.ConnectionString);

                    break;
                case EConexionBDTipoConexion.PostgreSQL:
                    
                    NpgsqlConnectionStringBuilder pgbuilder = new NpgsqlConnectionStringBuilder();
                    pgbuilder.Host = servidor;
                    pgbuilder.Database = bd;
                    pgbuilder.Username = usuario;
                    pgbuilder.Password = password;

                    _cnx = new NpgsqlConnection(pgbuilder.ConnectionString);

                    break;
            }            
        }                
                
        public void EjecutarConsulta(string consulta)
        {
            try
            {
                this._cnx.Open();

                //using para liberar recursos del command cuando acabe la consulta
                using (var cmd = this._cnx.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }
        }

        public void EjecutarConsulta(string consulta, ConexionBDParametros parametros)
        {
            try
            {
                this._cnx.Open();                
                //using para liberar recursos del command cuando acabe la consulta
                using (var cmd = this._cnx.CreateCommand())
                {                    
                    cmd.CommandText = consulta;
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    foreach(var p in parametros.ListaParametros)
                    {                        
                        var pt = cmd.CreateParameter();
                        pt.ParameterName = p.Name;
                        pt.DbType = p.Type;
                        pt.Value = p.Value;
                        pt.Size = p.Size;
                        pt.Direction = p.Direction;

                        cmd.Parameters.Add(pt);
                    }                                        

                    cmd.ExecuteNonQuery();

                    foreach(IDbDataParameter p in cmd.Parameters)
                    {
                        var param = parametros.ListaParametros.FirstOrDefault(x => x.Name == p.ParameterName);
                        if(param != null)
                        {
                            param.Value = p.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }
        }


        public DataTable EjecutarConsultaResultados(string consulta)
        {
            DataTable dt = null;
            try
            {
                this._cnx.Open();
                                
                using (var cmd = this._cnx.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    dt = new DataTable();

                    switch (this._tipoConexion)
                    {
                        case EConexionBDTipoConexion.MSSQLServer:
                            var sqlAdapter = new SqlDataAdapter((SqlCommand)cmd);
                            sqlAdapter.Fill(dt);
                            break;
                        case EConexionBDTipoConexion.PostgreSQL:
                            var pgAdapter = new NpgsqlDataAdapter((NpgsqlCommand)cmd);
                            pgAdapter.Fill(dt);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }

            return dt;
        }

        public DataTable EjecutarConsultaResultados(string consulta, ConexionBDParametros parametros)
        {
            DataTable dt = null;
            try
            {
                this._cnx.Open();

                using (var cmd = this._cnx.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    cmd.CommandType = CommandType.StoredProcedure;

                    dt = new DataTable();

                    foreach (var p in parametros.ListaParametros)
                    {
                        var pt = cmd.CreateParameter();
                        pt.ParameterName = p.Name;
                        pt.DbType = p.Type;
                        pt.Value = p.Value;
                        pt.Size = p.Size;
                        pt.Direction = p.Direction;

                        cmd.Parameters.Add(pt);
                    }

                    switch (this._tipoConexion)
                    {
                        case EConexionBDTipoConexion.MSSQLServer:
                            var sqlAdapter = new SqlDataAdapter((SqlCommand)cmd);
                            sqlAdapter.Fill(dt);
                            break;
                        case EConexionBDTipoConexion.PostgreSQL:
                            var pgAdapter = new NpgsqlDataAdapter((NpgsqlCommand)cmd);
                            pgAdapter.Fill(dt);
                            break;
                    }

                    foreach (IDbDataParameter p in cmd.Parameters)
                    {
                        var param = parametros.ListaParametros.FirstOrDefault(x => x.Name == p.ParameterName);
                        if (param != null)
                        {
                            param.Value = p.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }

            return dt;
        }

        public List<T> EjecutarConsultaResultados<T>(string consulta, ConexionBDParametros parametros)
        {
            List<T> lst = new List<T>();
            Type temp = typeof(T);

            try
            {
                this._cnx.Open();

                using(var cmd = this._cnx.CreateCommand())
                {
                    cmd.CommandText = consulta;
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var p in parametros.ListaParametros)
                    {
                        var pt = cmd.CreateParameter();
                        pt.ParameterName = p.Name;
                        pt.DbType = p.Type;
                        pt.Value = p.Value;
                        pt.Size = p.Size;
                        pt.Direction = p.Direction;

                        cmd.Parameters.Add(pt);
                    }

                    var lector = cmd.ExecuteReader();

                    while (lector.Read())
                    {
                        //crear la instancia del objeto 
                        T obj = Activator.CreateInstance<T>();

                        //buscar todos sus campos y propiedades
                        for (int i = 0; i < lector.FieldCount; i++)
                        {

                            foreach (FieldInfo pro in temp.GetFields())
                            {
                                // si se encuentra se asigna el valor encontrado
                                // nota : esto puede causar una excepcion si el tipo de valor que se encuentra no es el mismo tipo que regresa la consulta
                                if (pro.Name == lector.GetName(i))
                                {
                                    pro.SetValue(obj, lector[i]);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            foreach (PropertyInfo pro in temp.GetProperties())
                            {
                                if (pro.Name == lector.GetName(i))
                                {
                                    pro.SetValue(obj, lector[i], null);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                        lst.Add(obj);
                    }
                    lector.Close();

                    foreach (IDbDataParameter p in cmd.Parameters)
                    {
                        var param = parametros.ListaParametros.FirstOrDefault(x => x.Name == p.ParameterName);
                        if (param != null)
                        {
                            param.Value = p.Value;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }


            return lst;
        }


        public List<T> EjecutarConsultaResultados<T>(string consulta)
        {
            List<T> lst = new List<T>();
            Type temp = typeof(T);

            try
            {
                this._cnx.Open();

                using (var cmd = this._cnx.CreateCommand())
                {
                    cmd.CommandText = consulta;

                    var lector = cmd.ExecuteReader();

                    while (lector.Read())
                    {
                        //crear la instancia del objeto 
                        T obj = Activator.CreateInstance<T>();

                        //buscar todos sus campos y propiedades
                        for (int i = 0; i < lector.FieldCount; i++)
                        {

                            foreach (FieldInfo pro in temp.GetFields())
                            {
                                // si se encuentra se asigna el valor encontrado
                                // nota : esto puede causar una excepcion si el tipo de valor que se encuentra no es el mismo tipo que regresa la consulta
                                if (pro.Name == lector.GetName(i))
                                {
                                    pro.SetValue(obj, lector[i]);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            foreach (PropertyInfo pro in temp.GetProperties())
                            {
                                if (pro.Name == lector.GetName(i))
                                {
                                    pro.SetValue(obj, lector[i], null);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }

                        lst.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._cnx.Close();
            }


            return lst;
        }
    }
}
