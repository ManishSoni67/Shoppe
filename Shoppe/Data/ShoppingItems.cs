using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Shoppe
{
    [Table]
    public class ShoppingItems
    {

        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(CanBeNull = false)]
        public int UserID { get; set; }

        [Column(CanBeNull = false)]
        public string Name { get; set; }

        [Column(CanBeNull = false)]
        public int MUID { get; set; }

        [Column(CanBeNull = false)]
        public int HeaderID { get; set; }

        [Column(CanBeNull = false)]
        public double Qty { get; set; }

        [Column(CanBeNull = false)]
        public string Description { get; set; }

        [Column(CanBeNull = false)]
        public double UnitRate { get; set; }

        [Column(CanBeNull = false)]
        public double Amount { get; set; }

        [Column(CanBeNull = false)]
        public DateTime CreatedOn { get; set; }

        [Column(CanBeNull = false)]
        public DateTime UpdatedOn { get; set; }

        [Column(CanBeNull = false)]
        public int Revision { get; set; }

    }
}
