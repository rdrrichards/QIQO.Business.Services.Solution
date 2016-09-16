using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class ProductTypeData : CommonData, IEntity
    { // ProductType class opener
        public int ProductTypeKey { get; set; }
        public string ProductTypeCategory { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return ProductTypeKey; }
            set { ProductTypeKey = value; }
        }
    } // ProductType class closer
}