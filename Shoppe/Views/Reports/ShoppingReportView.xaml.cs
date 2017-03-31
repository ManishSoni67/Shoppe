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
    public partial class ShoppingReportView : PhoneApplicationPage
    {
        public ShoppingReportViewVM Model
        {
            get 
            {
                return (ShoppingReportViewVM)this.DataContext;
            }
        }
        public ShoppingReportView()
        {
            InitializeComponent();
            Model.InitializeMasters();
            SelectFirst();
            SelectFirstDate();


        }

        private void SelectFirstDate()
        {
            Model.LoadAllShoppingData();
        }

        private void SelectFirst()
        {
            var item = Lst_ShopItems.Items.OfType<MShopping>().FirstOrDefault();
            if (item != null)
            {
                Lst_ShopItems.SelectedItem = item;
                Model.LoadShoppingData(item.ID);
            }
        }

     

        private void SdatePicker_ValueChanged(object sender, Microsoft.Phone.Controls.DateTimeValueChangedEventArgs e)
        {
            var date = sender as DatePicker;
            var Sdate = date.Value;
            if (Sdate.HasValue)
            {
                Model.SDate = Sdate.Value;
                Model.LoadAllShoppingData();
            }
            else 
            {
                MessageBox.Show("Invalid Date Selected");
            }
        }

        private void Lst_ShopItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var lst = sender as ListPicker;
            var data = (MShopping)lst.SelectedItem;
            if (data != null)
            {
                Model.LoadShoppingData(data.ID);
            }
        }
    }
}