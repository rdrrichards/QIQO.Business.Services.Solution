using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class CommentTypeData : CommonData, IEntity
    { // CommentType class opener
        public int CommentTypeKey { get; set; }
        public string CommentTypeCategory { get; set; }
        public string CommentTypeCode { get; set; }
        public string CommentTypeName { get; set; }
        public string CommentTypeDesc { get; set; }

        public int EntityRowKey
        {
            get { return CommentTypeKey; }
            set { CommentTypeKey = value; }
        }
    } // CommentType class closer
}