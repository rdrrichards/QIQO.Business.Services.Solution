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
                return MapRows(entity_context.ExecuteProcedureAsSqlDataReader("usp_role_all"));
            }
        }

        public override RoleData GetByID(Guid id)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@RoleId", id) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_role_get_by_id", pcol));
            }
        }

        public override RoleData GetByName(string name)
        {
            var pcol = new List<SqlParameter>() { new SqlParameter("@Name", name) };
            using (entity_context)
            {
                return MapRow(entity_context.ExecuteProcedureAsSqlDataReader("usp_role_get_by_name", pcol));
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