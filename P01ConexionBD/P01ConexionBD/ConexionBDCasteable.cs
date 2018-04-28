using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01ConexionBD
{
    public class ConexionBDCasteable
    {
        //definir todos los converts aqui

        Object obj = null;
        public ConexionBDCasteable(Object o)
        {
            obj = o;
        }

        public override string ToString()
        {
            return obj.ToString();
        }

        public decimal ToDecimal()
        {
            return Convert.ToDecimal(obj.ToString());
        }

        public int ToInt()
        {
            return Convert.ToInt32(obj.ToString());
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(obj);
        }
    }
}
