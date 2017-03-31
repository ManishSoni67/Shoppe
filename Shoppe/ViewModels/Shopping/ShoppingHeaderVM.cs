using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Shoppe
{
    public class ShoppingHeaderVM : BaseModel
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
        public ShoppingHeaderVM()
        {
            InitializeDB();
            Oninit();
        }

        public override void Oninit()
        {
            base.Oninit();
            ShoppingGroups = new ObservableCollection<GroupItemsForChilds<MShopping>>();

        }

        public void GetAllShoppingData()
        {

            DoWorkAsync();

        }


        public void GetAllShoppingDataAsync()
        {
            try
            {

                int UsrID = Loginbase.CurrentUser.ID;
                this.AllShoppingData = new ObservableCollection<MShopping>();
                var Items = db.ShoppingItems.Where(x => x.UserID == UsrID).Select(x => new MMShopingItems()
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
                                  UnitRate = x.UnitRate,
                                  UserID = x.UserID,
                              }).ToList();
                var Data = db.ShoppingData.Where(x => x.UserID == UsrID).Select(x => new MShopping()
                {
                    ID = x.ID,
                    ShoppingDate = x.ForDate,
                    Title = x.Title,
                    UserID = x.UserID,
                    TotalAmount = x.TotalAmount,
                    TotalQty = x.Qty
                }).ToList();
                this.AllShoppingData = new ObservableCollection<MShopping>(Data);
                foreach (var line in this.AllShoppingData)
                {
                    ObservableCollection<MMShopingItems> Item = new ObservableCollection<MMShopingItems>();
                    Item = new ObservableCollection<MMShopingItems>(Items.Where(x => x.HeaderID == line.ID));
                    line.Items = Item;
                }

                GroupItemsFromData();
            }
            catch (Exception e)
            {

            }

            NotifyAll();
        }


        private void GroupItemsFromData()
        {
            try
            {
                if (AllShoppingData.Count == 0)
                {
                    return;
                }

                ShoppingGroups.Clear();
                var Grps = AllShoppingData.GroupBy(x => x.ShoppingDate);
                foreach (var grp in Grps)
                {
                    GroupItemsForChilds<MShopping> ShopGrp = new GroupItemsForChilds<MShopping>(string.Format("{0: dddd, MMM MM, yyyy}", grp.Key));
                    var Data = grp.OrderByDescending(x => x.ShoppingDate.TimeOfDay).ToList();
                    // ShopGrp.ItemCount = Data.Count;
                    var Sum = Data.Sum(x => x.TotalAmount);
                    ShopGrp.TotalSum = Sum;
                    Data.ForEach(x => ShopGrp.Add(x));
                    ShoppingGroups.Add(ShopGrp);
                }

            }
            catch (Exception e)
            {

            }
        }


        ObservableCollection<MShopping> _AllShoppingData = new ObservableCollection<MShopping>();
        public ObservableCollection<MShopping> AllShoppingData
        {
            get { return _AllShoppingData; }
            set
            {
                _AllShoppingData = value;
                Notify("AllShoppingData");
            }
        }


        public ObservableCollection<GroupItemsForChilds<MShopping>> ShoppingGroups
        { get; set; }

    }
}
