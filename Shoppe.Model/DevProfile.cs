using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
   public class DevProfile:BaseModel
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

        string _Designation;
        public string Designation
        {
            get { return _Designation; }
            set
            {
                _Designation = value;
                Notify("Designation");
            }
        }

        string _Skills;
        public string Skills
        {
            get { return _Skills; }
            set
            {
                _Skills = value;
                Notify("Skills");
            }
        }

        string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                Notify("Email");
            }
        }

        string _CurrentComp;
        public string CurrentComp
        {
            get { return _CurrentComp; }
            set
            {
                _CurrentComp = value;
                Notify("CurrentComp");
            }
        }
        string _LinkedInUrl;
        public string LinkedInUrl
        {
            get { return _LinkedInUrl; }
            set
            {
                _LinkedInUrl = value;
                Notify("LinkedInUrl");
            }
        }


    }
}
