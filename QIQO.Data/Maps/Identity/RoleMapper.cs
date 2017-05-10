using System;
using System.Collections.Generic;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities.Identity;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class RoleMapper : MapperBase, IRoleMap
    {
        public RoleData Map(DataRow record)
        {
            try
            {
                return new RoleData() {
                    RoleId = NullCheck<Guid>(record["RoleId"]),
                    Name = NullCheck<string>(record["Name"]),
                    NormalizedName = NullCheck<string>(record["NormalizedName"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"RoleMap Exception occured: {ex.Message}", ex);
            }
        }

        public RoleData Map(IDataReader record)
        {
            try
            {
                return new RoleData()
                {
                    RoleId = NullCheck<Guid>(record["RoleId"]),
                    Name = NullCheck<string>(record["Name"]),
                    NormalizedName = NullCheck<string>(record["NormalizedName"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"RoleMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(RoleData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@RoleId", entity.RoleId));
            sql_params.Add(new SqlParameter("@Name", entity.Name));
            sql_params.Add(new SqlParameter("@NormalizedName", entity.NormalizedName));
            sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(RoleData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@RoleId", entity.RoleId));
            //sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }
    }
}