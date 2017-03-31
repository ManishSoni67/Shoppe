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
    public partial class MasterMUs : PhoneApplicationPage
    {
        public MasterMUsVM Model
        {
            get
            {
                return (MasterMUsVM)this.DataContext;
            }
        }

        public MasterMUs()
        {
            InitializeComponent();
            this.BackKeyPress += MasterMUs_BackKeyPress;
            MUManipulationView.Btn_Close.Click += Btn_Close_Click;
            MUManipulationView.Model.MUSaved += Model_MUSaved;
            Model.Worker.DoWork += Worker_DoWork;
            Model.Initilizebase();
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.InitializebaseAsync());
        }

        void Model_MUSaved(object sender, EventArgs e)
        {
            Model.Initilizebase();
        }

        void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MUManipulationView.MaintainState();
            MUManipulationView.Model.MU = new MMUs();
            ApplicationBar.IsVisible = true;
            Showlayout.Begin();
        }

        void MasterMUs_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ScaleBorder.ScaleX > 0)
            {
                e.Cancel = true;
                ApplicationBar.IsVisible = true;
                Model.Initilizebase();
                Showlayout.Begin();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btn_Add_Masters_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            ApplicationBar.IsVisible = false;
            MUManipulationView.Model.Reset();
            MUManipulationView.Model.ViewTitleName = "Add New MU";
            Hidelayout.Begin();


        }

        private void Reload_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.

            Model.Initilizebase();


        }

        private void Select_MU(object sender, System.EventArgs e)
        {
            var img = sender as Image;
            var data = (MMUs)img.DataContext;
            if (data != null)
            {
                ApplicationBar.IsVisible = false;
                MUManipulationView.Model.ViewTitleName = "Update " + data.Title + " Details";
                MUManipulationView.Model.MU = data.GetNewObject<MMUs>();
                Hidelayout.Begin();
            }

        }




    }
}