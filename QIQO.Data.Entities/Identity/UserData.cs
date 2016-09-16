using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities.Identity
{
    public class UserData : IIdentityEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }

        public string EntityRowKey
        {
            get { return Id.ToString(); }
            set { Id = Guid.Parse(value); }
        }
    }
}
