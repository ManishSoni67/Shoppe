using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;
namespace Shoppe
{
   public class DashBoardVM:BaseModel
    {
       public DashBoardVM()
       {
           InitializeDB();
           GetCountforItems();
       }

       ShoppeDBContext db = null;
       private void InitializeDB()
       {
           string ConnectionString = App.ConnectionString;
           db = new ShoppeDBContext(ConnectionString);
           if (!db.DatabaseExists())
           {
               db.CreateDatabase();
           }
       }

       MUserInfo _User=new MUserInfo();
       public MUserInfo User
       {
           get { return _User; }
           set
           {
               _User = value;
               Notify("User");
           }
       }

       string _MasterItem;
       public string MasterItem
       {
           get { return _MasterItem; }
           set
           {
               _MasterItem = value;
               Notify("MasterItem");
           }
       }

       string _MUItems;
       public string MUItems
       {
           get { return _MUItems; }
           set
           {
               _MUItems = value;
               Notify("MUItems");
           }
       }

       public void GetCountforItems()
       {
           var Items = Base.AllItems;
           var ItemCount = Items.Count;

           this.MasterItem = "Master Item \nCount: " + ItemCount;

           var MuItems = Base.AllMUs;

           this.MUItems = "MU Item \nCount: " + MuItems.Count;

       }


    }
}
