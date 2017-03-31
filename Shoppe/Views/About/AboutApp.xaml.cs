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
using Microsoft.Phone.Tasks;

namespace Shoppe
{
    public partial class AboutApp : PhoneApplicationPage
    {
        public AboutAppVM Model
        {
            get 
            {
                return (AboutAppVM)this.DataContext;
            }
        }

        public AboutApp()
        {
            InitializeComponent();
            this.BackKeyPress += AboutApp_BackKeyPress;
            this.PaegLoaded.Begin();

        }

        void AboutApp_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.PageBack.Begin();

            this.PageBack.Completed += (ss, ee) => 
            {
                e.Cancel = false;
            };
    
        }

        private void Img_Link_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var img = sender as Image;
            var data = (MAboutAppLinks)img.DataContext;

            if (data != null)
            {
                var link = data.UrlLink;

               WebBrowserTask Task = new WebBrowserTask()
                {
                    URL = link
                };
                Task.Show();


            }
        }

        private void Img_Mail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var Email = Model.Dev.Email;
            EmailComposeTask Compose = new EmailComposeTask();
            Compose.To = Email;
            Compose.Show();
        }

        private void Hyp_Mail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var Email = Model.Dev.Email;
            EmailComposeTask Compose = new EmailComposeTask();
            Compose.To = Email;
            Compose.Show();
        }

        private void Hyp_Mail_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	 var Email = Model.Dev.Email;
            EmailComposeTask Compose = new EmailComposeTask();
            Compose.To = Email;
            Compose.Show();
        }

        private void Img_LinkedIn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string link = Model.Dev.LinkedInUrl;
            WebBrowserTask Task = new WebBrowserTask()
            {
                URL = link
            };
            Task.Show();

        }
    }
}