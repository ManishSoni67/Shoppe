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
using System.Windows.Media;

namespace Shoppe
{
    public partial class AppSetting : PhoneApplicationPage
    {
        public AppSettngVM Model
        {
            get
            {
                return (AppSettngVM)this.DataContext;
            }
        }


        public AppSetting()
        {
            InitializeComponent();
            this.BackKeyPress += AppSetting_BackKeyPress;
        }

        void AppSetting_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Trn_MasterColors.ScaleX > 0)
            {
                e.Cancel = true;
                Str_Hide_Master_Clrs.Begin();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Brd_Color_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                var brd = sender as Border;
                var data = (MAppSettingColors)brd.DataContext;
                if (data != null)
                {
                    SelectedColorBrush = data;
                    Str_Show_Master_Clrs.Begin();

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void Lst_MasterColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (SelectedColorBrush != null)
            {
                var data = (MAppSettingColors)(sender as ListBox).SelectedItem;
                if (data != null)
                {
                    if (data.ID < 10)
                    {
                        var C = data.Color;
                        ChangeColor(SelectedColorBrush, C.Color);
                    }
                    else 
                    {
                        ResetColor(SelectedColorBrush);
                    }
                    Str_Hide_Master_Clrs.Begin();
                }
            }
            (sender as ListBox).SelectedItem = null;
        }



        private void ChangeColor(MAppSettingColors MC, Color c)
        {
            if (MC.ID == 1)
            {

                Base.DarkGrey.Color = c;
                Model.UpdateColor(MC, Base.DarkGrey.Color);
                
            }
            else if (MC.ID == 2)
            {
                Base.LightGrey.Color = c;
                Model.UpdateColor(MC, Base.LightGrey.Color);
            }
            else if (MC.ID == 3)
            {
                Base.SuccessColor.Color = c;
                Model.UpdateColor(MC, Base.SuccessColor.Color);
            }
            else if (MC.ID == 4)
            {

                Base.InvalidColor.Color = c;
                Model.UpdateColor(MC, Base.InvalidColor.Color);
            }
            else if (MC.ID == 5)
            {
                Base.NotificationColor.Color = c;
                Model.UpdateColor(MC, Base.NotificationColor.Color);
            }
            else if (MC.ID == 6)
            {
                Base.MoneyColor.Color = c;
                Model.UpdateColor(MC, Base.MoneyColor.Color);
            }

        }

        private void ResetColor(MAppSettingColors MC)
        {

            if (MC.ID == 1)
            {
               
                Base.DarkGrey.Color = Color.FromArgb(255, 71, 71, 71);
                Model.UpdateColor(MC, Base.DarkGrey.Color);
               
            }
            else if (MC.ID == 2)
            {
                Base.LightGrey.Color = Color.FromArgb(255, 120, 120, 120);
                Model.UpdateColor(MC, Base.LightGrey.Color);
            }
            else if (MC.ID == 3)
            {

                Base.SuccessColor.Color = Color.FromArgb(255, 71, 180, 91);
                Model.UpdateColor(MC, Base.SuccessColor.Color);

            }
            else if (MC.ID == 4)
            {
                Base.InvalidColor.Color = Color.FromArgb(255, 191, 48, 48);
                Model.UpdateColor(MC, Base.InvalidColor.Color);
            }
            else if (MC.ID == 5)
            {
                Base.NotificationColor.Color = Color.FromArgb(255, 7, 43, 95);
                Model.UpdateColor(MC, Base.NotificationColor.Color);
            }
            else if (MC.ID == 6)
            {
                Base.MoneyColor.Color = Color.FromArgb(255,5,119,255);
                Model.UpdateColor(MC, Base.MoneyColor.Color);
            }
        }

        private void Btn_Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            foreach (var line in Model.AppColors)
            {
                ResetColor(line);
            }
        }
        MAppSettingColors SelectedColorBrush;

        

    }
}