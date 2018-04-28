using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P05ABC.EN
{
    public class Globales
    {
        public static string Path { get; set; } = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static ConexionModel Conexion { get; set; } = new ConexionModel()
        {
            DataSource = "localhost",            
            DataBase = "test",
            UserID = "sa",
            Password = "123"
        };
    }
}
