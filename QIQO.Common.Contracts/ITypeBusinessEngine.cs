using System.Collections.Generic;

namespace QIQO.Common.Contracts
{
    public interface ITypeBusinessEngine
    {

    }

    public interface ITypeBusinessEngine<T> : ITypeBusinessEngine
        where T : class, IType, new()
    {
        List<T> GetTypes();
        int AddOrUpdateType(T type);
        bool DeleteType(T type);
        T GetTypeByKey(int type);
    }
}
