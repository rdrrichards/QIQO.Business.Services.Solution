using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class PersonData : CommonData, IEntity
    {

        public int PersonKey { get; set; }
        public string PersonCode { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonMi { get; set; }
        public string PersonLastName { get; set; }
        public int ParentPersonKey { get; set; }
        public DateTime? PersonDob { get; set; }

        public int EntityRowKey
        {
            get { return PersonKey; }
            set { PersonKey = value; }
        }
    }
}