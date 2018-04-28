﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace P01ConexionBD.UI.Converters
{
    public class EnumToBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value,
            Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (parameter.Equals(value))
                return true;
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;

        }
        #endregion

    }
}
