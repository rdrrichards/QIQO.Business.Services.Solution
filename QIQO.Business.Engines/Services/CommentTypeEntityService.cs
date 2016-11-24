using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class CommentTypeEntityService : ICommentTypeEntityService
    {
        public CommentType Map(CommentTypeData comment_type_data)
        {
            return new CommentType()
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
        }

        public CommentTypeData Map(CommentType comment_type)
        {
            return new CommentTypeData()
            {
                CommentTypeKey = comment_type.CommentTypeKey,
                CommentTypeCategory = comment_type.CommentTypeCategory,
                CommentTypeCode = comment_type.CommentTypeCode,
                CommentTypeName = comment_type.CommentTypeName,
                CommentTypeDesc = comment_type.CommentTypeDesc
            };
        }
    }
}