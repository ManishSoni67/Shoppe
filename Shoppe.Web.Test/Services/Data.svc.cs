using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Shoppe.Model;
namespace Shoppe.Web.Test.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Data" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Data.svc or Data.svc.cs at the Solution Explorer and start debugging.
    public class Data : IData
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
            int i = 0;
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Onion", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pea", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Potato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Sweet Potato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Cucumber", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Green Beans", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Spinach", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Flour", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Tomato", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Ladyfinger", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Corn", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Carrot", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Radish", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Chilli", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Capcicum", Description = MasterItemType.Vegetable, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Non-Veg
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Chicken", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Mutton", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Fish", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Egg", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Beef", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pork", Description = MasterItemType.NonVegetable, IsVeg = false, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Drinks
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Juice", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Soda", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Soft-Drink", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Milk", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Mineral-Water", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Wine", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Whisky", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Others", Description = MasterItemType.Drinks, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Cerials
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pulses", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Rajma", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Grains", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Chana", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Rice", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Oats", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Beans", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Broken Wheat", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Coriander", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Barley", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Maize", Description = MasterItemType.Cerials, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Fruits
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Apple", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Mango", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Grapes", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Bananas", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pineapple", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Peache", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Dates", Description = MasterItemType.Fruits, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Nuts
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Almonds", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Hazel Nuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Peanuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Walnuts", Description = MasterItemType.Nuts, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });


            //Fast Food
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Noodle", Description = MasterItemType.FastFood, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pasta", Description = MasterItemType.FastFood, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Spices
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Salt", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Pepper", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Cardamum", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Cinnamon", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Cloves", Description = MasterItemType.Spices, IsVeg = true, IsMaster = true, MUID = 2, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Oils
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Vegetable Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Olive Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Mustard Oil", Description = MasterItemType.Oils, IsVeg = true, IsMaster = true, MUID = 1, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Personals
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Soap", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Shampoo", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Conditioner", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Face pack", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Face Wash", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Whitening Cream", Description = MasterItemType.Personal, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });

            //Others
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Chocolates", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Muffins", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Ice Cream", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Fruit Cake", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Candy", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });
            ItemList.Add(new MasterItem() { ID = ++i, Title = "Soft Toy", Description = MasterItemType.Others, IsVeg = true, IsMaster = true, MUID = 3, CreatedOn = DateTime.Today, PicPath = null, UpdatedOn = DateTime.Today });


            return ItemList;

        }

        public IEnumerable<MasterItem> GetAllMasterItems()
        {
            return GetAllItemsMasters();
        }

        IEnumerable<MUs> IData.GetAllMUs()
        {
            return GetAllMUs();
        }
    }

    [DataContract]
    public class MasterItem
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool IsMaster { get; set; }

        [DataMember]
        public int MUID { get; set; }

        [DataMember(Name = "MasterItemType")]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime UpdatedOn { get; set; }


        [DataMember]
        public string PicPath { get; set; }


        [DataMember]
        public bool IsVeg { get; set; }

    }

    [DataContract]
    public class MUs
    {

        [DataMember]
        public int ID { get; set; }


        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public double UnitRate { get; set; }


        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime UpdatedOn { get; set; }

        [DataMember]
        public bool IsMaster { get; set; }



    }

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

    }
}
