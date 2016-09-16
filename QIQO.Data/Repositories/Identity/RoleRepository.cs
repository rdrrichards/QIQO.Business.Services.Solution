using QIQO.Common.Contracts;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities.Identity;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Repositories
{
    public class RoleRepository : IdentityRepositoryBase<RoleData>, IRoleRepository
    {
        private IIdentityDBContext entity_context;

        public RoleRepository(IIdentityDBContext dbc, IRoleMap map_factory) : base(map_factory)
        {
            entity_context = dbc;
        }

        public override void Delete(RoleData entity)
        {
            using (entity_context)
            {
                entity_context.ExecuteProcedureNonQuery("usp_role_del", Mapper.MapParamsForDelete(entity));
            }
        }

        public override IEnumerable<RoleData> GetAll()
        {
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_role_all");
                Log.Info("RoleRepository GetAll function call successful");
                return MapRows(ds);
            }
        }

        public override RoleData GetByID(Guid id)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@RoleId", id) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_role_get_by_id", pcol);
                Log.Info("RoleRepository (GetByID) Passed ExecuteProcedureAsDataSet (usp_role_get) function");
                return MapRow(ds);
            }
        }

        public override RoleData GetByName(string name)
        {
            List<SqlParameter> pcol = new List<SqlParameter>() { new SqlParameter("@Name", name) };
            using (entity_context)
            {
                DataSet ds = entity_context.ExecuteProcedureAsDataSet("usp_role_get_by_name", pcol);
                Log.Info("RoleRepository (GetByName) Passed ExecuteProcedureAsDataSet (usp_role_get_by_name) function");
                return MapRow(ds);
            }
        }

        public override int Save(RoleData entity)
        {
            using (entity_context)
            {
                return entity_context.ExecuteProcedureNonQuery("usp_role_ups", Mapper.MapParamsForUpsert(entity));
            }
        }
    }
}