using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Shoppe.Model
{
   public class MUserInfo:BaseModel
    {

        public int ID { get; set; }

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


        string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                Notify("Password");
            }
        }


        string _DeviceName;
        public string DeviceName
        {
            get { return _DeviceName; }
            set
            {
                _DeviceName = value;
                Notify("DeviceName");
            }
        }


        string _Hint;
        public string Hint
        {
            get { return _Hint; }
            set
            {
                _Hint = value;
                Notify("Hint");
            }
        }

       
        public DateTime CreatedOn { get; set; }

       
        public DateTime UpdatedOn { get; set; }





      

    }
}
