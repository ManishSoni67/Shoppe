using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Shoppe
{
    public class MasterItemType
    {
        public static string Vegetable = "Vegetable";

        public static string NonVegetable = "Non-Vegetable";

        public static string Drinks = "Drinks";

        public static string Cerials = "Cerials";

        public static string Fruits = "Fruits";

        public static string Nuts = "Nuts";

        public static string FastFood = "Fast-Food";

        public static string Oils = "Oils";

        public static string Personal = "Personal";

        public static string Spices = "Spices";

        public static string Others = "Others";

        public static string[] GetAllMasterTypes()
        {
            string[] types = new string[] { Vegetable, NonVegetable, Drinks, Cerials, Fruits, Nuts, FastFood, Oils, Personal, Spices, Others };
            return types;
        }

        public static List<MAppSettingColors> GetAllColors()
        {
            List<MAppSettingColors> Colors = new List<MAppSettingColors>();

            MAppSettingColors darkgrey = new MAppSettingColors()
            {
                ID = 1,
                Name = "Titles",
                Color = Base.DarkGrey,

            };
            Colors.Add(darkgrey);
            MAppSettingColors lightgrey = new MAppSettingColors()
            {
                ID = 2,
                Name = "SubTitles",
                Color = Base.LightGrey,

            };
            Colors.Add(lightgrey);
            MAppSettingColors SuccessColor = new MAppSettingColors()
            {
                ID = 3,
                Name = "Success Operation",
                Color = Base.SuccessColor,

            };
            Colors.Add(SuccessColor);
            MAppSettingColors InvalidOperation = new MAppSettingColors()
            {
                ID = 4,
                Name = "Invalid Operation",
                Color = Base.InvalidColor,

            };
            Colors.Add(InvalidOperation);
            MAppSettingColors Notificatoions = new MAppSettingColors()
            {
                ID = 5,
                Name = "Notifications",
                Color = Base.NotificationColor,

            };
            Colors.Add(Notificatoions);

            MAppSettingColors AmountColor = new MAppSettingColors()
            {
                ID = 6,
                Name = "Amount",
                Color = Base.MoneyColor,

            };
            Colors.Add(AmountColor);

            return Colors;
        }


        public static List<MAppSettingColors> GetMasterColors()
        {
            List<MAppSettingColors> MasterColors = new List<MAppSettingColors>();

            MasterColors.Add(new MAppSettingColors() { ID = 1, Color = new SolidColorBrush(Colors.Gray), Name = "Grey" });
            MasterColors.Add(new MAppSettingColors() { ID = 2, Color = new SolidColorBrush(Colors.Green), Name = "Green" });
            MasterColors.Add(new MAppSettingColors() { ID = 3, Color = new SolidColorBrush(Colors.Red), Name = "Red" });
            MasterColors.Add(new MAppSettingColors() { ID = 4, Color = new SolidColorBrush(Colors.Yellow), Name = "Yellow" });
            MasterColors.Add(new MAppSettingColors() { ID = 5, Color = new SolidColorBrush(Colors.Orange), Name = "Orange" });
            MasterColors.Add(new MAppSettingColors() { ID = 6, Color = new SolidColorBrush(Colors.Magenta), Name = "Magenta" });
            MasterColors.Add(new MAppSettingColors() { ID = 7, Color = new SolidColorBrush(Colors.Purple), Name = "Purple" });
            MasterColors.Add(new MAppSettingColors() { ID = 8, Color = new SolidColorBrush(Colors.Brown), Name = "Brown" });
            MasterColors.Add(new MAppSettingColors() { ID = 9, Color = new SolidColorBrush(Colors.Cyan), Name = "Cyan" });

            MasterColors.Add(new MAppSettingColors() { ID = 10, Color = new SolidColorBrush(Colors.Transparent), Name = "Reset" });

            return MasterColors;
        }


    }


}
