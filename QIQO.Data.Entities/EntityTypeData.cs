using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class EntityTypeData : CommonData, IEntity
    { // EntityType class opener
        public int EntityTypeKey { get; set; }
        public string EntityTypeCode { get; set; }
        public string EntityTypeName { get; set; }

        public int EntityRowKey
        {
            get { return EntityTypeKey; }
            set { EntityTypeKey = value; }
        }
    } // EntityType class closer
}