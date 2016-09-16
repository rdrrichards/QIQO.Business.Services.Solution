using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class CommentEntityService : ICommentEntityService
    {
        public Comment Map(CommentData comment_data)
        {
            Comment comment = new Comment()
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

            return comment;
        }
        public CommentData Map(Comment comment)
        {
            CommentData comment_data = new CommentData()
            {
                CommentKey = comment.CommentKey,
                CommentTypeKey = (int)comment.CommentType,
                CommentValue = comment.CommentValue,
                EntityKey = comment.EntityKey,
                EntityType = comment.EntityTypeKey
            };

            return comment_data;
        }
        public CommentType Map(CommentTypeData comment_type_data)
        {
            CommentType CommentType = new CommentType()
            {
                CommentTypeKey = comment_type_data.CommentTypeKey,
                CommentTypeCategory = comment_type_data.CommentTypeCategory,
                CommentTypeCode = comment_type_data.CommentTypeCode,
                CommentTypeName = comment_type_data.CommentTypeName,
                CommentTypeDesc = comment_type_data.CommentTypeDesc,
                AddedUserID = comment_type_data.AuditAddUserId,
                AddedDateTime = comment_type_data.AuditAddDatetime,
                UpdateUserID = comment_type_data.AuditUpdateUserId,
                UpdateDateTime = comment_type_data.AuditUpdateDatetime
            };

            return CommentType;
        }

        public CommentTypeData Map(CommentType comment_type)
        {
            CommentTypeData CommentType_data = new CommentTypeData()
            {
                CommentTypeKey = comment_type.CommentTypeKey,
                CommentTypeCategory = comment_type.CommentTypeCategory,
                CommentTypeCode = comment_type.CommentTypeCode,
                CommentTypeName = comment_type.CommentTypeName,
                CommentTypeDesc = comment_type.CommentTypeDesc
            };

            return CommentType_data;
        }
    }
}
