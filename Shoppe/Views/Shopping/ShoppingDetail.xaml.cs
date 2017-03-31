using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shoppe.Model;

namespace Shoppe
{
    public partial class ShoppingDetail : UserControl
    {
        public ShoppingDetailVM Model
        {
            get 
            {
                return (ShoppingDetailVM)this.DataContext;
            }
        }
        public ShoppingDetail()
        {
            InitializeComponent();
        }

        public void EquateMembers(MShopping Shop, double Qty, double Amount)
        {

            Model.Shopping = Shop;
            Model.QTY = Qty;
            Model.Amount = Amount;
            double Average = Math.Round((Amount / Qty),2);
            Model.Avg = Average;
 
        }


    }
}
