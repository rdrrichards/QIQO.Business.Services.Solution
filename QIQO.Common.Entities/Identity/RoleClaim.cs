using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class RoleClaim
    {
        [DataMember]
        public Guid ClaimID { get; set; }
        [DataMember]
        public Guid RoleID { get; set; }
        [DataMember]
        public string ClaimType { get; set; }
        [DataMember]
        public string ClaimValue { get; set; }
    }
}