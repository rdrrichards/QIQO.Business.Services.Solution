using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class UserSession
    {
        [DataMember]
        public int ProcessID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public string UserDomain { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string HostName { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime? EndTime { get; set; }
        [DataMember]
        public int Active { get; set; }
        [DataMember]
        public int CompanyKey { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        public UserSession() { }
        public UserSession(int process_id, string host_name, string user_domain, string user_name, int company_key)
        {
            if (process_id == 0)
                throw new ArgumentException("The process ID parameter cannot be zero(0)!", "process_id");
            if (host_name == "")
                throw new ArgumentException("The host name parameter cannot be empty!", "host_name");
            if (user_domain == "")
                throw new ArgumentException("The user domain parameter cannot be empty!", "user_domain");
            if (user_name == "")
                throw new ArgumentException("The user name parameter cannot be empty!", "user_name");
            if (company_key == 0)
                throw new ArgumentException("The company key parameter cannot be zero(0)!", "company_key");

            ProcessID = process_id;
            HostName = host_name;
            UserDomain = user_domain;
            UserName = user_name;
            CompanyKey = company_key;
            string session_id = host_name + "|" + user_domain + "|" + user_name + "|" + process_id.ToString();
            SessionID = session_id;
            StartTime = DateTime.Now;
            Active = 1;
        }
    }
}
