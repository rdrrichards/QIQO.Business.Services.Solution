using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class EntityEntityData : CommonData, IEntity
    { // EntityEntity class opener
        public int EntityEntityKey { get; set; }
        public int PrimaryEntityKey { get; set; }
        public int PrimaryEntityTypeKey { get; set; }
        public int SecondaryEntityKey { get; set; }
        public int SecondaryEntityTypeKey { get; set; }
        public int EntityEntitySeq { get; set; }
        public string EntityEntityRole { get; set; }
        public string Comment { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EntityRowKey
        {
            get { return EntityEntityKey; }
            set { EntityEntityKey = value; }
        }
    } // EntityEntity class closer
}