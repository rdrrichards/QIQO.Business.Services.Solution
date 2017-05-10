using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class EntityProduct : Product, IModel
    {
        //public int EntityProductKey { get; set; }

        //These next 5 properties make a unique row 
        [DataMember]
        public int EntityProductKey { get; set; }
        [DataMember]
        public QIQOProductType EntityProductType { get; set; } = QIQOProductType.Sweet9;
        [DataMember]
        public int EntityProductSeq { get; set; }

        [DataMember]
        public int EntityProductEntityKey { get; set; }
        [DataMember]
        public QIQOEntityType EntityProductEntityTypeKey { get; set; } = QIQOEntityType.Account;
        [DataMember]
        public EntityType EntityProductEntityTypeData { get; set; }

        // I expect this to be emplty most of the time
        [DataMember]
        public string Comment { get; set; }
    }
}
