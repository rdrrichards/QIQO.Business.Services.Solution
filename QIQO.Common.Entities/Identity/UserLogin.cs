using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class UserLogin
    {
        [DataMember]
        public string LoginProvider { get; set; }
        [DataMember]
        public string ProviderKey { get; set; }
        [DataMember]
        public string ProviderDisplayName { get; set; }
        [DataMember]
        public Guid UserID { get; set; }
    }
}
