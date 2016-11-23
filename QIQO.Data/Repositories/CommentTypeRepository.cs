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
    public class CommentTypeRepository : RepositoryBase<CommentTypeData>, ICommentTypeRepository
    {
        private IMainDBContext entity_context;
        
        public CommentTypeRepository(IMainDBContext dbc, ICommentTypeMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override IEnumerable<CommentTypeData> GetAll()
        {
            Log.Info("Accessing CommentTypeRepo GetAll function");
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_type_all");
                Log.Info("CommentTypeRepo ExecuteProcedureAsDataSet function call successful");
                return MapRows(ds);
            }
        }

        public IEnumerable<CommentTypeData> GetAllByCategory(string category)
        {
            Log.Info("Accessing CommentTypeRepo GetAllByCategory function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@comment_type_category", category) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_type_get_cat", pcol);
                Log.Info("CommentTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_comment_type_get_cat) function");
                return MapRows(ds);
            }
        }

        public override CommentTypeData GetByID(int comment_type_key)
        {
            Log.Info("Accessing CommentTypeRepo GetByID function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@comment_type_key", comment_type_key) };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_type_get", pcol);
                Log.Info("CommentTypeRepo (GetByID) Passed ExecuteProcedureAsDataSet (usp_comment_type_get) function");
                return MapRow(ds);
            }
        }

        public override CommentTypeData GetByCode(string comment_type_code, string entity_code)
        {
            Log.Info("Accessing CommentTypeRepo GetByCode function");
            var pcol = new List<SqlParameter>() {
                new SqlParameter("@comment_type_code", comment_type_code),
                new SqlParameter("@company_code", entity_code)
            };
            using (entity_context)
            {
                var ds = entity_context.ExecuteProcedureAsDataSet("usp_comment_type_get_c", pcol);
                Log.Info("CommentTypeRepo (GetByCode) Passed ExecuteProcedureAsDataSet (usp_comment_type_get_c) function");
                return MapRow(ds);
            }
        }

        public override int Insert(CommentTypeData entity)
        {
            Log.Info("Accessing CommentTypeRepo Insert function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override int Save(CommentTypeData entity)
        {
            Log.Info("Accessing CommentTypeRepo Save function");
            if (entity != null)
                return Upsert(entity);
            else
                throw new ArgumentException(nameof(entity));
        }

        public override void Delete(CommentTypeData entity)
        {
            Log.Info("Accessing CommentTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_type_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override void DeleteByCode(string entity_code)
        {
            Log.Info("Accessing CommentTypeRepo DeleteByCode function");
            var pcol = new List<SqlParameter>() { new SqlParameter("@comment_type_code", entity_code) };
            pcol.Add(Mapper.GetOutParam());
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_type_del_c", pcol);
            }
        }

        public override void DeleteByID(int entity_key)
        {
            Log.Info("Accessing CommentTypeRepo Delete function");
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_comment_type_del", Mapper.MapParamsForDelete(entity_key));
            }
        }

        private int Upsert(CommentTypeData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_comment_type_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}