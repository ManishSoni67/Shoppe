
using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Shoppe
{
    public class BaseMasters
    {
        public static List<MUs> GetAllMUs()
        {
            List<MUs> AllMUs = new List<MUs>();
            AllMUs.Add(new MUs() { ID = 1, Title = "Litre", UnitRate = 10, IsMaster = true, UpdatedOn = DateTime.Today, CreatedOn = DateTime.Today });
            AllMUs.Add(new MUs() { ID = 2, Title = "Kg", UnitRate = 10, IsMaster = true, UpdatedOn = DateTime.Today, CreatedOn = DateTime.Today });
            AllMUs.Add(new MUs() { ID = 3, Title = "Pack", UnitRate = 10, IsMaster = true, UpdatedOn = DateTime.Today, CreatedOn = DateTime.Today });
            return AllMUs;
        }

        public static List<MasterItem> GetAllItemsMasters()
        {
            List<MasterItem> ItemList = new List<MasterItem>();
            //Vegetables
            ItemList.Add(new MasterItem() { Title = "Onion", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Pea", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Potato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Sweet Potato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Cucumber", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Green Beans", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Spinach", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Flour", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Tomato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Ladyfinger", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Corn", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Carrot", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Radish", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Chilli", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Capcicum", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Non-Veg
            ItemList.Add(new MasterItem() { Title = "Chicken", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Mutton", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Fish", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Egg", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Beef", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Pork", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Drinks
            ItemList.Add(new MasterItem() { Title = "Juice", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Soda", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Soft-Drink", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Milk", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Mineral-Water", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Wine", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Whisky", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Others", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Cerials
            ItemList.Add(new MasterItem() { Title = "Pulses", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Rajma", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Grains", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Chana", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Rice", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Oats", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Beans", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Broken Wheat", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Coriander", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Barley", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Maize", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Fruits
            ItemList.Add(new MasterItem() { Title = "Apple", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Mango", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Grapes", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Bananas", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Pineapple", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Peache", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Dates", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Nuts
            ItemList.Add(new MasterItem() { Title = "Almonds", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Hazel Nuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Peanuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Walnuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });


            //Fast Food
            ItemList.Add(new MasterItem() { Title = "Noodle", Description = MasterItemType.FastFood, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Pasta", Description = MasterItemType.FastFood, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Spices
            ItemList.Add(new MasterItem() { Title = "Salt", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Pepper", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Cardamum", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Cinnamon", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Cloves", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Oils
            ItemList.Add(new MasterItem() { Title = "Vegetable Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Olive Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Mustard Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Personals
            ItemList.Add(new MasterItem() { Title = "Soap", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Shampoo", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Conditioner", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Face pack", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Face Wash", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Whitening Cream", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Others
            ItemList.Add(new MasterItem() { Title = "Chocolates", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Muffins", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Ice Cream", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Fruit Cake", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Candy", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { Title = "Soft Toy", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });


            return ItemList;

        }

        public static List<AppSettingColors> GetColorsList()
        {
            List<AppSettingColors> AppColors = new List<AppSettingColors>();
            AppColors.Add(new AppSettingColors() { ID = 1, Name = "Title", A = 255, R = 71, B = 71, G = 71 });
            AppColors.Add(new AppSettingColors() { ID = 2, Name = "SubTitle", A = 255, R = 120, B = 120, G = 120 });
            AppColors.Add(new AppSettingColors() { ID = 3, Name = "Success", A = 255, R = 71, B = 91, G = 180 });
            AppColors.Add(new AppSettingColors() { ID = 4, Name = "Invalid", A = 255, R = 191, B = 48, G = 48 });
            AppColors.Add(new AppSettingColors() { ID = 5, Name = "Notification", A = 255, R = 7, B = 95, G = 43 });
            AppColors.Add(new AppSettingColors() { ID = 6, Name = "Money", A = 255, R = 5, B = 255, G = 119 });
            return AppColors;
        }

        private void ResetColor(MAppSettingColors MC)
        {

            if (MC.ID == 1)
            {

                Base.DarkGrey.Color = Color.FromArgb(255, 71, 71, 71);

            }
            else if (MC.ID == 2)
            {
                Base.LightGrey.Color = Color.FromArgb(255, 120, 120, 120);
            }
            else if (MC.ID == 3)
            {

                Base.SuccessColor.Color = Color.FromArgb(255, 71, 180, 91);
            }
            else if (MC.ID == 4)
            {
                Base.InvalidColor.Color = Color.FromArgb(255, 191, 48, 48);
            }
            else if (MC.ID == 5)
            {
                Base.NotificationColor.Color = Color.FromArgb(255, 7, 43, 95);
            }
            else if (MC.ID == 6)
            {
                Base.MoneyColor.Color = Color.FromArgb(255, 5, 119, 255);
            }
        }


    }
}
