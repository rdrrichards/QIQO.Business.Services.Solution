using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Product: IModel
    {
        [DataMember]
        public int ProductKey { get; set; }
        [DataMember]
        public QIQOProductType ProductType { get; set; } = QIQOProductType.Sweet9;
        [DataMember]
        public ProductType ProductTypeData { get; set; } = new ProductType();
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public string ProductNameShort { get; set; }
        [DataMember]
        public string ProductNameLong { get; set; }
        [DataMember]
        public string ProductImagePath { get; set; }
        [DataMember]
        public List<EntityAttribute> ProductAttributes { get; set; } = new List<EntityAttribute>();
        [DataMember]
        public string ProductDescCombo { get; set; }
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
