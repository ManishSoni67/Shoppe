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
    public partial class ShoppingHeader : PhoneApplicationPage
    {
        public ShoppingHeaderVM Model
        {
            get
            {
                return (ShoppingHeaderVM)this.DataContext;
            }
        }

        public ShoppingHeader()
        {
            InitializeComponent();
            this.Loaded += ShoppingHeader_Loaded;
            Model.Worker.DoWork += Worker_DoWork;
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.GetAllShoppingDataAsync());
        }


        void ShoppingHeader_Loaded(object sender, RoutedEventArgs e)
        {
            Model.GetAllShoppingData();
        }

        private void btn_Add_Shopping_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            NavigationService.Navigate(new Uri("/Views/Shopping/Shopping.xaml", UriKind.Relative));

        }

        private void Reload_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void Grd_Shop_Header_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Add event handler implementation here.
            var grd = sender as Grid;
            var data = (MShopping)grd.DataContext;
            if (data != null)
            {
                NavigationService.Navigate(new Uri("/Views/Shopping/ShoppingReadView.xaml?ID=" + data.ID, UriKind.Relative));
            }
        }


    }
}