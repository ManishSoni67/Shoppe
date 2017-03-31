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
    public partial class UserProfile : UserControl
    {
        public UserProfileVM Model
        {
            get
            {
                return (UserProfileVM)this.DataContext;
            }
        }

        public UserProfile()
        {
            InitializeComponent();
            var User = Loginbase.CurrentUser;
            if (User != null)
            {
                Model.User = User;
            }
        }

        private void Btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            MaintainStates();
            if (Model.Validate())
            {
                Model.Update();
                Model.Status = "User Updated Successfully";
                VisualStateManager.GoToState(this, "SuccessStart", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "InvalidStart", true);
            }



        }

        private void Btn_Close_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        public void MaintainStates()
        {
            Model.Status = "";

            if (Brd_InvalidProgress.Opacity > 0.0)
            {
                VisualStateManager.GoToState(this, "InvalidStop", true);
            }
            if (Brd_SuccessProgress.Opacity > 0.0)
            {

                VisualStateManager.GoToState(this, "SuccessStop", true);
            }
        }
    }
}
