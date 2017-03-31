using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
    public class AboutAppModel:BaseModel
    {
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


        string _Version;
        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                Notify("Version");
            }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                Notify("Description");
            }
        }
    }
}
