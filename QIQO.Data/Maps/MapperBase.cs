using System;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class MapperBase
    {
        public SqlParameter GetOutParam()
        {
            // for the output param @@identity or the current key
            SqlParameter outParam = new SqlParameter();
            outParam.ParameterName = "@key";
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Direction = ParameterDirection.Output;
            return outParam;
        }

        public SqlParameter GetIdentityOutParam()
        {
            // for the output param guid or the current id
            SqlParameter outParam = new SqlParameter();
            outParam.ParameterName = "@Id";
            outParam.SqlDbType = SqlDbType.VarChar;
            outParam.Direction = ParameterDirection.Output;
            return outParam;
        }

        public SqlParameter BuildParam(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }

        protected T NullCheck<T>(object checkValue)
        {
            T outValue;
            if (checkValue == DBNull.Value)
                outValue = default(T);
            else
                outValue = (T)checkValue;
            return outValue;
        }
    }
}
