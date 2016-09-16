using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class ContactTypeData : CommonData, IEntity
    { // ContactType class opener
        public int ContactTypeKey { get; set; }
        public string ContactTypeCategory { get; set; }
        public string ContactTypeCode { get; set; }
        public string ContactTypeName { get; set; }
        public string ContactTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return ContactTypeKey; }
            set { ContactTypeKey = value; }
        }
    } // ContactType class closer
}