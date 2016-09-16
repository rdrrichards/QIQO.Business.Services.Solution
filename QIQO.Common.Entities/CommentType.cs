using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class CommentType : IType
    {
        [DataMember]
        public int CommentTypeKey { get; set; }

        [DataMember]
        public string CommentTypeCategory { get; set; }
        [DataMember]
        public string CommentTypeCode { get; set; }
        [DataMember]
        public string CommentTypeName { get; set; }
        [DataMember]
        public string CommentTypeDesc { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        public int TypeRowKey
        {
            get { return CommentTypeKey; }

            set { CommentTypeKey = value; }
        }
    }
}
