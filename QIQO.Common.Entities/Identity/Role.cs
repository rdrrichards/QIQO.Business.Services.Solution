using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Role
    {
        [DataMember]
        public Guid RoleId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string NormalizedName { get; set; }
        [DataMember]
        public List<RoleClaim> Roles { get; set; } = new List<RoleClaim>();
        [DataMember]
        public List<User> Users { get; set; } = new List<User>();

    }
}
