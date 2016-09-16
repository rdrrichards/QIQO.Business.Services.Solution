using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class CommentData : CommonData, IEntity
    { // Comment class opener
        public int CommentKey { get; set; }
        public int EntityKey { get; set; }
        public int EntityType { get; set; }
        public int CommentTypeKey { get; set; }
        public string CommentValue { get; set; }

        public int EntityRowKey
        {
            get { return CommentKey; }
            set { CommentKey = value; }
        }
    } // Comment class closer
}