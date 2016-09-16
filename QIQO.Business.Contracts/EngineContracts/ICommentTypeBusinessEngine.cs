using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface ICommentTypeBusinessEngine : ITypeBusinessEngine<CommentType>, IBusinessEngine
    {
        List<CommentType> GetTypesByCategory(string category);
    }
}