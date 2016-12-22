using System;
using System.Collections.Generic;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities.Identity;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class UserClaimMapper : MapperBase, IUserClaimMap
    {
        public UserClaimData Map(DataRow record)
        {
            try
            {
                return new UserClaimData() {
                    Id = NullCheck<Guid>(record["ClaimId"]),
                    UserID = NullCheck<Guid>(record["UserID"]),
                    ClaimType = NullCheck<string>(record["ClaimType"]),
                    ClaimValue = NullCheck<string>(record["ClaimValue"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"RoleClaimMap Exception occured: {ex.Message}", ex);
            }
        }

        public UserClaimData Map(IDataReader record)
        {
            try
            {
                return new UserClaimData()
                {
                    Id = NullCheck<Guid>(record["ClaimId"]),
                    UserID = NullCheck<Guid>(record["UserID"]),
                    ClaimType = NullCheck<string>(record["ClaimType"]),
                    ClaimValue = NullCheck<string>(record["ClaimValue"])
                };
            }
            catch (Exception ex)
            {
                throw new MapException($"RoleClaimMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(UserClaimData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ClaimId", entity.Id));
            sql_params.Add(new SqlParameter("@UserId", entity.UserID));
            sql_params.Add(new SqlParameter("@ClaimType", entity.ClaimType));
            sql_params.Add(new SqlParameter("@ClaimValue", entity.ClaimValue));
            sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(UserClaimData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@ClaimId", entity.Id));
            return sql_params;
        }        
    }
}