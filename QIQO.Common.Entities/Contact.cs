using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    public class Contact: IModel
    {
        [DataMember]
        public int ContactKey { get; set; }
        [DataMember]
        public int EntityKey { get; set; }
        [DataMember]
        public int EntityTypeKey { get; set; }
        [DataMember]
        public int ContactTypeKey { get; set; }
        [DataMember]
        public QIQOContactType ContactType { get; set; } = QIQOContactType.CellPhone;
        [DataMember]
        public string ContactValue { get; set; }
        [DataMember]
        public int ContactDefaultFlg { get; set; }
        [DataMember]
        public int ContactActiveFlg { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }
    }
}
