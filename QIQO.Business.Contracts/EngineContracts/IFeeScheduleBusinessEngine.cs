using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IFeeScheduleBusinessEngine : IBusinessEngine
    {
        bool FeeScheduleDelete(FeeSchedule fee_schedule);
        int FeeScheduleSave(FeeSchedule fee_schedule);
        FeeSchedule GetFeeScheduleByID(int fee_schedule_key);
        List<FeeSchedule> GetFeeSchedulesByCompany(Company company);
        List<FeeSchedule> GetFeeSchedulesByAccount(Account account);
        List<FeeSchedule> GetFeeSchedulesByProduct(Product product);
    }
}