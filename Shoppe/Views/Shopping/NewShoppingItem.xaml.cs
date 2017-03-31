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
    public partial class NewShoppingItem : PhoneApplicationPage
    {

        public NewShoppingItemVM Model
        {
            get 
            {
                return (NewShoppingItemVM)this.DataContext;
            }
        }
        public NewShoppingItem()
        {
            InitializeComponent();
            Model.ItemSaved += Model_ItemSaved;
        }

        void Model_ItemSaved(object sender, EventArgs e)
        {

            Model.Status = "Item Saved";

            VisualStateManager.GoToState(this, "SuccesBoxShow", true);
        }

        private void lst_Picker_Cat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        	// TODO: Add event handler implementation here.

            var type = lst_Picker_Cat.SelectedItem;
            if (type != null)
            {
                var typ = type.ToString();
                Model.ShoppingItem.Description = typ;
            }
        }

        private void Btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MaintainState();
            if (Model.Validate())
            {

                Model.ReflectChange();
            }
            else
            {
                VisualStateManager.GoToState(this, "ErrorBoxShowUp", true);
            }
        	
        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Model.ShoppingItem.Name = "";
            Model.ShoppingItem.Qty = 0;
            Model.ShoppingItem.UnitRate = 0;
        }

        private void Btn_Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
          
        }

        private void lst_Picker_MU_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var data = lst_Picker_MU.SelectedItem;
            if (data != null)
            {
                var MUitem = (MMUs)data;
                Model.ShoppingItem.MUID = MUitem.ID;
            }
        }

        public void MaintainState()
        {

            if (Brd_SuccessProgress.Opacity > 0)
            {
                VisualStateManager.GoToState(this, "SuccesBoxHide", true);
            }

            if (Brd_InvalidProgress.Opacity > 0)
            {
                VisualStateManager.GoToState(this, "ErrorBoxHide", true);

            }

        }

        public void MapMUIDandType()
        {
            var MU = this.lst_Picker_MU.Items.OfType<MMUs>().SingleOrDefault(x => x.ID == this.Model.ShoppingItem.MUID);
            if (MU!=null)
            {
                lst_Picker_MU.SelectedItem = MU;
            }
            var type = this.lst_Picker_Cat.Items.SingleOrDefault(x => x.ToString().Equals(this.Model.ShoppingItem.Description));
            if (type != null)
            {
                lst_Picker_Cat.SelectedItem = type;
            }

        }

        public void SelectFirstElements()
        {
            var MU = this.lst_Picker_MU.Items.OfType<MMUs>().FirstOrDefault();
            if (MU != null)
            {
                lst_Picker_MU.SelectedItem = MU;
                Model.ShoppingItem.MUID = MU.ID;
            }
            var type = this.lst_Picker_Cat.Items.FirstOrDefault();
            if (type != null)
            {
                lst_Picker_Cat.SelectedItem = type;
                Model.ShoppingItem.Description = type.ToString();
            }
        }

         
    }
}