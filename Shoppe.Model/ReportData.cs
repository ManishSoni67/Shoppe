using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
   public class ReportData:BaseModel
    {
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

        double _Value;
        public double Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                Notify("Value");
            }
        }
    }
}
