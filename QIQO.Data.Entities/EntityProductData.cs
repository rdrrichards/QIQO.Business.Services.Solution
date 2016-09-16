using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class EntityProductData : CommonData, IEntity 
    { // EntityProduct class opener
        public int EntityProductKey { get; set; }
        public int ProductKey { get; set; }
        public int ProductTypeKey { get; set; }
        public int EntityProductSeq { get; set; }
        public int EntityTypeKey { get; set; }
        public string Comment { get; set; }

        public int EntityKey { get; set; }

        public int EntityRowKey
        {
            get { return EntityProductKey; }
            set { EntityProductKey = value; }
        }
    } // EntityProduct class closer
}