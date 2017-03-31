using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Shoppe.Model;

namespace Shoppe
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        public MainPageVM Model
        {
            get
            {
                return (MainPageVM)this.DataContext;
            }
        }
        public MainPage()
        {
            InitializeComponent();
            //RegForm.StrUserSaved.Completed += StrUserSaved_Completed;
            RegForm.CloseView += RegForm_CloseView;
            RegForm.Model.SavedCompleted += Model_SavedCompleted;
            Model.UserLogged += Model_UserLogged;
            Model.UserNotAutherized += Model_UserNotAutherized;
            StrUserlogin.Completed += StrUserlogin_Completed;
            this.BackKeyPress += MainPage_BackKeyPress;
            this.Loaded += MainPage_Loaded;
            Model.Worker.DoWork += Worker_DoWork;
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model._CheckForUser());
        }

        void Model_UserNotAutherized(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(this, "AuthurizeStop", true);
        }

        void Model_SavedCompleted(object sender, LoginParams e)
        {
            e.EquateProps(this.Model.User);
            VisualStateManager.GoToState(this, "AuthurizeStart", true);


        }

        void RegForm_CloseView(object sender, EventArgs e)
        {
            StrHideRegForm.Begin();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "AuthurizeStart", true);
            Model.User.Password = "";
        }

        void StrUserlogin_Completed(object sender, EventArgs e)
        {
            NavigateToHomeScreen();
        }

        void Model_UserLogged(object sender, EventArgs e)
        {
            Model.Status = "User is logged in";
            var user = App.Current.Resources["User"];
            if (user == null)
            {
                App.Current.Resources.Add("User", Model.User);
            }
            Shoppe.Notifications.Base.Controls.ShowSuccessTest(Model.Status);
            NavigateToHomeScreen();
            // StrUserlogin.Begin();
        }

        void MainPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var trn = TrnsLoginFormScale;
            if (trn.ScaleX == 0)
            {
                StrHideRegForm.Begin();
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show("Are You Sure??", "You Want To Quit?", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        void StrUserSaved_Completed(object sender, EventArgs e)
        {
            RegForm.Reset();
            StrHideRegForm.Begin();
        }

        private void Btn_Registration_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.

            //StrShowRegForm.Begin();

        }

        private void Btn_Rate_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void Btn_AboutApp_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void Btn_Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            VisualStateManager.GoToState(this, "AuthurizeStart", true);

            // VisualStateManager.GoToState(this, "AuthurizeStart", true);
            Model.Autherize();

            //Shoppe.Notifications.Base.Controls.ShowSuccessTest(Model.Status);
        }

        private void Btn_Reg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.\
            StrShowRegForm.Begin();
        }

        private void Img_Shoppe_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {

                var link = "/Views/About/AboutApp.xaml";
                NavigationService.Navigate(new Uri(link, UriKind.Relative));
            }
            catch (Exception ee)
            {

            }
        }

        private void Brd_InvalidProgress_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VisualStateManager.GoToState(this, "AuthurizeStart", true);
        }


        private void NavigateToHomeScreen()
        {
            try
            {
                NavigationService.Navigate(new Uri("/Views/DashBoard/DashBoard.xaml", UriKind.Relative));
            }
            catch (Exception e)
            {

            }
        }
    }
}