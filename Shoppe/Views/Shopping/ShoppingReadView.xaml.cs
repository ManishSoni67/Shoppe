using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{
    public partial class ShoppingReadView : PhoneApplicationPage
    {
        public ShoppingReadViewVM Model
        {
            get
            {
                return (ShoppingReadViewVM)this.DataContext;
            }
        }
        public ShoppingReadView()
        {
            InitializeComponent();
            this.Loaded += ShoppingReadView_Loaded;
            this.BackKeyPress += ShoppingReadView_BackKeyPress;
            Model.Worker.DoWork += Worker_DoWork;
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.LoadDataAsync());
        }

        void ShoppingReadView_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pvt_Master.IsEnabled = true;
            ApplicationBar.IsVisible = true;

            if (Trns_BaseShoppingDetail.ScaleX > 0)
            {
                e.Cancel = true;
                Str_HideShopDetail.Begin();
            }
            else if (Trns_BaseShoppingReport.ScaleX > 0)
            {
                e.Cancel = true;
                Str_HideShopReport.Begin();
            }
            else
            {
                e.Cancel = false;
            }
        }

        void ShoppingReadView_Loaded(object sender, RoutedEventArgs e)
        {
            var ID = int.Parse(NavigationContext.QueryString["ID"]);
            Model.Shopping.ID = ID;
            Model.LoadData();
        }

        private void Btn_ShowReport_Click(object sender, System.EventArgs e)
        {
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            VWShoppingReport.Model.ViewTitle = this.Model.Shopping.Title;
            VWShoppingReport.Model.ReportData = new ObservableCollection<ReportData>(Model.MasterItems.Select(x => new ReportData()
            {
                Name = x.Name,
                Value = x.Amount
            }));
            double SUM = VWShoppingReport.Model.ReportData.Sum(x => x.Value);
            VWShoppingReport.Model.Amount = Math.Round(SUM, 2);
            Str_ShowShopReport.Begin();
        }

        private void btn_Back_Click(object sender, System.EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Btn_Prievew_Click(object sender, System.EventArgs e)
        {
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            var Qty = Model.MasterItems.Sum(x => x.Qty);
            var Amount = Model.MasterItems.Sum(x => x.Amount);
            VWShoppingDetails.EquateMembers(Model.Shopping, Qty, Amount);
            VWShoppingDetails.Txt_Name.IsReadOnly = true;
            Str_ShowShopDetail.Begin();
        }
    }
}