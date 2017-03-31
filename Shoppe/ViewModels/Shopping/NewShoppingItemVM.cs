using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{

    public class NewShoppingItemVM:BaseModel
    {
        ShoppeDBContext db = null;
        private void InitializeDB()
        {
            this.db = new ShoppeDBContext(App.ConnectionString);
            if (!(db.DatabaseExists()))
            {
                db.CreateDatabase();
            }
        }

        public event EventHandler ItemSaved;
        public void RaiseItemSaved()
        {
            if (ItemSaved != null)
                ItemSaved(this, new EventArgs());
        }
        public NewShoppingItemVM()
        {
            InitializeDB();
            Oninit();
        }

        private void Oninit()
        {
            LoadMasters();
        }

        private void LoadMasters()
        {
            this.AllMUs = new ObservableCollection<MMUs>(Base.AllMUs);
            this.Types = MasterItemType.GetAllMasterTypes();
        }

        ObservableCollection<MMUs> _AllMUs= new ObservableCollection<MMUs>();
        public ObservableCollection<MMUs> AllMUs
        {
            get { return _AllMUs; }
            set
            {
                _AllMUs = value;
                Notify("AllMUs");
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

        MMShopingItems _ShoppingItem= new MMShopingItems();
        public MMShopingItems ShoppingItem
        {
            get { return _ShoppingItem; }
            set
            {
                _ShoppingItem = value;
                Notify("ShoppingItem");
            }
        }


        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(ShoppingItem.Name)) { Status = "Name Cannot be null or Empty"; return false; }
            else if (this.ShoppingItem.Qty <= 0) { Status = "Quantity Cannot be Zero or Negative"; return false; }
            else if (this.ShoppingItem.UnitRate <= 0) { Status = "Unit Rate cannot be Zero or Negative"; return false; }
            else
            {
                Status = "";
                return true;
            }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                Notify("Status");
            }
        }

        public void ReflectChange()
        {
            if (this.Validate())
            {
                RaiseItemSaved();
            }
           
        }


        string _ViewTitle="New Shopping Item";
        public string ViewTitle
        {
            get { return _ViewTitle; }
            set
            {
                _ViewTitle = value;
                Notify("ViewTitle");
            }
        }


    }
}
