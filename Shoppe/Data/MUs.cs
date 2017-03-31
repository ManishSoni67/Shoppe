using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Shoppe
{
    [Table]
    [DataContract]
    public class MUs
    {

        [DataMember]
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }


        [DataMember]
        [Column(CanBeNull = false)]
        public string Title { get; set; }

        [DataMember]
        [Column(CanBeNull = false)]
        public double UnitRate { get; set; }


        [DataMember]
        [Column(CanBeNull = false)]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        [Column(CanBeNull = false)]
        public DateTime UpdatedOn { get; set; }

        [DataMember]
        [Column(CanBeNull = false)]
        public bool IsMaster { get; set; }



    }
}
