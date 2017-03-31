using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shoppe
{
    [Table]
    
    public class UserInfo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }


        [Column(CanBeNull = false)]
        public string Username { get; set; }

        [Column(CanBeNull = false)]
        public string Password { get; set; }

        [Column(CanBeNull = false)]
        public string DeviceName { get; set; }

        [Column(CanBeNull = true)]
        public string Hint { get; set; }

        [Column(CanBeNull = false)]
        public DateTime CreatedOn { get; set; }

        [Column(CanBeNull = false)]
        public DateTime UpdatedOn { get; set; }




    }
}
