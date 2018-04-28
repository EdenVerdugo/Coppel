using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P02Clonador
{
    public class Clonador
    {
        public static T Clonar<T>(T objeto)
        {
            Type type = typeof(T);

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var obj = (T)Activator.CreateInstance(type);

            foreach(var field in fields)
            {
                field.SetValue(obj, field.GetValue(objeto));
            }

            return obj;
        }
    }
}
