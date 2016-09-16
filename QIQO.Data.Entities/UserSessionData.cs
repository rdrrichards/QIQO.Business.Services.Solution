using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class UserSessionData : CommonData, IEntity
    { // UserSession class opener
        public int SessionKey { get; set; }
        public string SessionCode { get; set; }
        public string HostName { get; set; }
        public string UserDomain { get; set; }
        public string UserName { get; set; }
        public int ProcessId { get; set; }
        public int CompanyKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ActiveFlg { get; set; }

        public int EntityRowKey
        {
            get { return SessionKey; }
            set { SessionKey = value; }
        }
    } // UserSession class closer
}