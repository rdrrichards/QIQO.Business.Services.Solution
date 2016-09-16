using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class FeeScheduleBusinessEngine : EngineBase, IFeeScheduleBusinessEngine
    {
        private readonly IFeeScheduleRepository _fee_schedule_repo;
        private readonly IFeeScheduleEntityService _fee_sched_es;
        public FeeScheduleBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _fee_schedule_repo = _data_repository_factory.GetDataRepository<IFeeScheduleRepository>();
            _fee_sched_es = _entity_service_factory.GetEntityService<IFeeScheduleEntityService>();
        }

        public bool FeeScheduleDelete(FeeSchedule fee_schedule)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var fee_schedule_data = _fee_sched_es.Map(fee_schedule);
                _fee_schedule_repo.Delete(fee_schedule_data);
                return true;
            });
        }

        public int FeeScheduleSave(FeeSchedule fee_schedule)
        {
            if (fee_schedule == null)
                throw new ArgumentNullException(nameof(fee_schedule));

            return ExecuteFaultHandledOperation(() =>
            {
                var prod_data = _fee_sched_es.Map(fee_schedule);
                return _fee_schedule_repo.Insert(prod_data);
            });
        }

        public FeeSchedule GetFeeScheduleByID(int fee_schedule_key)
        {
            Log.Info("Accessing FeeScheduleBusinessEngine GetFeeScheduleByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                
                var fee_schedule_data = _fee_schedule_repo.GetByID(fee_schedule_key);
                Log.Info("FeeScheduleBusinessEngine GetByID function completed");

                if (fee_schedule_data.FeeScheduleKey != 0)
                {
                    FeeSchedule fee_schedule = _fee_sched_es.Map(fee_schedule_data);
                    return fee_schedule;
                }
                else
                {
                    NotFoundException ex = new NotFoundException($"FeeSchedule with key {fee_schedule_key} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<FeeSchedule> GetFeeSchedulesByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var fee_schedules = new List<FeeSchedule>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var fee_schedule_data = _fee_schedule_repo.GetAll(comp);

                foreach (FeeScheduleData fee_sched in fee_schedule_data)
                {
                    var fee_schedule = _fee_sched_es.Map(fee_sched);
                    fee_schedules.Add(fee_schedule);
                }
                return fee_schedules;
            });
        }

        public List<FeeSchedule> GetFeeSchedulesByAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return ExecuteFaultHandledOperation(() =>
            {
                var fee_schedules = new List<FeeSchedule>();
                var acct = new AccountData() { AccountKey = account.AccountKey };
                var fee_schedule_data = _fee_schedule_repo.GetAll(acct);

                foreach (FeeScheduleData fee_sched in fee_schedule_data)
                {
                    FeeSchedule fee_schedule = _fee_sched_es.Map(fee_sched);
                    fee_schedules.Add(fee_schedule);
                }
                return fee_schedules;
            });
        }

        public List<FeeSchedule> GetFeeSchedulesByProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            return ExecuteFaultHandledOperation(() =>
            {
                var fee_schedules = new List<FeeSchedule>();
                var prod = new ProductData() { ProductKey = product.ProductKey };
                var fee_schedule_data = _fee_schedule_repo.GetAll(prod);

                foreach (FeeScheduleData fee_sched in fee_schedule_data)
                {
                    FeeSchedule fee_schedule = _fee_sched_es.Map(fee_sched);
                    fee_schedules.Add(fee_schedule);
                }
                return fee_schedules;
            });
        }
    }
}