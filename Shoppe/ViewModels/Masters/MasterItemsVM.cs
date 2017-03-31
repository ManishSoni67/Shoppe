using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{
    public class MasterItemsVM : BaseModel
    {
        public MasterItemsVM()
        {
            InitializeDB();
            Types = MasterItemType.GetAllMasterTypes();
        }

        ShoppeDBContext db = null;
        private void InitializeDB()
        {
            this.db = new ShoppeDBContext(App.ConnectionString);
            if (!(db.DatabaseExists()))
            {
                db.CreateDatabase();
            }
        }

        public event EventHandler ItemDeleted;
        public void RaiseItemDeleted()
        {
            if (ItemDeleted != null)
                ItemDeleted(this, new EventArgs());
        }

        string[] _Types;
        public string[] Types
        {
            get { return _Types; }
            set
            {
                _Types = value;
                Notify("Types");
            }
        }

        bool _IsAppBarVisible = true;
        public bool IsAppBarVisible
        {
            get { return _IsAppBarVisible; }
            set
            {
                _IsAppBarVisible = value;
                Notify("IsAppBarVisible");
            }
        }

        ObservableCollection<MMasterItems> _AllMasterItems = new ObservableCollection<MMasterItems>();
        public ObservableCollection<MMasterItems> AllMasterItems
        {
            get { return _AllMasterItems; }
            set
            {
                _AllMasterItems = value;
                Notify("AllMasterItems");
            }
        }
        ObservableCollection<GroupItems<MMasterItems>> _AllGrupedItems = new ObservableCollection<GroupItems<MMasterItems>>();
        public ObservableCollection<GroupItems<MMasterItems>> AllGrupedItems
        {
            get { return _AllGrupedItems; }
            set
            {
                _AllGrupedItems = value;
                Notify("AllGrupedItems");
            }
        }




        string _SearchPattern;
        public string SearchPattern
        {
            get { return _SearchPattern; }
            set
            {
                _SearchPattern = value;
                Notify("SearchPattern");
            }
        }



        public void GetAllItems()
        {
            DoWorkAsync();
        }


        public void _GetAllItemsAsync()
        {
            try
            {
                this.AllMasterItems = new ObservableCollection<MMasterItems>(Base.AllItems);
                GroupItemsByItemType();
            }
            catch (Exception e)
            {

            }
        }

        public void GroupItemsByItemType()
        {
            try
            {
                if (AllGrupedItems.Count > 0)
                {
                    AllGrupedItems.Clear();
                }
                var AllItems = AllMasterItems;
                var GroupedItem = AllItems.GroupBy(x => x.Description);
                foreach (var Grp in GroupedItem)
                {
                    GroupItems<MMasterItems> GrpItem = new GroupItems<MMasterItems>() { Key = Grp.Key };
                    var ItemsList = Grp.Select(x => x).OrderBy(x => x.Title).ToList();
                    ItemsList.ForEach(x => GrpItem.Add(x));
                    GrpItem.ItemCount = ItemsList.Count;
                    AllGrupedItems.Add(GrpItem);
                }
                Notify("AllGrupedItems");
            }
            catch (Exception e)
            {

            }
        }

        public void DeleteItem(int ID)
        {
            var Item = db.MasterItems.SingleOrDefault(x => x.ID == ID);
            if (Item != null)
            {
                db.MasterItems.DeleteOnSubmit(Item);
                db.SubmitChanges();
                Base.ReloadMasterItems();
                GetAllItems();
                RaiseItemDeleted();
            }

        }




    }

    public class GroupItems<T> : ObservableCollection<T>
    {

        public GroupItems()
        {

        }

        public GroupItems(string _Key)
        {

            Key = _Key;

        }
        public string Key { get; set; }

        public string Title { get { return Key; } set { } }

        public int ItemCount { get { return Items.Count; } set { } }
    }


    public class GroupItemsForChilds<T> : GroupItems<T>
    {

        public GroupItemsForChilds()
        {

        }
        public GroupItemsForChilds(String _Key)
            : base(_Key)
        {



        }

        public double TotalSum { get; set; }

        public double AverageSum
        {
            get
            {
                return Math.Round(TotalSum / ItemCount, 2);
            }
            set { }
        }


    }


}
