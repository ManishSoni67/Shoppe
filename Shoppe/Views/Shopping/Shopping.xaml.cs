using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Shoppe.Model;
using System.Collections.ObjectModel;

namespace Shoppe
{
    public partial class Shopping : PhoneApplicationPage
    {

        public ShoppingVM Model
        {
            get
            {
                return (ShoppingVM)this.DataContext;
            }
        }

        public Shopping()
        {
            InitializeComponent();
            BaseItems.Btn_Done.Click += Btn_Done_Click;
            this.BackKeyPress += Shopping_BackKeyPress;
            BaseItems.Btn_Close.Click += Base_Btn_Close_Click;
            VWShoppingItem.Btn_Close.Click += Btn_Close_Click;
            VWShoppingItem.Model.ItemSaved += Model_ItemSaved;
            Model.ShopCompleted += Model_ShopCompleted;
            this.Loaded += Shopping_Loaded;
            Str_Notify.Completed += Str_Notify_Completed;
            Brd_Notification.Visibility = Visibility.Collapsed;

        }

        void Str_Notify_Completed(object sender, EventArgs e)
        {
            Brd_Notification.Visibility = Visibility.Collapsed;
        }

        void Model_ShopCompleted(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        void Shopping_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var line in BaseItems.Model.MasterItems)
            {
                line.isChecked = false;
            }
        }

        void Model_ItemSaved(object sender, EventArgs e)
        {


            MMShopingItems item = MMShopingItems.Copy(VWShoppingItem.Model.ShoppingItem);
            if (item.LineID == 0)
            {
                Model.MasterItems.Add(item);


            }
            else
            {
                var Itm = this.Model.MasterItems.SingleOrDefault(x => x.LineID == item.LineID);
                if (Itm != null)
                {
                    Itm.MUID = item.MUID;
                    Itm.Name = item.Name;
                    Itm.Description = item.Description;
                    Itm.UnitRate = item.UnitRate;
                    Itm.Qty = item.Qty;
                    //Itm.amou = item.MUID;

                }
            }


            Model.LoadMasters();

        }

        void Base_Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Pvt_Master.IsEnabled = true;
            ApplicationBar.IsVisible = true;

            Str_HideBase.Begin();
        }

        void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Pvt_Master.IsEnabled = true;
            ApplicationBar.IsVisible = true;
            Str_HideShopItem.Begin();
        }

        void Shopping_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Pvt_Master.IsEnabled = true;
            ApplicationBar.IsVisible = true;
            if (Trns_Base.ScaleX > 0)
            {

                e.Cancel = true;
                Str_HideBase.Begin();
            }
            else if (Trns_BaseNewShopping.ScaleX > 0)
            {
                e.Cancel = true;
                Str_HideShopItem.Begin();
            }
            else if (Trns_BaseShoppingDetail.ScaleX > 0)
            {
                e.Cancel = true;
                Str_HideShopDetail.Begin();
            }
            else if (Trns_BaseShoppingReport.ScaleX > 0)
            {
                e.Cancel = true;
                Str_HideShopReport.Begin();
            }
            else
            {
                e.Cancel = false;
            }
        }

        void Btn_Done_Click(object sender, RoutedEventArgs e)
        {
            var User = Loginbase.CurrentUser;
            var Data = BaseItems.Model.MasterItems.Where(x => x.isChecked == true);
            //ObservableCollection<MMShopingItems> Items = new ObservableCollection<MMShopingItems>();

            if (this.Model.MasterItems.Count == 0)
            {
                Model.MasterItems = new ObservableCollection<MMShopingItems>(Data.Select(x => new MMShopingItems()
                    {
                        MUID = x.MUID,
                        IsFromMaster = true,
                        ItemMasterID = x.ID,
                        CreatedOn = DateTime.Today,
                        UpdatedOn = DateTime.Today,
                        Description = x.Description,
                        Name = x.Title,
                        Qty = 1,
                        UnitRate = 10,
                        Revision = 1,
                        UserID = User.ID,
                    }));


            }
            else
            {

                foreach (var datline in Data)
                {
                    var shop = this.Model.MasterItems.SingleOrDefault(x => x.ItemMasterID == datline.ID);
                    if (shop == null)
                    {
                        MMShopingItems m = new MMShopingItems()
                        {
                            MUID = datline.MUID,
                            IsFromMaster = true,
                            ItemMasterID = datline.ID,
                            CreatedOn = DateTime.Today,
                            UpdatedOn = DateTime.Today,
                            Description = datline.Description,
                            Name = datline.Title,
                            Qty = 1,
                            UnitRate = 10,
                            Revision = 1,
                            UserID = User.ID,
                        };

                        this.Model.MasterItems.Add(m);

                    }

                }

            }

            Model.LoadMasters();
            BaseItems.Str_Notify.Begin();

        }



        private void btn_Add_Masters_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            int Index = this.Pvt_Master.SelectedIndex;

            BaseItems.Pvt_Masters.SelectedIndex = Index;
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            Str_ShowBase.Begin();



        }

        private void grd_ShopItem_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            VWShoppingItem.MaintainState();
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            var grid = sender as Grid;
            var data = (MMShopingItems)grid.DataContext;
            MMShopingItems newshop = MMShopingItems.Copy(data);
            VWShoppingItem.Model.ShoppingItem = newshop;
            VWShoppingItem.MapMUIDandType();


            Str_ShowShopItem.Begin();


        }

        private void btn_Add_ShopItem_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            VWShoppingItem.MaintainState();
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;


            VWShoppingItem.Model.ShoppingItem = new MMShopingItems();
            // VWShoppingItem.MapMUIDandType();
            VWShoppingItem.SelectFirstElements();

            Str_ShowShopItem.Begin();
        }

        private void Btn_Prievew_Click(object sender, System.EventArgs e)
        {
            Pvt_Master.IsEnabled = false;
            ApplicationBar.IsVisible = false;
            var Qty = Model.MasterItems.Sum(x => x.Qty);
            var Amount = Model.MasterItems.Sum(x => x.Amount);
            VWShoppingDetails.EquateMembers(Model.Shopping, Qty, Amount);
            Str_ShowShopDetail.Begin();
        }

        private void Btn_Save_Shopping_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            //Save Mechanism
            if (Model.MasterItems.Count > 0)
            {
                if (Model.Shopping.Title.Equals("New Shopping"))
                {
                    //   Pvt_Master.IsEnabled = false;
                    //   ApplicationBar.IsVisible = false;
                    //   var Qty = Model.MasterItems.Sum(x => x.Qty);
                    //   var Amount = Model.MasterItems.Sum(x => x.Amount);
                    //   VWShoppingDetails.EquateMembers(Model.Shopping, Qty, Amount);
                    ////   VWShoppingDetails.Model.IsNotReady = false;
                    //   Str_ShowShopDetail.Begin();
                    Brd_Notification.Visibility = Visibility.Visible;
                    Str_Notify.Begin();
                }
                else
                {
                    Model.SaveShopping();
                }
            }
            else
            {
                MessageBox.Show("No Shopping Item Added yet");
            }


        }

        private void Menu_Show_Details_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.

            if (Model.MasterItems.Count > 0)
            {
                Pvt_Master.IsEnabled = false;
                ApplicationBar.IsVisible = false;

                VWShoppingReport.Model.ViewTitle = this.Model.Shopping.Title;
                VWShoppingReport.Model.ReportData = new ObservableCollection<ReportData>(Model.MasterItems.Select(x => new ReportData()
                {
                    Name = x.Name,
                    Value = x.Amount
                }));
                double SUM = VWShoppingReport.Model.ReportData.Sum(x => x.Value);
                VWShoppingReport.Model.Amount = SUM;

                Str_ShowShopReport.Begin();
            }
            else
            {
                MessageBox.Show("No Shopping Item Added yet");
            }
        }

        private void Img_Delete_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var Img = sender as Image;
            var Data = (MMShopingItems)Img.DataContext;
            if (Data != null)
            {
                this.Model.MasterItems.Remove(Data);

            }
            Model.LoadMasters();
        }
    }
}