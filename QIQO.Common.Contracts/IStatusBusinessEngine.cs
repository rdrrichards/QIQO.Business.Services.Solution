using System.Collections.Generic;

namespace QIQO.Common.Contracts
{
    public interface IStatusBusinessEngine
    {

    }

    public interface IStatusBusinessEngine<T> : IStatusBusinessEngine
        where T : class, IStatusData, new()
    {
        List<T> GetStatuses();
        int SaveStatus(T status);
        bool DeleteStatus(T status);
        T GetStatusByKey(int status);
    }
}
