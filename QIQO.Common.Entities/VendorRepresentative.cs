using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class VendorRepresentative : PersonBase, IModel
    {
        [DataMember]
        public Vendor Vendor { get; set; }
    }
}
