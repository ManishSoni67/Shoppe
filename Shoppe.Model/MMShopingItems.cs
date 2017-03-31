using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
    public class MMShopingItems:BaseModel
    {

        public static MMShopingItems Copy(MMShopingItems item)
        {
            MMShopingItems nw = new MMShopingItems() 
            {
                ID=item.ID,
                Amount= item.Amount,
                CreatedOn= item.CreatedOn,
                Isbusy= item.Isbusy,
                Description= item.Description,
                HeaderID= item.HeaderID,
                MUID= item.MUID,
                Name= item.Name,
                Qty= item.Qty,
                LineID= item.LineID,
                UnitRate= item.UnitRate,
                Revision= item.Revision,
                UpdatedOn= item.UpdatedOn,
                UserID= item.UserID,
                IsFromMaster= item.IsFromMaster,
                ItemMasterID= item.ItemMasterID,
            };
            return nw;
           
             
        }

        bool _IsFromMaster=false;
        public bool IsFromMaster
        {
            get { return _IsFromMaster; }
            set
            {
                _IsFromMaster = value;
                Notify("IsFromMaster");
            }
        }

        int _ItemMasterID;
        public int ItemMasterID
        {
            get { return _ItemMasterID; }
            set
            {
                _ItemMasterID = value;
                Notify("ItemMasterID");
            }
        }

        int _LineID;
        public int LineID
        {
            get { return _LineID; }
            set
            {
                _LineID = value;
                Notify("LineID");
            }
        }

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

        double _Qty;
        public double Qty
        {
            get { return _Qty; }
            set
            {
                _Qty = value;
                UpdateAmount();
                Notify("Qty");
            }
        }

        int _HeaderID;
        public int HeaderID
        {
            get { return _HeaderID; }
            set
            {
                _HeaderID = value;
                Notify("HeaderID");
            }
        }

        int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                Notify("UserID");
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

        double _UnitRate;
        public double UnitRate
        {
            get { return _UnitRate; }
            set
            {
                _UnitRate = value;
                UpdateAmount();
                Notify("UnitRate");
            }
        }

        double _Amount;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
                Notify("Amount");
            }
        }


        DateTime _CreatedOn=DateTime.Today;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set
            {
                _CreatedOn = value;
                Notify("CreatedOn");
            }
        }

        DateTime _UpdatedOn=DateTime.Today;
        public DateTime UpdatedOn
        {
            get { return _UpdatedOn; }
            set
            {
                _UpdatedOn = value;
                Notify("UpdatedOn");
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

        int _Revision;
        public int Revision
        {
            get { return _Revision; }
            set
            {
                _Revision = value;
                Notify("Revision");
            }
        }


        private void UpdateAmount()
        {
            this.Amount = Math.Round(this.Qty * this.UnitRate, 2);
        }


      
    }
}
