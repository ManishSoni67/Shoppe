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
    public partial class UserRegistration : UserControl
    {

        public UserRegistrationVM Model
        {
            get
            {
                return (UserRegistrationVM)this.DataContext;
            }
        }
        public event EventHandler CloseView;
        public void RaiseCloseView()
        {
            if (this.CloseView != null)
            {
                this.CloseView(this, new EventArgs() { });
            }
        }

        public UserRegistration()
        {
            InitializeComponent();
            Model.DuplicateUserFound += Model_DuplicateUserFound;
            Model.SavedCompleted += Model_SavedCompleted;
            StrUserSaved.Completed += StrUserSaved_Completed;
            Model.Worker.DoWork += Worker_DoWork;
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model._AddUser());
        }

        void StrUserSaved_Completed(object sender, EventArgs e)
        {
            //Model.User = new MUserInfo();
        }

        void Model_SavedCompleted(object sender, LoginParams e)
        {
            Model.Status = "Registration is Completed !";
            Model.Reset();
            // StrUserSaved.Begin();
            Shoppe.Notifications.Base.Controls.ShowSuccessTest(Model.Status);
            RaiseCloseView();
        }

        void Model_DuplicateUserFound(object sender, EventArgs e)
        {

            Model.Status = "User Already Exists";
            VisualStateManager.GoToState(this, "AuthorizationStop", true);

        }

        private void Btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Model.Validate())
            {
                //Shoppe.Notifications.Base.Controls.ShowSuccessTest();

                VisualStateManager.GoToState(this, "AuthorStart", true);
                Model.AddUser();
            }
            else
            {
                VisualStateManager.GoToState(this, "AuthorizationStop", true);
            }

        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Reset();
            RaiseCloseView();
        }

        public void Reset()
        {
            Model.Reset();
            VisualStateManager.GoToState(this, "AuthorStart", true);
            this.StrUserControlClosed.Begin();
        }

        private void Brd_InvalidProgress_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VisualStateManager.GoToState(this, "AuthorStart", true);
        }

    }
}
