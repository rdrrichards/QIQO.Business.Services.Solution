using System;
using System.Collections.Generic;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities.Identity;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class UserRoleMapper : MapperBase, IUserRoleMap
    {
        public UserRoleData Map(DataRow record)
        {
            try
            {
                return new UserRoleData() {
                    RoleID = NullCheck<Guid>(record["RoleID"]),
                    UserID = NullCheck<Guid>(record["UserID"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("UserRoleMap Exception occured", ex);
            }
        }

        public UserRoleData Map(IDataReader record)
        {
            try
            {
                return new UserRoleData()
                {
                    RoleID = NullCheck<Guid>(record["RoleID"]),
                    UserID = NullCheck<Guid>(record["UserID"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException("UserRoleMap Exception occured", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(UserRoleData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@RoleID", entity.RoleID));
            sql_params.Add(new SqlParameter("@UserId", entity.UserID));
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(UserRoleData entity)
        {
            return MapParamsForUpsert(entity);
        }
    }
}