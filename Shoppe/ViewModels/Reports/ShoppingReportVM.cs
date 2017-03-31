using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{
    public class ShoppingReportVM : BaseModel
    {
        ShoppeDBContext db = null;
        private void InitializeDB()
        {
            this.db = new ShoppeDBContext(App.ConnectionString);
            if (!(db.DatabaseExists()))
            {
                db.CreateDatabase();
            }
        }
        public ShoppingReportVM()
        {
            Oninit();
            InitializeDB();
        }

        public override void Oninit()
        {
            base.Oninit();
            //ReportData.Add(new ReportData() {Name="Manish", Value=100.00 });
            //ReportData.Add(new ReportData() { Name = "Vinod", Value = 200.00 });
            //ReportData.Add(new ReportData() { Name = "Suresh", Value = 300.00 });
            //ReportData.Add(new ReportData() { Name = "Naresh", Value = 400.00 });
        }

        ObservableCollection<ReportData> _ReportData = new ObservableCollection<ReportData>();
        public ObservableCollection<ReportData> ReportData
        {
            get { return _ReportData; }
            set
            {
                _ReportData = value;
                Notify("ReportData");
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

        double _Amount = 0.00;
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
                NotifyAll();
            }
        }


        public int TotalItems { get { return ReportData.Count; } set { } }

        public bool HaveItems { get { return TotalItems > 0; } set { } }

        public double AverageAmount
        {
            get
            {
                if (HaveItems)
                    return Math.Round(Amount / TotalItems, 2);
                else
                    return 0.0;
            }
            set { }
        }

    }
}
