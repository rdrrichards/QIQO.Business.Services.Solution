using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid UserId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string NormalizedEmail { get; set; }
        [DataMember]
        public bool EmailConfirmed { get; set; }
        [DataMember]
        public string PasswordHash { get; set; }
        [DataMember]
        public string SecurityStamp { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public bool PhoneNumberConfirmed { get; set; }
        [DataMember]
        public bool TwoFactorEnabled { get; set; }
        [DataMember]
        public DateTimeOffset? LockoutEnd { get; set; }
        [DataMember]
        public bool LockoutEnabled { get; set; }
        [DataMember]
        public int AccessFailedCount { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string NormalizedUserName { get; set; }

        [DataMember]
        public List<UserClaim> Claims { get; set; } = new List<UserClaim>();
        [DataMember]
        public List<Role> Roles { get; set; } = new List<Role>();
        [DataMember]
        public List<UserLogin> Logins { get; set; } = new List<UserLogin>();
    }
}
