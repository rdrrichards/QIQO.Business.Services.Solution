using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class EntityPersonData : CommonData, IEntity
    { // EntityPerson class opener
        public int EntityPersonKey { get; set; }
        public int PersonKey { get; set; }
        public int PersonTypeKey { get; set; }
        public int EntityPersonSeq { get; set; }
        public string PersonRole { get; set; }
        public int EntityTypeKey { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EntityKey { get; set; }

        public int EntityRowKey
        {
            get { return EntityPersonKey; }
            set { EntityPersonKey = value; }
        }
    } // EntityPerson class closer
}