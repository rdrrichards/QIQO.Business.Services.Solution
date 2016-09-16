using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface IFeeScheduleEntityService : IEntityService
    {
        FeeSchedule Map(FeeScheduleData fee_schedule_data);
        FeeScheduleData Map(FeeSchedule fee_schedule);
    }
}