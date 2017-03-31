using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Shoppe
{
    [Table]
   public class ShoppingData
    {

        [Column(IsPrimaryKey=true,IsDbGenerated=true)]
        public int ID { get; set; }

        [Column(CanBeNull=false)]
        public DateTime ForDate { get; set; }
        [Column(CanBeNull = false)]
        public int UserID { get; set; }

        [Column(CanBeNull = false)]
        public string Title { get; set; }


        [Column(CanBeNull = false)]
        public double Qty{get; set;}


        [Column(CanBeNull = false)]
        public double TotalAmount { get; set; }

    }
}
