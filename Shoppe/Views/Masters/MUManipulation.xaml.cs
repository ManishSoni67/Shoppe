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
    public partial class MUManipulation : UserControl
    {
        public MUManipulationVM Model
        {
            get
            {
                return (MUManipulationVM)this.DataContext;
            }
        }

        public MUManipulation()
        {
            InitializeComponent();
            this.Model.MUSaved += Model_MUSaved;
            this.Model.SomeError += Model_SomeError;
            Model.Worker.DoWork += Worker_DoWork;
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model.SaveAsync());
        }

        void Model_SomeError(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(this, "ErrorShowUp", true);
        }

        void Model_MUSaved(object sender, EventArgs e)
        {
            Model.Status = "MU Saved Successfully";
            Notifications.Base.Controls.ShowSuccessTest(Model.Status);
            // VisualStateManager.GoToState(this, "SuccesBoxShow", true);

        }

        private void Btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MaintainState();
            Model.Save();

        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            MaintainState();
            Model.MU.Title = "";
        }

        public void MaintainState()
        {

            if (Brd_SuccessProgress.Opacity > 0)
            {
                VisualStateManager.GoToState(this, "SuccesBoxHide", true);
            }

            if (Brd_InvalidProgress.Opacity > 0)
            {
                VisualStateManager.GoToState(this, "ErrorHide", true);

            }

        }
    }
}
