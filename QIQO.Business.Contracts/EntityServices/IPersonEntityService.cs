using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface IPersonEntityService : IEntityService
    {
        Employee Map(PersonData person_data);
        PersonData Map(Employee employee);
        PersonData Map(AccountPerson employee);
        void InitPersonData(AccountPerson person, PersonData emp_data);
        void InitPersonData(Employee person, PersonData emp_data);
        void Map(EntityPersonData per_data, Employee emp_data);
        Employee Map(EntityPersonData emp_data);
        PersonType Map(PersonTypeData person_type_data);
        PersonTypeData Map(PersonType person_type);
    }
}