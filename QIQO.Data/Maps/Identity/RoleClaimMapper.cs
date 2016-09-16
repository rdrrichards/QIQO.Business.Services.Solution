using System;
using System.Collections.Generic;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities.Identity;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class RoleClaimMapper : MapperBase, IRoleClaimMap
    {
        public RoleClaimData Map(DataRow record)
        {
            try
            {
                return new RoleClaimData() {
                    Id = NullCheck<Guid>(record["ClaimId"]),
                    RoleID = NullCheck<Guid>(record["RoleId"]),
                    ClaimType = NullCheck<string>(record["ClaimType"]),
                    ClaimValue = NullCheck<string>(record["ClaimValue"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"RoleClaimMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(RoleClaimData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ClaimId", entity.Id));
            sql_params.Add(new SqlParameter("@RoleId", entity.RoleID));
            sql_params.Add(new SqlParameter("@ClaimType", entity.ClaimType));
            sql_params.Add(new SqlParameter("@ClaimValue", entity.ClaimValue));
            sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(RoleClaimData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ClaimId", entity.Id));
            //sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }
    }
}