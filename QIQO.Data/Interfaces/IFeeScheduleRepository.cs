using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IFeeScheduleRepository : IRepository<FeeScheduleData>
    {
        IEnumerable<FeeScheduleData> GetAll(AccountData account);
        IEnumerable<FeeScheduleData> GetAll(CompanyData company);
        IEnumerable<FeeScheduleData> GetAll(ProductData product);
    }
}