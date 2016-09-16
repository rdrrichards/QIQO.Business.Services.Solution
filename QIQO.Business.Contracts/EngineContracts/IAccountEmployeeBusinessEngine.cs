using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAccountEmployeeBusinessEngine : IBusinessEngine
    {
        List<AccountPerson> GetEmployeeListByAccount(Account account);
        int EmployeeSave(Account account, AccountPerson employee, string role, string comment);
        bool EmployeeDelete(Account account, AccountPerson employee);
    }
}