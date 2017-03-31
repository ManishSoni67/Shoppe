using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Shoppe
{
    public class InvBoolToVisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var val = (bool)value;
                if (val)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            catch
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object();
        }
    }
}
