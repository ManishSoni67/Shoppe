using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Shoppe.Notifications.Base
{
    public class Controls
    {
        static Controls()
        {
            AllPopups = new List<Popup>();
            //MainPopUp = new Popup();
            //MainPopUp.Loaded += (ss, ee) =>
            //{
            //    MainPopUp.Width = Application.Current.Host.Content.ActualWidth;
            //};
            //MainPopUp.Child = new Canvas();
            //(MainPopUp.Child as Canvas).Loaded += (ss, ee) =>
            //{
            //    (MainPopUp.Child as Canvas).Width = Application.Current.Host.Content.ActualWidth;
            //};
            //MainPopUp.VerticalOffset = Math.Round(Application.Current.Host.Content.ActualHeight, 0) - (65 + 0);
            //MainPopUp.HorizontalOffset = -5;
        }

        public static List<Popup> AllPopups { get; set; }

        //private static Popup MainPopUp { get; set; }

        public static Popup ShowSuccessTest(string MessageContent = "Message")
        {
            try
            {
                Popup pop = new Popup();
                pop.Tap += (ss, ee) =>
                {
                    pop.IsOpen = false;
                };
                var content = new Shoppe.Notifications.Views.SuccessToast(MessageContent);
                pop.Child = content;
                content.Loaded += (ss, ee) =>
                {
                    content.Initiate();
                };
                content.ClosePop += (ss, ee) =>
                {

                    pop.IsOpen = false;
                };
                //pop.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                pop.VerticalOffset = Math.Round(Application.Current.Host.Content.ActualHeight, 0) - (65 + 0);
                pop.HorizontalOffset = -5;

                pop.IsOpen = true;

                if (!(AllPopups.Contains(pop)))
                {
                    AllPopups.Add(pop);
                }
                //content.Initiate();
                return pop;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //public static void WaitForAllContentToBeClosed()
        //{
        //    try
        //    {
        //        var StillOpenViews = (MainPopUp.Child as Canvas).Children.OfType<Shoppe.Notifications.Views.SuccessToast>().Where(x => (x.IsOpen));
        //        if (StillOpenViews.Count() > 0)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            MainPopUp.IsOpen = false;
        //        }


        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
