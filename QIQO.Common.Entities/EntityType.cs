using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class EntityType : IType, IModel
    {
        [DataMember]
        public int EntityTypeKey { get; set; }

        //public string EntityTypeCategory { get; set; }
        [DataMember]
        public string EntityTypeCode { get; set; }
        [DataMember]
        public string EntityTypeName { get; set; }
        //public string EntityTypeDesc { get; set; }
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
            get { return EntityTypeKey; }

            set { EntityTypeKey = value; }
        }
    }
}
