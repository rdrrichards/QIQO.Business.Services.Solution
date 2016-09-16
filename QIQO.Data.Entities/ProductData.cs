using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class ProductData : CommonData, IEntity
    { // Product class opener
        public int ProductKey { get; set; }
        public int ProductTypeKey { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductNameShort { get; set; }
        public string ProductNameLong { get; set; }
        public string ProductImagePath { get; set; }

        public int EntityRowKey
        {
            get { return ProductKey; }
            set { ProductKey = value; }
        }
    } // Product class closer
}