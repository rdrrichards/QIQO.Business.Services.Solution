using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface ICommentTypeRepository : IRepository<CommentTypeData>
    {
        IEnumerable<CommentTypeData> GetAllByCategory(string category);
    }
}