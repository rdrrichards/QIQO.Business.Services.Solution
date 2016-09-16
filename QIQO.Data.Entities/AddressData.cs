using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class AddressData : CommonData, IEntity
    { // Address class opener
        public int AddressKey { get; set; }
        public int AddressTypeKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateProv { get; set; }
        public string AddressCounty { get; set; }
        public string AddressCountry { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressNotes { get; set; }
        public int AddressDefaultFlg { get; set; }
        public int AddressActiveFlg { get; set; }

        public int EntityRowKey
        {
            get { return AddressKey; }
            set { AddressKey = value; }
        }
    } // Address class closer
}