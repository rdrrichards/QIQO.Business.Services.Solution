using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class PersonTypeData : CommonData, IEntity
    { // PersonType class opener
        public int PersonTypeKey { get; set; }
        public string PersonTypeCategory { get; set; }
        public string PersonTypeCode { get; set; }
        public string PersonTypeName { get; set; }
        public string PersonTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return PersonTypeKey; }
            set { PersonTypeKey = value; }
        }
    } // PersonType class closer
}