using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Shoppe.Model
{
    public class MAboutAppLinks:BaseModel
    {

        public int ID { get; set; }

        string _Content;
        public string Content
        {
            get { return _Content; }
            set
            {
                _Content = value;
                Notify("Content");
            }
        }

        BitmapImage _Icon= new BitmapImage();
        public BitmapImage Icon
        {
            get { return _Icon; }
            set
            {
                _Icon = value;
                Notify("Icon");
            }
        }

        public string UrlLink { get; set; }


        
    }
}
