using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class AddressTypeData : CommonData, IEntity
    { // AddressType class opener
        public int AddressTypeKey { get; set; }
        public string AddressTypeCode { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return AddressTypeKey; }
            set { AddressTypeKey = value; }
        }
    } // AddressType class closer
}