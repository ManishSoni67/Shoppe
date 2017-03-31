using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Shoppe.Notifications.Views
{
    public partial class SuccessToast : UserControl
    {
        public event EventHandler ClosePop;
        public void RaiseClosePopup()
        {
            if (this.ClosePop != null)
            {
                ClosePop(this, new EventArgs());
            }
        }

        public SuccessToast()
        {
            InitializeComponent();
            InitiateAnimation.Completed += InitiateAnimation_Completed;
            DisposeAnimation.Completed += DisposeAnimation_Completed;
            IsOpen = true;
        }

        public SuccessToast(string Message)
            : this()
        {
            this.txt_Content.Text = Message;
        }

        void DisposeAnimation_Completed(object sender, EventArgs e)
        {
            RaiseClosePopup();
        }

        void InitiateAnimation_Completed(object sender, EventArgs e)
        {
            InitiateTimer();
        }

        public void InitiateTimer()
        {
            Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 0, 1, 500);
            Timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {

            Timer.Stop();
            DisposeAnimation.Begin();

        }

        public DispatcherTimer Timer { get; set; }

        public Storyboard InitiateAnimation
        {
            get
            {
                return this.GetDesiredChild<Storyboard>("Str_ShowNotification");
            }
            set { }
        }
        public Storyboard DisposeAnimation
        {
            get
            {
                return this.GetDesiredChild<Storyboard>("Str_HideNotification");
            }
            set { }
        }

        public bool IsOpen { get; set; }


        public void Initiate()
        {
            InitiateAnimation.Begin();
        }

        public T GetDesiredChild<T>(string Key) where T : class
        {
            try
            {
                return this.Resources[Key] as T;
            }
            catch (Exception ee)
            {
                return null;
            }
        }




    }
}
