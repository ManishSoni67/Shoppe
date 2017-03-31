using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Shoppe.Model;

namespace Shoppe
{
   public class AppSettngVM:BaseModel
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
       public AppSettngVM()
       {
           LoadFromBase();
       }

       public void LoadFromBase()
       {
           InitializeDB();
           this.AppColors = new ObservableCollection<MAppSettingColors>(MasterItemType.GetAllColors());
           this.MasterColors = new ObservableCollection<MAppSettingColors>(MasterItemType.GetMasterColors());
       }


       ObservableCollection<MAppSettingColors> _AppColors = new ObservableCollection<MAppSettingColors>();
       public ObservableCollection<MAppSettingColors> AppColors
       {
           get { return _AppColors; }
           set
           {
               _AppColors = value;
               Notify("AppColors");
           }
       }

       ObservableCollection<MAppSettingColors> _MasterColors= new ObservableCollection<MAppSettingColors>();
       public ObservableCollection<MAppSettingColors> MasterColors
       {
           get { return _MasterColors; }
           set
           {
               _MasterColors = value;
               Notify("MasterColors");
           }
       }

       public void UpdateColor(MAppSettingColors MC, Color c)
       {

           var color = db.AppSetting.SingleOrDefault(x => x.ID == MC.ID);
           if (color != null)
           {
               color.A = c.A;
               color.B = c.B;
               color.R = c.R;
               color.G = c.G;
               db.SubmitChanges();
           }


       }


    }
}
