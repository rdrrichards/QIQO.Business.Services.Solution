using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class UserSessionRepository : RepositoryBase<UserSessionData>, IUserSessionRepository
    {
        private IMainDBContext entity_context;

        public UserSessionRepository(IMainDBContext dbc, IUserSessionMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<UserSessionData> GetAll()
        {
            Log.Info("Accessing UserSessionRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_session_all");
                Log.Info("UserSessionRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override UserSessionData GetByID(int user_session_key)
        {
            Log.Info("Accessing UserSessionRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@session_key", user_session_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_session_get_by_key", pcol);
                Log.Info("UserSessionRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_user_session_get_by_key) function");
                return MapRow(ds);
            }
        }

        public override UserSessionData GetByCode(string user_session_code, string entity_code)
        {
            Log.Info("Accessing UserSessionRepo GetByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@user_session_code", user_session_code) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_user_session_get_by_code", pcol);
                Log.Info("UserSessionRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_user_session_get_by_code) function");
                return MapRow(ds);
            }
        }

        public override int Insert(UserSessionData entity)
        {
            Log.Info("Accessing UserSessionRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(UserSessionData entity)
        {
            Log.Info("Accessing UserSessionRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(UserSessionData entity)
        {
            Log.Info("Accessing UserSessionRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_session_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing UserSessionRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@user_session_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_session_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing UserSessionRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_user_session_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(UserSessionData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_user_session_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}