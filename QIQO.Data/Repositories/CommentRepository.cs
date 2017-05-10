using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_comment_all"));
            }
        }

        public IEnumerable<CommentData> GetAll(int entity_key, int entity_type_key)
        {
            Log.Info("Accessing CommentRepo GetAll function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@entity_key", entity_key),
                Mapper.BuildParam("@entity_type_key", entity_type_key)
            };
            using (entity_context)
            {
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_comment_all_by_entity", pcol));
            }
        }

        public override CommentData GetByID(int comment_key)
        {
            Log.Info("Accessing CommentRepo GetByID function");
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_key", comment_key) };

            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_comment_get", pcol));
            }
        }

        public override CommentData GetByCode(string comment_code, string entity_code)
        {
            Log.Info("Accessing CommentRepo GetByCode function");
            var pcol = new List<SqlParameter>()
            {
                Mapper.BuildParam("@comment_code", comment_code),
                Mapper.BuildParam("@company_code", entity_code)
            };

            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_comment_get_c", pcol));
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
            var pcol = new List<SqlParameter>() { Mapper.BuildParam("@comment_code", entity_code) };
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