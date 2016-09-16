using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Vendor
    {
        [DataMember]
        public int VendorKey { get; set; }
        [DataMember]
        public string VendorCode { get; set; }
        [DataMember]
        public string VendorName { get; set; }
        [DataMember]
        public string VendorDesc { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        public List<VendorRepresentative> VendorRepresentatives { get; set; } = new List<VendorRepresentative>();
    }
}
