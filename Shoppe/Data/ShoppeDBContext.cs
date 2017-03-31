using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Shoppe
{
    class ShoppeDBContext : DataContext
    {
        public ShoppeDBContext(string ConnectionString)
            : base(ConnectionString)
        {

        }

        public Table<ShoppingData> ShoppingData
        {
            get
            {
                return this.GetTable<ShoppingData>();
            }
        }

        public Table<ShoppingItems> ShoppingItems
        {
            get
            {
                return this.GetTable<ShoppingItems>();
            }
        }

        public Table<AppSettingColors> AppSetting
        {
            get
            {
                return this.GetTable<AppSettingColors>();
            }
        }
        public Table<UserInfo> UserInfos
        {
            get
            {
                return this.GetTable<UserInfo>();
            }
        }

        public Table<MUs> MUss
        {
            get
            {
                return this.GetTable<MUs>();
            }
        }

        public Table<MasterItem> MasterItems
        {
            get
            {
                return this.GetTable<MasterItem>();
            }
        }

    }
}
