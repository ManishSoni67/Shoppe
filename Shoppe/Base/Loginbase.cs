using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppe
{
   public class Loginbase
    {



       public static MUserInfo CurrentUser
       {
           get
           {
               return (MUserInfo)App.Current.Resources["User"];
           }
       }

       public static void ResetUser(MUserInfo inf)
       {

           var User= (MUserInfo)App.Current.Resources["User"];
           if (User != null)
           {
               User = inf;
           }

       }

      
   }
}
