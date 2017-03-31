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
    public partial class DashBoard : PhoneApplicationPage
    {
        public DashBoardVM Model
        {
            get
            {
                return (DashBoardVM)this.DataContext;
            }
        }
        public DashBoard()
        {
            InitializeComponent();
            this.Loaded += DashBoard_Loaded;
            Str_ViewNavigated.Completed += Str_ViewNavigated_Completed;
            this.BackKeyPress += DashBoard_BackKeyPress;
            UserProfileVW.Btn_Close.Click += Btn_Close_Click;

        }

        void Str_ViewNavigated_Completed(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(this.NavigationUri)))
            {
                NavigationService.Navigate(new Uri(this.NavigationUri, UriKind.Relative));
            }
        }

        void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Str_HideProfile.Begin();
        }

        void DashBoard_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TrnsUserProfile.ScaleX > 0)
            {
                e.Cancel = true;
                UserProfileVW.MaintainStates();
                Str_HideProfile.Begin();
            }
            else
            {
                if (MessageBox.Show("Are You Sure??", "You Want To Quit?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    App.Quit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        void DashBoard_Loaded(object sender, RoutedEventArgs e)
        {
            var data = Loginbase.CurrentUser;
            if (data != null)
            {
                Model.User = data;
            }
            else
            {
                NavigationService.GoBack();
            }

            Str_ViewInitiated.Begin();


        }

        private void LogOut()
        {
            if (MessageBox.Show("Are You Sure?", "You Want To Logout?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                NavigationService.GoBack();
            }
            else
            {

            }

        }




        private void Hub_Items_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.NavigationUri = "/Views/Masters/MasterItems.xaml";
            Str_ViewNavigated.Begin();
        }

        private void Hub_MUs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Add event handler implementation here.

            this.NavigationUri = "/Views/Masters/MasterMUs.xaml";
            Str_ViewNavigated.Begin();
        }

        private void Hub_Shop_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {


            this.NavigationUri = "/Views/Shopping/ShoppingHeader.xaml";
            Str_ViewNavigated.Begin();

        }

        private void Hub_Reprts_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            this.NavigationUri = "/Views/Reports/ShoppingReportView.xaml";
            Str_ViewNavigated.Begin();
        }

        private void Hub_Settings_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            this.NavigationUri = "/Views/AppSetting/AppSetting.xaml";
            Str_ViewNavigated.Begin();
        }

        private void Img_Edit_Account_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            UserProfileVW.MaintainStates();
            var data = Loginbase.CurrentUser;
            if (data != null)
            {
                UserProfileVW.Model.User = data;
            }
            Str_ShowProfile.Begin();
        }

        public string NavigationUri { get; set; }

        private void Hub_About_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            this.NavigationUri = "/Views/About/AboutApp.xaml";
            Str_ViewNavigated.Begin();
        }

        private void btn_Logout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            LogOut();
        }


    }
}