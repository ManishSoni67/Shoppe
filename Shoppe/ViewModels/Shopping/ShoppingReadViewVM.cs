using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Shoppe
{
    public class ShoppingReadViewVM : BaseModel
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

        public ShoppingReadViewVM()
        {
            Oninit();
            InitializeDB();
        }

        public override void Oninit()
        {
            base.Oninit();
            GroupedShoppingItems = new ObservableCollection<GroupItemsForChilds<MMShopingItems>>();

        }
        public void LoadData()
        {
            DoWorkAsync();
        }


        public void LoadDataAsync()
        {
            try
            {
                var data = db.ShoppingData.SingleOrDefault(x => x.ID == Shopping.ID);
                if (data != null)
                {
                    Shopping.ID = data.ID;
                    Shopping.TotalAmount = data.TotalAmount;
                    Shopping.TotalQty = data.Qty;
                    Shopping.UserID = data.UserID;
                    Shopping.Title = data.Title;
                    Shopping.ShoppingDate = data.ForDate;
                }
                var datline = db.ShoppingItems.Where(x => x.HeaderID == Shopping.ID);
                if (datline != null)
                {
                    this.MasterItems = new ObservableCollection<MMShopingItems>(datline.Select(x => new MMShopingItems()
                    {
                        ID = x.ID,
                        MUID = x.MUID,
                        Amount = x.Amount,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        UpdatedOn = x.UpdatedOn,
                        Revision = x.Revision,
                        HeaderID = x.HeaderID,
                        Qty = x.Qty,
                        Description = x.Description,
                        UnitRate = x.UnitRate,
                        UserID = x.UserID,
                    }));

                    this.LoadMasters();
                }
            }
            catch (Exception e)
            {

            }


            NotifyAll();
        }


        public void LoadMasters()
        {

            try
            {
                if (this.MasterItems.Count == 0) { return; }
                GroupedShoppingItems.Clear();
                EvaluateLineID();
                this.UpdateTotalQty();
                var GroupedData = this.MasterItems.GroupBy(x => x.Description);
                foreach (var Grp in GroupedData)
                {
                    GroupItemsForChilds<MMShopingItems> ItemGrp = new GroupItemsForChilds<MMShopingItems>(Grp.Key);
                    var Data = Grp.OrderByDescending(x => x.Qty).ToList();
                    var Sum = Data.Sum(x => x.Amount);
                    ItemGrp.TotalSum = Sum;
                    Data.ForEach(x => ItemGrp.Add(x));
                    GroupedShoppingItems.Add(ItemGrp);
                }

            }
            catch (Exception e)
            {

            }
        }

        public void EvaluateLineID()
        {
            int i = 0;

            if (this.MasterItems.Count > 0)
            {
                foreach (var line in MasterItems)
                {
                    line.LineID = ++i;
                }

            }

        }

        MShopping _Shopping = new MShopping();
        public MShopping Shopping
        {
            get { return _Shopping; }
            set
            {
                _Shopping = value;
                Notify("Shopping");
            }
        }




        ObservableCollection<MMShopingItems> _MasterItems = new ObservableCollection<MMShopingItems>();
        public ObservableCollection<MMShopingItems> MasterItems
        {
            get { return _MasterItems; }
            set
            {
                _MasterItems = value;
                Notify("MasterItems");
            }
        }

        public ObservableCollection<GroupItemsForChilds<MMShopingItems>> GroupedShoppingItems { get; set; }

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


        public double TotalSum { get; set; }

        public double Average { get { return Math.Round(TotalSum / TotalQty, 2); } set { } }


        public void UpdateTotalQty()
        {

            var Qty = this.MasterItems.Count();
            this.TotalQty = Qty;
            var Sum = MasterItems.Sum(x => x.Amount);
            TotalSum = Sum;
        }


    }
}
