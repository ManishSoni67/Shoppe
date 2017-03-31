using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
namespace Shoppe
{
    [Table]
    public class AppSettingColors
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }

        [Column(CanBeNull = false)]
        public string Name { get; set; }

        [Column(CanBeNull = false)]
        public byte A { get; set; }

        [Column(CanBeNull = false)]
        public byte R { get; set; }

        [Column(CanBeNull = false)]
        public byte G { get; set; }

        [Column(CanBeNull = false)]
        public byte B { get; set; }
    }
}
