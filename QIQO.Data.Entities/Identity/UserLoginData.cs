
using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities.Identity
{
    public class UserLoginData : IIdentityEntity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public Guid UserID { get; set; }
        public string EntityRowKey
        {
            get { return LoginProvider; }
            set { LoginProvider = value; }
        }
    }
}
