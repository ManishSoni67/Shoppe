using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Shoppe
{
    public partial class ShoppingReport : UserControl
    {
        public ShoppingReportVM Model
        {
            get
            {
                return (ShoppingReportVM)this.DataContext;
            }
        }

        public ShoppingReport()
        {
            InitializeComponent();
        }
    }
}
