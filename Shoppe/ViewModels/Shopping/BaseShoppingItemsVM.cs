using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;
namespace Shoppe
{
    public class BaseShoppingItemsVM : BaseModel
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
        public BaseShoppingItemsVM()
        {
            Oninit();
            AttatchEvent();
        }
        private void Oninit()
        {
            InitializeDB();
            LoadAllBaseItem();
        }
        public void LoadAllBaseItem()
        {
            this.MasterItems = new ObservableCollection<MMasterItems>(Base.AllItems);
            this.VegItems = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Vegetable)));
            this.NonVegItems = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.NonVegetable)));
            this.Spices = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Spices)));
            this.Fruits = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Fruits)));
            this.Cerials = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Cerials)));
            this.Drinks = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Drinks)));
            this.FastFoods = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.FastFood)));
            this.Nuts = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Nuts)));
            this.Oils = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Oils)));
            this.Personal = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Personal)));
            this.Others = new ObservableCollection<MMasterItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Others)));
           

        }

        private void AttatchEvent()
        {
            foreach (var item in MasterItems)
            {
                item.Checked += item_Checked;
            }
        }

        void item_Checked(object sender, EventArgs e)
        {
            this.UpdateTotalQty();
        }

        ObservableCollection<MMasterItems> _MasterItems= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> MasterItems
        {
            get { return _MasterItems; }
            set
            {
                _MasterItems = value;
                AttatchEvent();
                Notify("MasterItems");
            }
        }

        ObservableCollection<MMasterItems> _VegItems= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> VegItems
        {
            get { return _VegItems; }
            set
            {
                _VegItems = value;
                Notify("VegItems");
            }
        }

        ObservableCollection<MMasterItems> _NonVegItems = new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> NonVegItems
        {
            get { return _NonVegItems; }
            set
            {
                _NonVegItems = value;
                Notify("NonVegItems");
            }
        }

        ObservableCollection<MMasterItems> _Drinks= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Drinks
        {
            get { return _Drinks; }
            set
            {
                _Drinks = value;
                Notify("Drinks");
            }
        }


        ObservableCollection<MMasterItems> _Cerials= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Cerials
        {
            get { return _Cerials; }
            set
            {
                _Cerials = value;
                Notify("Cerials");
            }
        }

        ObservableCollection<MMasterItems> _Fruits= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Fruits
        {
            get { return _Fruits; }
            set
            {
                _Fruits = value;
                Notify("Fruits");
            }
        }

        ObservableCollection<MMasterItems> _Nuts= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Nuts
        {
            get { return _Nuts; }
            set
            {
                _Nuts = value;
                Notify("Nuts");
            }
        }

        ObservableCollection<MMasterItems> _FastFoods= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> FastFoods
        {
            get { return _FastFoods; }
            set
            {
                _FastFoods = value;
                Notify("FastFoods");
            }
        }

        ObservableCollection<MMasterItems> _Spices= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Spices
        {
            get { return _Spices; }
            set
            {
                _Spices = value;
                Notify("Spices");
            }
        }

        ObservableCollection<MMasterItems> _Oils= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Oils
        {
            get { return _Oils; }
            set
            {
                _Oils = value;
                Notify("Oils");
            }
        }

        ObservableCollection<MMasterItems> _Personal= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Personal
        {
            get { return _Personal; }
            set
            {
                _Personal = value;
                Notify("Personal");
            }
        }

        ObservableCollection<MMasterItems> _Others= new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> Others
        {
            get { return _Others; }
            set
            {
                _Others = value;
                Notify("Others");
            }
        }
        double _TotalQty;
        public double TotalQty
        {
            get { return _TotalQty; }
            set
            {
                _TotalQty = value;
                Notify("TotalQty");
            }
        }

        public void UpdateTotalQty()
        {
            var Qty = this.MasterItems.Where(x => x.isChecked == true).Count();
            this.TotalQty = Qty;

        }


        string _SearchPattern;
        public string SearchPattern
        {
            get { return _SearchPattern; }
            set
            {
                _SearchPattern = value;
                Notify("SearchPattern");
            }
        }




    }
}
