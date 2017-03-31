using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
   public class MMUs:BaseModel
    {
        public int ID { get; set; }


        string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Notify("Title");
            }
        }

        bool _IsMaster;
        public bool IsMaster
        {
            get { return _IsMaster; }
            set
            {
                _IsMaster = value;
                Notify("IsMaster");
            }
        }

        double _UnitRate;
        public double UnitRate
        {
            get { return _UnitRate; }
            set
            {
                _UnitRate = value;
                Notify("UnitRate");
            }
        }

        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set
            {
                _CreatedOn = value;
                Notify("CreatedOn");
            }
        }

        public DateTime UpdatedOn { get; set; }

    }
}
