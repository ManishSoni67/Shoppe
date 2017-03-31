using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
namespace Shoppe.Model
{
    public class MShopping : BaseModel
    {
        public MShopping()
        {

        }




        public int ID { get; set; }

        DateTime _ShoppingDate = DateTime.Today;
        public DateTime ShoppingDate
        {
            get { return _ShoppingDate; }
            set
            {
                _ShoppingDate = value;
                Notify("ShoppingDate");
            }
        }

        public int UserID { get; set; }


        string _Title = "New Shopping";
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
                Notify("Title");
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


        ObservableCollection<MMShopingItems> _Items = new ObservableCollection<MMShopingItems>();
        public ObservableCollection<MMShopingItems> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                Notify("Items");
            }
        }

        public int TotalItems
        {
            get
            {
                try
                {
                    return Items.Count;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            set { }
        }


        public bool HaveItems
        {
            get
            {
                return TotalItems > 0;
            }
            set { }
        }

    }
}
