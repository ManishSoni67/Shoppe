using Shoppe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Shoppe
{
    public class AboutAppVM : BaseModel
    {
        public AboutAppVM()
        {
            Init();

        }

        public void Init()
        {


            Links = new ObservableCollection<MAboutAppLinks>();
            Links.Add(new MAboutAppLinks()
            {
                ID = 1,
                Content = "Connect With Us on Facebook",
                Icon = new BitmapImage(new Uri("/Media/Icons/Facebook.png", UriKind.Relative)),
                UrlLink = "https://www.facebook.com/Googlert"
            });
            Links.Add(new MAboutAppLinks()
            {
                ID = 2,
                Content = "Connect With Us on Google+",
                Icon = new BitmapImage(new Uri("/Media/Icons/Google.png", UriKind.Relative)),
                UrlLink = "https://plus.google.com/u/0/b/111013302558351195393/111013302558351195393"
            });
            Links.Add(new MAboutAppLinks()
            {
                ID = 3,
                Content = "More Apps Waiting for You :)",
                Icon = new BitmapImage(new Uri("/Media/Icons/WindowsStore.png", UriKind.Relative)),
                UrlLink = "http://www.windowsphone.com/en-US/store/publishers?publisherId=Googlert&appId=a302a617-8af4-4189-a673-9a0e7344e4bf"
            });


            this.AppAttr = new AboutAppModel()
            {
                Description="Shoppe, what I call it MOBILE ERP, Handle all of your Shopping Data Under One Single HOOD in Your Phone :), Which is Fun when it comes with all Reporting with Previous Shopping Records, All You Gotta Do, is to Shop",
                Title="Shoppe",
                Version="Shoppe v 1.o",
               
               
            };
            this.Dev = new DevProfile()
            {
                Name = "Manish Soni",
                Skills = "Silverlight, WPF, Windows Phone 7/8, WCF, ASP.NET MVC, HTML, JavaScript, HTML, XML, CSS, SQL Server",
                Designation = "Software Developer",
                Email = "manish.6709@gmail.com",
                LinkedInUrl = "in.linkedin.com/pub/manish-soni/54/23b/4a1",
            };

        }

        ObservableCollection<MAboutAppLinks> _Links = new ObservableCollection<MAboutAppLinks>();
        public ObservableCollection<MAboutAppLinks> Links
        {
            get { return _Links; }
            set
            {
                _Links = value;
                Notify("Links");
            }
        }

        AboutAppModel _AppAttr= new AboutAppModel();
        public AboutAppModel AppAttr
        {
            get { return _AppAttr; }
            set
            {
                _AppAttr = value;
                Notify("AppAttr");
            }
        }

        DevProfile _Dev = new DevProfile();
        public DevProfile Dev
        {
            get { return _Dev; }
            set
            {
                _Dev = value;
                Notify("Dev");
            }
        }

    }
}
