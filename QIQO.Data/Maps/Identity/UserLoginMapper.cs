using System;
using System.Collections.Generic;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities.Identity;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class UserLoginMapper : MapperBase, IUserLoginMap
    {
        public UserLoginData Map(DataRow record)
        {
            try
            {
                return new UserLoginData() {
                    LoginProvider = NullCheck<string>(record["LoginProvider"]),
                    UserID = NullCheck<Guid>(record["UserID"]),
                    ProviderKey = NullCheck<string>(record["ProviderKey"]),
                    ProviderDisplayName = NullCheck<string>(record["ProviderDisplayName"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("UserLoginMap Exception occured", ex);
            }
        }

        public UserLoginData Map(IDataReader record)
        {
            try
            {
                return new UserLoginData()
                {
                    LoginProvider = NullCheck<string>(record["LoginProvider"]),
                    UserID = NullCheck<Guid>(record["UserID"]),
                    ProviderKey = NullCheck<string>(record["ProviderKey"]),
                    ProviderDisplayName = NullCheck<string>(record["ProviderDisplayName"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("UserLoginMap Exception occured", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(UserLoginData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@LoginProvider", entity.LoginProvider));
            sql_params.Add(new SqlParameter("@UserId", entity.UserID));
            sql_params.Add(new SqlParameter("@ProviderKey", entity.ProviderKey));
            sql_params.Add(new SqlParameter("@ProviderDisplayName", entity.ProviderDisplayName));
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(UserLoginData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@LoginProvider", entity.LoginProvider));
            sql_params.Add(new SqlParameter("@ProviderKey", entity.ProviderKey));
            sql_params.Add(new SqlParameter("@UserId", entity.UserID));
            return sql_params;
        }
    }
}