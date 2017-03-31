using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;

namespace Shoppe
{
    public class MUManipulationVM : BaseModel
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
        public MUManipulationVM()
        {
            Oninit();
        }

        private void Oninit()
        {
            InitializeDB();
        }

        public event EventHandler SomeError;
        public void RaiseSomeError()
        {
            if (SomeError != null)
                SomeError(this, new EventArgs());
        }

        public event EventHandler MUSaved;
        public void RaiseMUSaved()
        {
            if (MUSaved != null)
                MUSaved(this, new EventArgs());
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(MU.Title))
            {

                Status = "Please Enter A Valid Name";
                return false;
            }
            else
            {
                Status = "";
                return true;
            }


        }

        public void Save()
        {
            DoWorkAsync();
        }

        public void SaveAsync()
        {

            if (Validate())
            {
                try
                {
                    if (MU.ID == 0)
                    {
                        MUs mu = new MUs();
                        mu.IsMaster = false;
                        mu.Title = MU.Title;
                        mu.UnitRate = 100;
                        mu.UpdatedOn = DateTime.Today;
                        mu.CreatedOn = DateTime.Today;
                        db.MUss.InsertOnSubmit(mu);
                        ViewTitleName = "Update " + mu.Title + " Details";
                        db.SubmitChanges();
                        MU.ID = mu.ID;


                    }
                    else
                    {
                        var M = db.MUss.SingleOrDefault(x => x.ID == MU.ID);
                        if (M != null)
                        {
                            M.IsMaster = false;
                            M.Title = MU.Title;
                            M.UpdatedOn = DateTime.Today;
                            db.SubmitChanges();

                        }
                    }

                    Base.ReloadAllMUs();
                    RaiseMUSaved();
                    NotifyAll();
                }
                catch (Exception e)
                {
                    Status = e.Message;
                    RaiseSomeError();

                }

            }
            else
            {
                RaiseSomeError();
            }
        }

        public void Reset()
        {
            MU = new MMUs();
            NotifyAll();
        }

        MMUs _MU = new MMUs();
        public MMUs MU
        {
            get { return _MU; }
            set
            {
                _MU = value;
                Notify("MU");
            }
        }



        string _ViewTitleName;
        public string ViewTitleName
        {
            get { return _ViewTitleName; }
            set
            {
                _ViewTitleName = value;
                Notify("ViewTitleName");
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




    }
}
