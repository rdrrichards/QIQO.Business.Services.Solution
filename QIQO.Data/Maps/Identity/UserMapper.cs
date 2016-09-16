using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QIQO.Data.Entities.Identity;
using QIQO.Common.Core.Logging;

namespace QIQO.Data.Maps
{
    public class UserMapper : MapperBase, IUserMap
    {
        public UserData Map(DataRow record)
        {
            try
            {
                return new UserData()
                {
                    Id = NullCheck<Guid>(record["UserId"]),
                    Email = NullCheck<string>(record["Email"]),
                    NormalizedEmail = NullCheck<string>(record["NormalizedEmail"]),
                    EmailConfirmed = NullCheck<bool>(record["EmailConfirmed"]),
                    PasswordHash = NullCheck<string>(record["PasswordHash"]),
                    SecurityStamp = NullCheck<string>(record["SecurityStamp"]),
                    PhoneNumber = NullCheck<string>(record["PhoneNumber"]),
                    PhoneNumberConfirmed = NullCheck<bool>(record["PhoneNumberConfirmed"]),
                    TwoFactorEnabled = NullCheck<bool>(record["TwoFactorEnabled"]),
                    LockoutEnd = NullCheck<DateTimeOffset>(record["LockoutEnd"]),
                    LockoutEnabled = NullCheck<bool>(record["LockoutEnabled"]),
                    AccessFailedCount = NullCheck<int>(record["AccessFailedCount"]),
                    UserName = NullCheck<string>(record["UserName"]),
                    NormalizedUserName = NullCheck<string>(record["NormalizedUserName"])
                };
            }
            catch (Exception ex)
            {
                Log.Error($"UserMap Exception occured: {ex.Message}", ex);
                throw new MapException($"UserMap Exception occured: {ex.Message}", ex);
            }
        }

        public List<SqlParameter> MapParamsForUpsert(UserData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@UserId", entity.Id));
            sql_params.Add(new SqlParameter("@Email", entity.Email));
            sql_params.Add(new SqlParameter("@NormalizedEmail", entity.NormalizedEmail));
            sql_params.Add(new SqlParameter("@EmailConfirmed", entity.EmailConfirmed));
            sql_params.Add(new SqlParameter("@PasswordHash", entity.PasswordHash));
            sql_params.Add(new SqlParameter("@SecurityStamp", entity.SecurityStamp));
            sql_params.Add(new SqlParameter("@PhoneNumber", entity.PhoneNumber));
            sql_params.Add(new SqlParameter("@PhoneNumberConfirmed", entity.PhoneNumberConfirmed));
            sql_params.Add(new SqlParameter("@TwoFactorEnabled", entity.TwoFactorEnabled));
            sql_params.Add(new SqlParameter("@LockoutEnd", entity.LockoutEnd));
            sql_params.Add(new SqlParameter("@LockoutEnabled", entity.LockoutEnabled));
            sql_params.Add(new SqlParameter("@AccessFailedCount", entity.AccessFailedCount));
            sql_params.Add(new SqlParameter("@UserName", entity.UserName));
            sql_params.Add(new SqlParameter("@NormalizedUserName", entity.NormalizedUserName));
            //sql_params.Add(GetIdentityOutParam());
            return sql_params;
        }

        public List<SqlParameter> MapParamsForDelete(UserData entity)
        {
            var sql_params = new List<SqlParameter>();
            sql_params.Add(new SqlParameter("@UserId", entity.Id));
            return sql_params;
        }
    }
}
