using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class FeeSchedule
    {
        [DataMember]
        public int FeeScheduleKey { get; set; }
        [DataMember]
        public int CompanyKey { get; set; }
        [DataMember]
        public int AccountKey { get; set; }
        [DataMember]
        public int ProductKey { get; set; }
        [DataMember]
        public DateTime FeeScheduleStartDate { get; set; }
        [DataMember]
        public DateTime FeeScheduleEndDate { get; set; }
        [DataMember]
        public string FeeScheduleTypeCode { get; set; }
        [DataMember]
        public decimal FeeScheduleValue { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string AccountCode { get; set; }

        //[DataMember]
        //public Product Product { get; set; } = new Product();
    }
}
