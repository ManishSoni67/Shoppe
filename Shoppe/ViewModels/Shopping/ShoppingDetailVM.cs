using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;
namespace Shoppe
{
    public class ShoppingDetailVM:BaseModel
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

        public ShoppingDetailVM()
        {
            InitializeDB();
            Oninit();
        }

        private void Oninit()
        {
            
            
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




        double _QTY;
        public double QTY
        {
            get { return _QTY; }
            set
            {
                _QTY = value;
                Notify("QTY");
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

        double _Avg;
        public double Avg
        {
            get { return _Avg; }
            set
            {
                _Avg = value;
                Notify("Avg");
            }
        }

        bool _IsNotReady=true;
        public bool IsNotReady
        {
            get { return _IsNotReady; }
            set
            {
                _IsNotReady = value;
                Notify("IsNotReady");
            }
        }



     

    }
}
