using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P02Clonador;

namespace P02Clonador.Shell
{
    public class Ejemplo
    {
        

        public Ejemplo(string val1, string val2, string val3)
        {
            Valor1 = val1;
            Valor2 = val2;
            Valor3 = val3;
        }

        public string Valor1;
        public string Valor2 { get; set; }
        private string Valor3;
    }
        

    class Program
    {
        static void Main(string[] args)
        {
            Ejemplo e = new Ejemplo("Eden", "Rodrigo", "Verdugo Garcia");

            Console.WriteLine("Se va a clonar un objeto, favor de poner un breakpoint en la linea correspondiente para debugear...");

            var objetoClonado = Clonador.Clonar<Ejemplo>(e);

            Console.WriteLine("Se ha clonado correctamente el objeto...");
            Console.ReadLine();
        }
    }
}
