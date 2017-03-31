using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe
{
   public class UserProfileVM:BaseModel
    {
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

        public UserProfileVM()
        {
            InitializeDB();
        }

        MUserInfo _User= new MUserInfo();
        public MUserInfo User
        {
            get { return _User; }
            set
            {
                _User = value;
                Notify("User");
            }
        }


        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(User.Name)) { Status = "Username Cannot be Empty!"; return false; }
            else if (string.IsNullOrWhiteSpace(User.Password)) { Status = "Password Cannot Be Empty !"; return false; }

            else { Status = ""; return true; }
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

        public void Update()
        {
            var usr = db.UserInfos.SingleOrDefault(x => x.ID == User.ID);
            if (usr != null)
            {
                usr.Username = User.Name;
                usr.Password = User.Password;
                usr.Hint = User.Hint;
                db.SubmitChanges();
                Loginbase.ResetUser(this.User);
            }
        }



    }


}
