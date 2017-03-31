using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;

namespace Shoppe
{
    public class MasterItemManipulationVM : BaseModel
    {


        public MasterItemManipulationVM()
        {
            InitializeDB();
            GetAllItems();
            NotifyAll();
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

        public event EventHandler ItemSaved;
        public void RaiseItemSaved()
        {
            if (ItemSaved != null)
                ItemSaved(this, new EventArgs());
        }

        public event EventHandler ItemDeleted;
        public void RaiseItemDeleted()
        {
            if (ItemDeleted != null)
                ItemDeleted(this, new EventArgs());
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

        public ObservableCollection<MMUs> AllMUs
        {
            get { return new ObservableCollection<MMUs>(Base.AllMUs); }
            set
            {
                Notify("AllMUs");
            }
        }

        MMasterItems _Item = new MMasterItems();
        public MMasterItems Item
        {
            get { return _Item; }
            set
            {
                _Item = value;
                Notify("Item");
            }
        }

        public string[] Types
        {
            get { return MasterItemType.GetAllMasterTypes(); }
            set
            {
                Notify("Types");
            }
        }

        string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                Notify("Status");
            }
        }

        string _ViewTitle;
        public string ViewTitle
        {
            get { return _ViewTitle; }
            set
            {
                _ViewTitle = value;
                Notify("ViewTitle");
            }
        }

        public void Reset()
        {
            try
            {
                this.Item = new MMasterItems();
                NotifyAll();
            }
            catch (Exception e)
            {

            }

        }

        


        public bool Validate()
        {
            if (String.IsNullOrWhiteSpace(Item.Title)) { Status = "Title Cannot Be Empty"; return false; }
            else if (Item.MUID <= 0) { Status = "Choose a M.U. !"; return false; }
            else if (String.IsNullOrWhiteSpace(Item.Description)) { Status = "Please Specify a Type !"; return false; }
            // else if (data != null) { Status = "Item Already Exists"; return false; }
            else { Status = ""; return true; }

        }

        public void AddOrUpdateItems()
        {
            if (Validate())
            {
                DoWorkAsync();
            }
        }
        public void AddorUpdateProductAsync()
        {
            try
            {
                if (Item.ID == 0)
                {
                    var data = db.MasterItems.SingleOrDefault(x => x.Title.ToLower().Equals(Item.Title.ToLower().Trim()));
                    if (data == null)
                    {
                        MasterItem m = new MasterItem()
                        {
                            Title = Item.Title,
                            IsVeg = Item.IsVeg,
                            IsMaster = false,
                            CreatedOn = DateTime.Today,
                            Description = Item.Description,
                            MUID = Item.MUID,
                            PicPath = Item.PicPath,
                            UpdatedOn = DateTime.Today,

                        };
                        db.MasterItems.InsertOnSubmit(m);
                        db.SubmitChanges();
                        Status = "New Item Saved Successfully";
                        ViewTitle = "Update " + m.Title + " Details !";
                        Item.ID = m.ID;
                    }
                }
                else
                {
                    var itm = db.MasterItems.SingleOrDefault(x => x.ID == Item.ID);
                    if (itm != null)
                    {
                        itm.Title = Item.Title;
                        itm.IsVeg = Item.IsVeg;
                        itm.Description = Item.Description;
                        itm.MUID = Item.MUID;
                        itm.IsMaster = false;
                        itm.UpdatedOn = DateTime.Today;
                        db.SubmitChanges();
                        Status = itm.Title + " Updated Successfully !";
                    }
                }
                Base.ReloadMasterItems();
                this.GetAllItems();
                NotifyAll();
                RaiseItemSaved();
            }
            catch (Exception e)
            {

            }
        }

        private void GetAllItems()
        {
            this.AllMasterItems = new ObservableCollection<MMasterItems>(Base.AllItems);
        }

        public void DeleteItem(int ID)
        {
            var Item = db.MasterItems.SingleOrDefault(x => x.ID == ID);
            if (Item != null)
            {
                db.MasterItems.DeleteOnSubmit(Item);
                db.SubmitChanges();

                RaiseItemDeleted();
            }

        }









    }
}
