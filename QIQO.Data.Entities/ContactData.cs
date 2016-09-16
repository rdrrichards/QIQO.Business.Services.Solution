using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class ContactData : CommonData, IEntity
    { // Contact class opener
        public int ContactKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityTypeKey { get; set; }
        public int ContactTypeKey { get; set; }
        public string ContactValue { get; set; }
        public int ContactDefaultFlg { get; set; }
        public int ContactActiveFlg { get; set; }

        public int EntityRowKey
        {
            get { return ContactKey; }
            set { ContactKey = value; }
        }
    } // Contact class closer
}