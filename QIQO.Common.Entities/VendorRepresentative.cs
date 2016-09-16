using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class VendorRepresentative : PersonBase
    {
        [DataMember]
        public Vendor Vendor { get; set; }
    }
}
