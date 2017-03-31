using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;
namespace Shoppe
{
    public class ShoppingReportViewVM:BaseModel
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
        public ShoppingReportViewVM()
        {
            InitializeDB();
           
 
        }

       public void InitializeMasters()
        {
            var user = Loginbase.CurrentUser;
            var data = db.ShoppingData.Where(x => x.UserID == user.ID).ToList();
            if (data.Count>0)
            {
                this.AllShoppingRecord = new ObservableCollection<MShopping>(data.Select(x => new MShopping()
                {
                    ID = x.ID,
                    ShoppingDate = x.ForDate,
                    Title = x.Title,
                    UserID = x.UserID,
                    TotalAmount = x.TotalAmount,
                    TotalQty = x.Qty
                }));

                //var AllData = db.ShoppingData.Select(x => x).ToList();
                this.AllShoppingData = new ObservableCollection<ReportData>(data.Select(x => new ReportData() { Name = x.Title, Value = x.TotalAmount }));
                this.AllShopTotal = this.AllShoppingData.Sum(x => x.Value);
            }
            else
            {
                //this.AllShoppingData = new ObservableCollection<ReportData>();
                //this.AllShopTotal = 0.0;
 
            }
        }

      

        ObservableCollection<ReportData> _ShoppingRecord= new ObservableCollection<ReportData>();
        public ObservableCollection<ReportData> ShoppingRecord
        {
            get { return _ShoppingRecord; }
            set
            {
                _ShoppingRecord = value;
                Notify("ShoppingRecord");
            }
        }


        ObservableCollection<ReportData> _ShopRecord= new ObservableCollection<ReportData>();
        public ObservableCollection<ReportData> ShopRecord
        {
            get { return _ShopRecord; }
            set
            {
                _ShopRecord = value;
                Notify("ShopRecord");
            }
        }
        ObservableCollection<MShopping> _AllShoppingRecord= new ObservableCollection<MShopping>();
        public ObservableCollection<MShopping> AllShoppingRecord
        {
            get { return _AllShoppingRecord; }
            set
            {
                _AllShoppingRecord = value;
                Notify("AllShoppingRecord");
            }
        }

        ObservableCollection<ReportData> _AllShoppingData= new ObservableCollection<ReportData>();
        public ObservableCollection<ReportData> AllShoppingData
        {
            get { return _AllShoppingData; }
            set
            {
                _AllShoppingData = value;
                Notify("AllShoppingData");
            }
        }

        double _TotalAmount;
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set
            {
                _TotalAmount = value;
                Notify("TotalAmount");
            }
        }

        double _ShopTotalAmount;
        public double ShopTotalAmount
        {
            get { return _ShopTotalAmount; }
            set
            {
                _ShopTotalAmount = value;
                Notify("ShopTotalAmount");
            }
        }

        double _AllShopTotal;
        public double AllShopTotal
        {
            get { return _AllShopTotal; }
            set
            {
                _AllShopTotal = value;
                Notify("AllShopTotal");
            }
        }

        DateTime _SDate= DateTime.Today;
        public DateTime SDate
        {
            get { return _SDate; }
            set
            {
                _SDate = value;
                Notify("SDate");
            }
        }
        DateTime _EDate=DateTime.Today;
        public DateTime EDate
        {
            get { return _EDate; }
            set
            {
                _EDate = value;
                Notify("EDate");
            }
        }

        public void LoadAllShoppingData()
        {
            var user = Loginbase.CurrentUser;
            var data = db.ShoppingData.Where(x => x.UserID == user.ID).Where(x => DateTime.Compare(x.ForDate.Date,SDate)==0).ToList();
            if (data.Count>0)
            {
                this.ShoppingRecord = new ObservableCollection<ReportData>(data.Select(x => new ReportData() { Name = x.Title, Value = x.TotalAmount }));
                this.ShopTotalAmount = this.ShoppingRecord.Sum(x => x.Value);
            }
            else
            //{
            {
            //    this.ShoppingRecord = new ObservableCollection<ReportData>();
            //    this.ShopTotalAmount = 0.0;
            }
         
        }

        public void LoadShoppingData(int ID)
        {
            var shop = db.ShoppingData.SingleOrDefault(x => x.ID == ID);
            if (shop != null)
            {
                var shoppingItems = db.ShoppingItems.Where(x => x.HeaderID == ID).ToList();
                if (shoppingItems.Count > 0)
                {
                    this.ShopRecord = new ObservableCollection<ReportData>(shoppingItems.Select(x => new ReportData()
                    {
                        Name = x.Name,
                        Value = x.Amount
                    }));

                    this.TotalAmount = this.ShopRecord.Sum(x => x.Value);
                }
                else
                {
                    //this.ShopRecord = new ObservableCollection<ReportData>();
                    //this.TotalAmount = 0.0;
 
                }
            }

 
        }

        




    }
}
