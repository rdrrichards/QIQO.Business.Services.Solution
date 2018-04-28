using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class FeeScheduleEntityService : IFeeScheduleEntityService
    {
        public FeeSchedule Map(FeeScheduleData fee_schedule_data)
        {
            return new FeeSchedule()
            {
                FeeScheduleKey = fee_schedule_data.FeeScheduleKey,
                CompanyKey = fee_schedule_data.CompanyKey,
                AccountKey = fee_schedule_data.AccountKey,
                ProductKey = fee_schedule_data.ProductKey,
                FeeScheduleStartDate = fee_schedule_data.FeeScheduleStartDate,
                FeeScheduleEndDate = fee_schedule_data.FeeScheduleEndDate,
                FeeScheduleTypeCode = fee_schedule_data.FeeScheduleType,
                FeeScheduleValue = fee_schedule_data.FeeScheduleValue,
                AddedUserID = fee_schedule_data.AuditAddUserId,
                AddedDateTime = fee_schedule_data.AuditAddDatetime,
                UpdateUserID = fee_schedule_data.AuditUpdateUserId,
                UpdateDateTime = fee_schedule_data.AuditUpdateDatetime,
                ProductDesc = fee_schedule_data.ProductDesc,
                ProductCode = fee_schedule_data.ProductCode,
                AccountCode = fee_schedule_data.AccountCode,
                AccountName = fee_schedule_data.AccountName
            };
        }

        public FeeScheduleData Map(FeeSchedule fee_schedule)
        {
            return new FeeScheduleData()
            {
                FeeScheduleKey = fee_schedule.FeeScheduleKey,
                CompanyKey = fee_schedule.CompanyKey,
                AccountKey = fee_schedule.AccountKey,
                ProductKey = fee_schedule.ProductKey,
                FeeScheduleStartDate = fee_schedule.FeeScheduleStartDate,
                FeeScheduleEndDate = fee_schedule.FeeScheduleEndDate,
                FeeScheduleType = fee_schedule.FeeScheduleTypeCode,
                FeeScheduleValue = fee_schedule.FeeScheduleValue
            };
        }
    }
}
