using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Shoppe
{
    public class Base
    {

        public static List<MMUs> AllMUs
        {
            get
            {
                return (List<MMUs>)App.Current.Resources["AllMUs"];
            }
        }

        public static List<MMasterItems> AllItems
        {
            get
            {
                return (List<MMasterItems>)App.Current.Resources["AllItems"];
            }
        }


        public static void ReloadMasterItems()
        {
            var items = (List<MMasterItems>)App.Current.Resources["AllItems"];
            if (items != null)
            {
                App.Current.Resources.Remove("AllItems");
                ShoppeDBContext db = new ShoppeDBContext(App.ConnectionString);
                if (!(db.DatabaseExists()))
                {
                    db.CreateDatabase();
                }
                var Masters = db.MasterItems.Select(x => x).ToList();
                List<MMasterItems> Items = new List<MMasterItems>();
                Items = new List<MMasterItems>(Masters.Select(x => new MMasterItems() { ID = x.ID, Title = x.Title, MUID = x.MUID, PicPath = x.PicPath, IsMaster = x.IsMaster, CreatedOn = x.CreatedOn, UpdatedOn = x.UpdatedOn, Description = x.Description }));
                var data = App.Current.Resources["AllItems"];
                if (data == null)
                {
                    App.Current.Resources.Add("AllItems", Items);
                }

            }
        }
        public static void ReloadAllMUs()
        {
            //App.Current.Resources.Remove("AllMUs");
            ShoppeDBContext db = new ShoppeDBContext(App.ConnectionString);
            if (!(db.DatabaseExists()))
            {
                db.CreateDatabase();
            }
            var MUItems = (List<MMUs>)App.Current.Resources["AllMUs"];
            if (MUItems != null)
            {
                App.Current.Resources.Remove("AllMUs");
                var Mu = db.MUss.Select(x => x).ToList();
                List<MMUs> MUList = new List<MMUs>();
                MUList = new List<MMUs>(Mu.Select(x => new MMUs() { ID = x.ID, Title = x.Title, IsMaster = x.IsMaster, UnitRate = x.UnitRate, CreatedOn = x.CreatedOn, UpdatedOn = x.UpdatedOn }));
                var MUitem = App.Current.Resources["AllMUs"];
                if (MUitem == null)
                {
                    App.Current.Resources.Add("AllMUs", MUList);
                }

            }
        }


        public static SolidColorBrush DarkGrey
        {
            get
            {
                return App.Current.Resources["darkGray"] as SolidColorBrush;
            }
        }

        public static SolidColorBrush LightGrey
        {
            get
            {
                return App.Current.Resources["LightGrey"] as SolidColorBrush;
            }
        }
        public static SolidColorBrush SuccessColor
        {
            get
            {
                return App.Current.Resources["SuccessColor"] as SolidColorBrush;
            }
        }

        public static SolidColorBrush InvalidColor
        {
            get
            {
                return App.Current.Resources["InvalidBackground"] as SolidColorBrush;
            }
        }
        public static SolidColorBrush NotificationColor
        {
            get
            {
                return App.Current.Resources["NotificationColor"] as SolidColorBrush;
            }
        }
        public static SolidColorBrush MoneyColor
        {
            get
            {
                return App.Current.Resources["ClrMoneyColor"] as SolidColorBrush;
            }
        }


        public static void EquateColors(IEnumerable<AppSettingColors> AppColors)
        {
            foreach (var color in AppColors)
            {

                if (color.ID == 1)
                {
                    Base.DarkGrey.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else if (color.ID == 2)
                {

                    Base.LightGrey.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else if (color.ID == 3)
                {
                    Base.SuccessColor.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else if (color.ID == 4)
                {
                    Base.InvalidColor.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else if (color.ID == 5)
                {
                    Base.NotificationColor.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else if (color.ID == 6)
                {
                    Base.MoneyColor.Color = Color.FromArgb(color.A, color.R, color.G, color.B);
                }

            }

        }


    }
}
