using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Shoppe.Model
{
   public class MAppSettingColors:BaseModel
    {

        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                Notify("ID");
            }
        }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                Notify("Name");
            }
        }

        SolidColorBrush _Color= new SolidColorBrush();
        public SolidColorBrush Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                Notify("Color");
            }
        }
       


    }
}
