using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Shoppe
{
   public class ShoppingVM:BaseModel
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
       public ShoppingVM()
       {
           InitializeDB();
           Oninit();
       }
       public event EventHandler ShopCompleted;
       public void RaiseShopCompleted()
       {
           if (ShopCompleted != null)
               ShopCompleted(this, new EventArgs());
       }

       private void Oninit()
       {
           
       }

       public void LoadMasters()
       {
           
           this.VegItems = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Vegetable)));
           this.NonVegItems = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.NonVegetable)));
           this.Fruits = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Fruits)));
           this.Spices = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Spices)));
           this.Cerials = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Cerials)));
           this.Drinks = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Drinks)));
           this.FastFoods = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.FastFood)));
           this.Nuts = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Nuts)));
           this.Oils = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Oils)));
           this.Personal = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Personal)));
           this.Others = new ObservableCollection<MMShopingItems>(this.MasterItems.Where(x => x.Description.Equals(MasterItemType.Others)));

           EvaluateLineID();
           this.UpdateTotalQty();
      
       }

       public void NotifyAll()
       {
           Notify("VegItems");
           Notify("NonVegItems");
           Notify("Fruits");
           Notify("Spices");
           Notify("Cerials");
           Notify("Drinks");
           Notify("FastFoods");
           Notify("Nuts");
           Notify("Oils");
           Notify("Personal");
           Notify("Others");
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

       public void DeleteMasterItem(int ID)
       {
           var item = this.MasterItems.SingleOrDefault(x => x.LineID == ID);
           if (item != null)
           {
               this.MasterItems.Remove(item);
           }
       }

       public void SaveShopping()
       {
           var user = Loginbase.CurrentUser;
           this.Shopping.TotalAmount = this.MasterItems.Sum(x => x.Amount);
           this.Shopping.TotalQty = this.MasterItems.Count;
           ShoppingData dta = new ShoppingData()
           {
               ForDate= this.Shopping.ShoppingDate,
               Title= this.Shopping.Title,
               UserID= user.ID,
               TotalAmount=this.Shopping.TotalAmount,
               Qty= this.Shopping.TotalQty
              
           };
           db.ShoppingData.InsertOnSubmit(dta);
           db.SubmitChanges();
           var ID = dta.ID;
           foreach( var item in this.MasterItems)
           {
               ShoppingItems itm = new ShoppingItems()
               {
                   HeaderID = ID,
                   MUID = item.MUID,
                   CreatedOn = DateTime.Today,
                   Amount = item.Amount,
                   Name = item.Name,
                   Qty = item.Qty,
                   Revision = 1,
                   UnitRate = item.UnitRate,
                   UpdatedOn = DateTime.Today,
                   UserID = user.ID,
                   Description= item.Description,
               };
               db.ShoppingItems.InsertOnSubmit(itm);
               db.SubmitChanges();
           }
           RaiseShopCompleted();
 
       }
       
       MShopping _Shopping= new MShopping();
       public MShopping Shopping
       {
           get { return _Shopping; }
           set
           {
               _Shopping = value;
               Notify("Shopping");
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

       ObservableCollection<MMShopingItems> _VegItems = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> VegItems
       {
           get { return _VegItems; }
           set
           {
               _VegItems = value;
               Notify("VegItems");
           }
       }

       ObservableCollection<MMShopingItems> _NonVegItems = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> NonVegItems
       {
           get { return _NonVegItems; }
           set
           {
               _NonVegItems = value;
               Notify("NonVegItems");
           }
       }

       ObservableCollection<MMShopingItems> _Drinks = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Drinks
       {
           get { return _Drinks; }
           set
           {
               _Drinks = value;
               Notify("Drinks");
           }
       }


       ObservableCollection<MMShopingItems> _Cerials = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Cerials
       {
           get { return _Cerials; }
           set
           {
               _Cerials = value;
               Notify("Cerials");
           }
       }

       ObservableCollection<MMShopingItems> _Fruits = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Fruits
       {
           get { return _Fruits; }
           set
           {
               _Fruits = value;
               Notify("Fruits");
           }
       }

       ObservableCollection<MMShopingItems> _Nuts = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Nuts
       {
           get { return _Nuts; }
           set
           {
               _Nuts = value;
               Notify("Nuts");
           }
       }

       ObservableCollection<MMShopingItems> _FastFoods = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> FastFoods
       {
           get { return _FastFoods; }
           set
           {
               _FastFoods = value;
               Notify("FastFoods");
           }
       }

       ObservableCollection<MMShopingItems> _Spices = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Spices
       {
           get { return _Spices; }
           set
           {
               _Spices = value;
               Notify("Spices");
           }
       }

       ObservableCollection<MMShopingItems> _Oils = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Oils
       {
           get { return _Oils; }
           set
           {
               _Oils = value;
               Notify("Oils");
           }
       }

       ObservableCollection<MMShopingItems> _Personal = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Personal
       {
           get { return _Personal; }
           set
           {
               _Personal = value;
               Notify("Personal");
           }
       }

       ObservableCollection<MMShopingItems> _Others = new ObservableCollection<MMShopingItems>();
       public ObservableCollection<MMShopingItems> Others
       {
           get { return _Others; }
           set
           {
               _Others = value;
               Notify("Others");
           }
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

       public void UpdateTotalQty()
       {
           var Qty = this.MasterItems.Count();
           this.TotalQty = Qty;

       }





    }
}
