using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IEntityPersonRepository : IRepository<EntityPersonData>
    {
        IEnumerable<EntityPersonData> GetAll(CompanyData company);
        IEnumerable<EntityPersonData> GetAll(AccountData account);
        void DeleteByObject(EntityPersonData entity);
        IEnumerable<EntityPersonData> GetAllReps(CompanyData company, int rep_type);
        EntityPersonData GetByPersonID(int person_key, int entity_type_key);
        int SavePersonSupervisor(int person_key, int entity_id, int entity_type_key);
    }
}