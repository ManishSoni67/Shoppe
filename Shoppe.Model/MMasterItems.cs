using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Shoppe.Model
{
    public class MMasterItems : BaseModel
    {

        public event EventHandler Checked;
        public void RaiseChecked()
        {
            if (Checked != null)
                Checked(this, new EventArgs());
        }

        public int ID { get; set; }


        public bool IsInDB
        {
            get
            {
                return ID > 0;
            }
            set { }
        }

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


        bool _isChecked = false;
        public bool isChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaiseChecked();
                Notify("isChecked");
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

        int _MUID;
        public int MUID
        {
            get { return _MUID; }
            set
            {
                _MUID = value;
                Notify("MUID");
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

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }



        string _PicPath;
        public string PicPath
        {
            get { return _PicPath; }
            set
            {
                _PicPath = value;
                Notify("PicPath");
            }
        }

        bool _IsVeg = true;
        public bool IsVeg
        {
            get { return _IsVeg; }
            set
            {
                _IsVeg = value;
                Notify("IsVeg");
            }
        }

        BitmapImage _ItemImage = new BitmapImage();
        public BitmapImage ItemImage
        {
            get { return _ItemImage; }
            set
            {
                _ItemImage = value;
                Notify("ItemImage");
            }
        }


        string[] _Types;
        public string[] Types
        {
            get { return _Types; }
            set
            {
                _Types = value;
                Notify("Types");
            }
        }


        public void PopulateImage()
        {
            if (!(string.IsNullOrWhiteSpace(this.PicPath)))
            {
                if (this.IsMaster)
                {
                    //Master Default Images
                }
                else
                {

                    //Images from the Isolated Storages
                }
            }
            else
            {
                //Default Images
            }
        }


    }
}
