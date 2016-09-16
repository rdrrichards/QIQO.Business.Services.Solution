using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class VendorData : CommonData, IEntity
    { // Vendor class opener
        public int VendorKey { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorDesc { get; set; }

        public int EntityRowKey
        {
            get { return VendorKey; }
            set { VendorKey = value; }
        }
    } // Vendor class closer
}