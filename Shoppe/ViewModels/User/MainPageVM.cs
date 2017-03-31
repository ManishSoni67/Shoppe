using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Shoppe.Model;

namespace Shoppe
{
    public class MainPageVM : BaseModel
    {
        public MainPageVM()
        {
            InitializeDB();
            Onint();
        }
        private void Onint()
        {
            this.User = GetLastUserInfo() ?? new MUserInfo();
            NotifyAll();
        }
        ShoppeDBContext db = null;
        private void InitializeDB()
        {
            string ConnectionString = App.ConnectionString;
            db = new ShoppeDBContext(ConnectionString);
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
        }

        public event EventHandler UserLogged;
        public void RaiseUserLogged()
        {
            if (UserLogged != null)
                UserLogged(this, new EventArgs());
        }
        public event EventHandler UserNotAutherized;
        public void RaiseUserNotAutherized()
        {
            if (this.UserNotAutherized != null)
            {
                UserNotAutherized(this, new EventArgs());
            }
        }
        /* Properties*/
        MUserInfo _User = new MUserInfo();
        public MUserInfo User
        {
            get { return _User; }
            set
            {
                _User = value;
                Notify("User");
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


        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(User.Name)) { Status = "Username Cannot be Empty!"; return false; }
            else if (string.IsNullOrWhiteSpace(User.Password)) { Status = "Password Cannot Be Empty !"; return false; }
            else { Status = ""; return true; }
        }

        public void Autherize()
        {
            if (Validate())
            {
                this.DoWorkAsync();
            }
        }

        public void _CheckForUser()
        {
            var usr = db.UserInfos.SingleOrDefault(x => (x.Username.ToLower().Equals(User.Name.Trim().ToLower())) && (x.Password.ToLower().Equals(User.Password.Trim().ToLower())));
            if (usr != null)
            {
                User.ID = usr.ID;
                //User.Name = usr.Username;
                User.Name = usr.Username;
                User.Password = usr.Password;
                User.Hint = usr.Hint;
                User.DeviceName = usr.DeviceName;
                Status = "";
                usr.UpdatedOn = DateTime.Today;
                db.SubmitChanges();
                RaiseUserLogged();
                //return true;
            }
            else
            {
                Status = "Invalid User !";
                // return false;
                RaiseUserNotAutherized();
            }
        }


        public MUserInfo GetLastUserInfo()
        {
            try
            {

                var LastUpdatedDate = db.UserInfos.Max(x => x.UpdatedOn);

                var LastUser = db.UserInfos.FirstOrDefault(x => DateTime.Compare(x.UpdatedOn, LastUpdatedDate) == 0);

                if (LastUser == null)
                    return null;

                else
                    return new MUserInfo()
                    {
                        ID = LastUser.ID,
                        DeviceName = LastUser.DeviceName,
                        Name = LastUser.Username,
                        Password = LastUser.Password,
                        CreatedOn = LastUser.CreatedOn,
                        UpdatedOn = LastUser.UpdatedOn,
                        Hint = LastUser.Hint,
                    };


            }
            catch (Exception e)
            {
                return null;
            }
        }





    }
}
