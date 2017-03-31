using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Shoppe
{
    public class MUIDToMuNameConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if ((int)value > 0)
                {
                    int ID = (int)value;
                    var Mu = Base.AllMUs.SingleOrDefault(x => x.ID == ID);
                    if (Mu != null)
                    {
                        return Mu.Title;
                    }
                    else
                    {
                        return "NA";
                    }


                }
                else
                {
                    return "NA";
                }
            }
            catch
            {
                return "NA";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object();
        }
    }
}
