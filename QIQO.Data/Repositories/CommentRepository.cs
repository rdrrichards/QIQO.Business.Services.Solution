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
    public class CommentRepository : RepositoryBase<CommentData>, ICommentRepository
    {
        private IMainDBContext entity_context;
        
        public CommentRepository(IMainDBContext dbc, ICommentMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<CommentData> GetAll()
        {
            Log.Info("Accessing CommentRepo GetAll function");
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_all");
                Log.Info("CommentRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<CommentData> GetAll(int entity_key, int entity_type_key)
        {
            Log.Info("Accessing CommentRepo GetAll function");
            List<SqlParameter> pcol = new List<SqlParameter>()
            {
                new SqlParameter("@entity_key", entity_key),
                new SqlParameter("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_all_by_entity", pcol);
                Log.Info("CommentRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public override CommentData GetByID(int comment_key)
        {
            Log.Info("Accessing CommentRepo GetByID function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@comment_key", comment_key) };

            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_get", pcol);
                Log.Info("CommentRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_comment_get) function");
                return MapRow(ds);
            }
        }

        public override CommentData GetByCode(string comment_code, string entity_code)
        {
            Log.Info("Accessing CommentRepo GetByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>()
            {
                new SqlParameter("@comment_code", comment_code),
                new SqlParameter("@company_code", entity_code)
            };

            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_get_c", pcol);
                Log.Info("CommentRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_comment_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(CommentData entity)
        {
            Log.Info("Accessing CommentRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(CommentData entity)
        {
            Log.Info("Accessing CommentRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentData entity)
        {
            Log.Info("Accessing CommentRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing CommentRepo DeleteByCode function");
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@comment_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing CommentRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(CommentData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_comment_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}