using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    public class Comment
    {
        [DataMember]
        public int CommentKey { get; set; }
        [DataMember]
        public int EntityKey { get; set; }
        [DataMember]
        public int EntityTypeKey { get; set; }
        [DataMember]
        public QIQOCommentType CommentType { get; set; }
        [DataMember]
        public string CommentValue { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }
    }
}
