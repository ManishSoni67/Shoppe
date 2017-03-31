using Microsoft.Phone.Info;
using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Shoppe
{
    public class UserRegistrationVM : BaseModel
    {
        public UserRegistrationVM()
            : base()
        {
            InitializeDB();
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

        public event EventHandler DuplicateUserFound;
        public void RaiseDuplicateUserFound()
        {
            if (DuplicateUserFound != null)
                DuplicateUserFound(this, new EventArgs());
        }

        public event EventHandler<LoginParams> SavedCompleted;
        public void RaiseSavedCompleted(int _ID, string _UName, string _UPass, string _Hint)
        {
            if (SavedCompleted != null)
                SavedCompleted(this, new LoginParams(_ID, _UName, _UPass, _Hint));
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


        public void AddUser()
        {
            if (Validate())
            {
                this.DoWorkAsync();
            }
        }

        public void _AddUser()
        {

            UserInfo inf = new UserInfo()
            {
                Username = User.Name,
                Password = User.Password,
                Hint = User.Hint,
                CreatedOn = DateTime.Today,
                UpdatedOn = DateTime.Today
            };
            inf.DeviceName = DeviceStatus.DeviceName;

            var usr = db.UserInfos.SingleOrDefault(x => (x.Username.ToLower().Equals(User.Name.Trim().ToLower())) && (x.Password.ToLower().Equals(User.Password.Trim().ToLower())));
            if (usr != null)
            {
                RaiseDuplicateUserFound();
            }
            else
            {
                db.UserInfos.InsertOnSubmit(inf);
                db.SubmitChanges();
                this.User.ID = inf.ID;
                RaiseSavedCompleted(inf.ID, inf.Username, inf.Password, inf.Hint);

            }

        }

        public void Reset()
        {
            this.User = new MUserInfo();
        }



    }

    public class LoginParams : EventArgs
    {
        public LoginParams()
        {

        }
        public LoginParams(int _ID, string _UNmae, string _UPass, string _Hint)
        {
            this.ID = _ID;
            this.UName = _UNmae;
            this.UPass = _UPass;
            this.Hint = _Hint;
        }

        public int ID { get; set; }
        public string UName { get; set; }
        public string UPass { get; set; }
        public string Hint { get; set; }

        public void EquateProps(MUserInfo Inf)
        {
            if (Inf == null)
                return;

            Inf.ID = this.ID;
            Inf.Name = this.UName;
            Inf.Password = this.UPass;
            Inf.Hint = this.Hint;

        }

    }
}
