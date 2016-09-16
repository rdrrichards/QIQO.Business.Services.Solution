
using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities.Identity
{
    public class UserClaimData : IIdentityEntity
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string EntityRowKey
        {
            get { return Id.ToString(); }
            set { Id = Guid.Parse(value); }
        }
    }
}
