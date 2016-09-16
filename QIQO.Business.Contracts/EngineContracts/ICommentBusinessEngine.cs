using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface ICommentBusinessEngine : IBusinessEngine
    {
        bool CommentDelete(Comment comment);
        int CommentSave(Comment comment);
        List<Comment> GetCommentsByEntity(int entity_key, QIQOEntityType entity_type);
    }
}