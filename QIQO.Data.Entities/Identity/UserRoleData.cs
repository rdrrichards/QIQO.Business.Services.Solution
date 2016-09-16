
using System;
using QIQO.Common.Contracts;

namespace QIQO.Data.Entities.Identity
{
    public class UserRoleData : IIdentityEntity
    {
        public Guid RoleID { get; set; }
        public Guid UserID { get; set; }
        public string EntityRowKey
        {
            get { return RoleID.ToString(); }
            set { RoleID = Guid.Parse(value); }
        }
    }
}
