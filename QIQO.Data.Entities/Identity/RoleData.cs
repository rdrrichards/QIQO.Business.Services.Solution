using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities.Identity
{
    public class RoleData : IIdentityEntity
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string EntityRowKey
        {
            get { return RoleId.ToString(); }
            set { RoleId = Guid.Parse(value); }
        }
    }
}
