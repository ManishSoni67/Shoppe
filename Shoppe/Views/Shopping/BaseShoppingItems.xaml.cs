using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Shoppe
{
    public partial class BaseShoppingItems : PhoneApplicationPage
    {
        public BaseShoppingItemsVM Model
        {
            get 
            {
                return (BaseShoppingItemsVM)this.DataContext;
            }
        }

        public BaseShoppingItems()
        {
            InitializeComponent();
        }

        private void Btn_Done_Click(object sender, System.Windows.RoutedEventArgs e)
        {

          //  var Items = Model.MasterItems.Where(x => x.isChecked = true);
        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
           foreach(var item in Model.MasterItems)
           {
               item.isChecked = false;
              
               
           }
        }

        private void Btn_Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }


    }
}