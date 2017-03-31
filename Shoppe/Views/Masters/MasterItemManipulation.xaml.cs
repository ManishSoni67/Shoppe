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
    public partial class MasterItemManipulation : UserControl
    {
        public MasterItemManipulationVM Model
        {
            get
            {
                return (MasterItemManipulationVM)this.DataContext;
            }
        }
        public MasterItemManipulation()
        {
            InitializeComponent();
            Model.ItemSaved += Model_ItemSaved;
            this.Model.Worker.DoWork += Worker_DoWork;

        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.AddorUpdateProductAsync());
        }

        public void InitiateView()
        {
            try
            {
                //lst_Picker_Cat.SelectedItem = Model.Types.FirstOrDefault();
                //Model.Item.Description = Model.Types.FirstOrDefault();
                //lst_Picker_MU.SelectedItem = Model.AllMUs.FirstOrDefault();
                //Model.Item.MUID = Model.AllMUs.FirstOrDefault().ID;
            }
            catch (Exception e)
            {

            }
        }

        void Model_ItemSaved(object sender, EventArgs e)
        {

            //Model.Status = "Item Saved";

            Notifications.Base.Controls.ShowSuccessTest(Model.Status);
            //VisualStateManager.GoToState(this, "SuccesBoxShow", true);

        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.


            MaintainState();

            Model.Item.Title = "";


        }

        private void Btn_Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            //VisualStateManager.GoToState(this, "SuccesBoxHide", true);
            //VisualStateManager.GoToState(this, "ErrorBoxHide", true);

        }

        private void Btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            MaintainState();
            if (Model.Validate())
            {

                Model.AddOrUpdateItems();
            }
            else
            {
                VisualStateManager.GoToState(this, "ErrorBoxShowUp", true);
            }
        }

        private void lst_Picker_Cat_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.


            var type = lst_Picker_Cat.SelectedItem;
            if (type != null)
            {
                var typ = type.ToString();
                Model.Item.Description = typ;
            }
        }

        private void lst_Picker_MU_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            var data = lst_Picker_MU.SelectedItem;
            if (data != null)
            {
                var MUitem = (MMUs)data;
                Model.Item.MUID = MUitem.ID;
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


        public void SetMasters(int? MUID = null, string _Type = null)
        {
            var MU = Model.AllMUs.FirstOrDefault(x => x.ID == (MUID ?? 0));
            if (MU != null)
            {
                lst_Picker_MU.SelectedItem = MU;
                Model.Item.MUID = MU.ID;
            }
            else
            {
                lst_Picker_MU.SelectedItem = Model.AllMUs.FirstOrDefault();
                Model.Item.MUID = Model.AllMUs.FirstOrDefault().ID;
            }
            var Type = Model.Types.FirstOrDefault(x => x.Equals(_Type ?? ""));
            if (Type != null)
            {
                lst_Picker_Cat.SelectedItem = Type;
                Model.Item.Description = Type;
            }
            else
            {
                lst_Picker_Cat.SelectedItem = Model.Types.FirstOrDefault();
                Model.Item.Description = Model.Types.FirstOrDefault();
            }

            Model.NotifyAll();
        }

    }
}
