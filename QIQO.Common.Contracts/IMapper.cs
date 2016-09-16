using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Common.Contracts
{
    public interface IMapper
    {
    }

    public interface IMapper<T> : IMapper
    {
        T Map(DataRow row);
        List<SqlParameter> MapParamsForUpsert(T entity);
        List<SqlParameter> MapParamsForDelete(T entity);
        List<SqlParameter> MapParamsForDelete(int entity_key);
        SqlParameter GetOutParam();
    }

    public interface IIdentityMapper
    {
    }

    public interface IIdentityMapper<T> : IMapper
    {
        T Map(DataRow row);
        List<SqlParameter> MapParamsForUpsert(T entity);
        List<SqlParameter> MapParamsForDelete(T entity);
        SqlParameter GetOutParam();
    }
}
