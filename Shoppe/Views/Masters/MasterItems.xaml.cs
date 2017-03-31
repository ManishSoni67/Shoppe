using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{
    public partial class MasterItems : PhoneApplicationPage
    {

        public MasterItemsVM Model
        {
            get
            {
                return (MasterItemsVM)this.DataContext;
            }
        }


        public MasterItems()
        {
            InitializeComponent();

            //    FillAllItems();
            this.BackKeyPress += MasterItems_BackKeyPress;
            MasterItemView.Model.ItemSaved += Model_ItemSaved;
            MasterItemView.Btn_Close.Click += Btn_Close_Click;
            this.Model.Worker.DoWork += Worker_DoWork;
            Model.GetAllItems();
        }

        void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Model._GetAllItemsAsync());
        }

        void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            MasterItemView.Model.Item = new MMasterItems();
            MasterItemView.MaintainState();
            ApplicationBar.IsVisible = true;
            HideMasterItemControl.Begin();
        }

        void Model_ItemSaved(object sender, EventArgs e)
        {

            Model.GetAllItems();

            //string cnt = "";
            //var Content = lst_types_Picker.SelectedItem;
            //if (Content != null)
            //{
            //    cnt = Content.ToString();
            //}

            //var item = MasterItemView.lst_Picker_Cat.Items.SingleOrDefault(x => x.Equals(cnt));
            //if (item != null)
            //{
            //    MasterItemView.lst_Picker_Cat.SelectedItem = item;
            //}
            //    Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern(Model.SearchPattern, cnt));


            //var Type = MasterItemView.Model.Item.Description;
            // this.SetListItemAsPerPattern(Model.SearchPattern, Type);
            // MasterItemView.Model.Item = new MMasterItems();




        }

        void MasterItems_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ScaleUserControl.ScaleX <= 0)
            {
                e.Cancel = true;
                MasterItemView.Model.Item = new MMasterItems();
                MasterItemView.MaintainState();
                ApplicationBar.IsVisible = true;
                HideMasterItemControl.Begin();
            }
            else
            {
                e.Cancel = false;
            }
        }



        private void Text_SearchItems_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var txt = sender as TextBox;
            var pattern = txt.Text;
            string cnt = "";
            var Content = lst_types_Picker.SelectedItem;
            if (Content != null)
            {
                cnt = Content.ToString();
            }
            // Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern(pattern, cnt));



        }



        private void FillAllItems()
        {
            string cnt = "";
            var Content = lst_types_Picker.SelectedItem;
            if (Content != null)
            {
                cnt = Content.ToString();
            }
            // Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern("", cnt));

        }



        private void Btn_SelectedItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            ApplicationBar.IsVisible = false;
            var btn = sender as Image;
            var data = (MMasterItems)btn.DataContext;
            if (data != null)
            {
                var dta = data;
                var Cat = MasterItemView.Model.Types.FirstOrDefault(x => x.Equals(data.Description));
                if (Cat != null)
                {
                    MasterItemView.lst_Picker_Cat.SelectedItem = Cat;
                }

                var MU = MasterItemView.Model.AllMUs.FirstOrDefault(x => x.ID == data.MUID);
                if (MU != null)
                {
                    MasterItemView.lst_Picker_MU.SelectedItem = MU;
                }
                var Item = data.GetNewObject<MMasterItems>();
                MasterItemView.Model.Item = Item;
                MasterItemView.Model.ViewTitle = "Update " + data.Title + " Details !";
                ShowMasterItemControl.Begin();
            }
        }

        private void lst_types_Picker_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            string cnt = "";
            var Content = lst_types_Picker.SelectedItem;
            if (Content != null)
            {
                cnt = Content.ToString();
            }

            var item = MasterItemView.lst_Picker_Cat.Items.SingleOrDefault(x => x.Equals(cnt));
            if (item != null)
            {
                MasterItemView.lst_Picker_Cat.SelectedItem = item;
            }
            //Dispatcher.BeginInvoke(()=>this.SetListItemAsPerPattern(Model.SearchPattern, cnt));

        }

        //private void SetListItemAsPerPattern(string Pattern, string type)
        //{

        //    ObservableCollection<MMasterItems> FilteredItems = new ObservableCollection<MMasterItems>();
        //    if (string.IsNullOrWhiteSpace(Pattern))
        //    {
        //        if (string.IsNullOrWhiteSpace(type))
        //        {
        //            var Items = Model.AllMasterItems.OrderBy(x => x.Title);
        //            FilteredItems = new ObservableCollection<MMasterItems>(Items);
        //            Lst_Items.ItemsSource = FilteredItems;
        //        }
        //        else 
        //        {
        //            var Items = Model.AllMasterItems.Where(x=>x.Description.Equals(type)).OrderBy(x => x.Title);
        //            FilteredItems = new ObservableCollection<MMasterItems>(Items);
        //            Lst_Items.ItemsSource = FilteredItems;
        //        }

        //    }
        //    else 
        //    {
        //        if (string.IsNullOrWhiteSpace(type))
        //        {
        //            var Items = Model.AllMasterItems.OrderBy(x => x.Title);
        //            FilteredItems = new ObservableCollection<MMasterItems>(Items);
        //            Lst_Items.ItemsSource = FilteredItems;
        //        }
        //        else
        //        {

        //                var Items = Model.AllMasterItems.Where(x => (x.Description.Equals(type)) && (x.Title.ToLower().Contains(Pattern.ToLower()))).OrderBy(x => x.Title);
        //                FilteredItems = new ObservableCollection<MMasterItems>(Items);
        //                Lst_Items.ItemsSource = FilteredItems;

        //        }


        //    }

        //}

        private void Btn_Search_Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.

            string cnt = "";
            Model.SearchPattern = null;
            var Content = lst_types_Picker.SelectedItem;
            if (Content != null)
            {
                cnt = Content.ToString();
            }
            // Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern(Model.SearchPattern, cnt));

        }

        private void Btn_Search_Reset_Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            string cnt = "";
            Model.SearchPattern = null;
            var Content = lst_types_Picker.SelectedItem;
            if (Content != null)
            {
                cnt = Content.ToString();
            }
            //  Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern("", cnt));

        }

        private void btn_Add_Masters_Click(object sender, System.EventArgs e)
        {
            AddNewMasterItem();

        }


        private void AddNewMasterItem(int? MUID = null, string Type = null)
        {
            try
            {
                // TODO: Add event handler implementation here.

                //            MasterItemView.Model.Item = new MMasterItems();
                ApplicationBar.IsVisible = false;
                //string cnt = "";
                //var Content = lst_types_Picker.SelectedItem;
                //if (Content != null)
                //{
                //    cnt = Content.ToString();
                //}

                //var item = MasterItemView.lst_Picker_Cat.Items.SingleOrDefault(x => x.Equals(cnt));
                //if (item != null)
                //{
                //    MasterItemView.lst_Picker_Cat.SelectedItem = item;
                //}

                //var Mu = (MMUs)MasterItemView.lst_Picker_MU.SelectedItem;
                //if (Mu != null)
                //{
                //    MasterItemView.Model.Item.MUID = Mu.ID;

                //}

                MasterItemView.Model.Reset();
                MasterItemView.SetMasters(MUID, Type);

                MasterItemView.InitiateView();
                MasterItemView.Model.ViewTitle = "New Master Item !";
                ShowMasterItemControl.Begin();
            }
            catch (Exception e)
            {
            }
        }

        private void Reload_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            //string cnt = "";
            //var Content = lst_types_Picker.SelectedItem;
            //if (Content != null)
            //{
            //    cnt = Content.ToString();
            //}

            //var item = MasterItemView.lst_Picker_Cat.Items.SingleOrDefault(x => x.Equals(cnt));
            //if (item != null)
            //{
            //    MasterItemView.lst_Picker_Cat.SelectedItem = item;
            //}

            Model.GetAllItems();
            //  Dispatcher.BeginInvoke(() => this.SetListItemAsPerPattern(Model.SearchPattern, cnt));
        }

        private void img_Add_New_Item_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Add event handler implementation here.

            var Img = sender as Image;
            if (Img == null)
                return;
            var Data = Img.DataContext;
            if (Data == null)
                return;
            var GrpData = (GroupItems<MMasterItems>)Data;
            int? MUID = null;
            if (GrpData.ItemCount > 0)
            {
                MUID = GrpData.FirstOrDefault().MUID;
            }
            else
            {
                MUID = null;
            }
            AddNewMasterItem(MUID, GrpData.Key);
        }



    }
}