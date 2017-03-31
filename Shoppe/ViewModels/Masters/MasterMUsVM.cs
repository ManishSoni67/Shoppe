using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shoppe.Model;
using System.Collections.ObjectModel;
namespace Shoppe
{
    public class MasterMUsVM : BaseModel
    {

        public MasterMUsVM()
        {
            Oninit();
        }

        private void Oninit()
        {



        }
        public void Initilizebase()
        {

            DoWorkAsync();
        }

        public void InitializebaseAsync()
        {
            try
            {
                this.AllMUs = new ObservableCollection<MMUs>(Base.AllMUs);

            }
            catch (Exception e)
            {
            }
        }


        ObservableCollection<MMUs> _AllMUs = new ObservableCollection<MMUs>();
        public ObservableCollection<MMUs> AllMUs
        {
            get { return _AllMUs; }
            set
            {
                _AllMUs = value;
                Notify("AllMUs");
            }
        }






    }
}
