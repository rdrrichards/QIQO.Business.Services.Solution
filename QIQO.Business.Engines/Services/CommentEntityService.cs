using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class CommentEntityService : ICommentEntityService
    {
        public Comment Map(CommentData comment_data)
        {
            return new Comment()
            {
                CommentKey = comment_data.CommentKey,
                CommentType = (QIQOCommentType)comment_data.CommentTypeKey,
                CommentValue = comment_data.CommentValue,
                EntityKey = comment_data.EntityKey,
                EntityTypeKey = comment_data.EntityType,
                AddedUserID = comment_data.AuditAddUserId,
                AddedDateTime = comment_data.AuditAddDatetime,
                UpdateUserID = comment_data.AuditUpdateUserId,
                UpdateDateTime = comment_data.AuditUpdateDatetime
            };
        }

        public CommentData Map(Comment comment)
        {
            return new CommentData()
            {
                CommentKey = comment.CommentKey,
                CommentTypeKey = (int)comment.CommentType,
                CommentValue = comment.CommentValue,
                EntityKey = comment.EntityKey,
                EntityType = comment.EntityTypeKey
            };
        }
    }
}