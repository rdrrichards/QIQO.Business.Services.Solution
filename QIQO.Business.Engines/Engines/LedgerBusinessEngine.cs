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
    public class LedgerBusinessEngine : EngineBase, ILedgerBusinessEngine
    {
        public LedgerBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {

        }

        public bool LedgerDelete(Ledger ledger)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerRepository ledger_repo = _data_repository_factory.GetDataRepository<ILedgerRepository>();
                LedgerData ledger_data = MapLedgerToLedgerData(ledger);

                ledger_repo.Delete(ledger_data);
                return true;
            });
        }

        public int LedgerSave(Ledger ledger)
        {
            if (ledger == null)
                throw new ArgumentNullException(nameof(ledger));

            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerRepository ledger_repo = _data_repository_factory.GetDataRepository<ILedgerRepository>();

                int ledger_key;
                LedgerData prod_data = MapLedgerToLedgerData(ledger);

                ledger_key = ledger_repo.Insert(prod_data);

                return ledger_key;
            });
        }

        public Ledger GetLedgerByCode(string ledger_code, Company company)
        {
            return GetLedgerByCode(ledger_code, company.CompanyCode);
        }

        public Ledger GetLedgerByCode(string ledger_code, string company_code)
        {
            Log.Info("Accessing LedgerBusinessEngine GetLedgerByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerRepository ledger_repo = _data_repository_factory.GetDataRepository<ILedgerRepository>();
                LedgerData ledger_data = ledger_repo.GetByCode(ledger_code, company_code);
                Log.Info("LedgerBusinessEngine GetLedgerByCode function completed");

                if (ledger_data.LedgerKey != 0)
                {
                    Ledger ledger = MapLedgerDataToLedger(ledger_data);

                    return ledger;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Ledger with code {0} is not in database", ledger_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }
        public Ledger GetLedgerByID(int ledger_key)
        {
            Log.Info("Accessing LedgerBusinessEngine GetLedgerByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerRepository ledger_repo = _data_repository_factory.GetDataRepository<ILedgerRepository>();
                LedgerData ledger_data = ledger_repo.GetByID(ledger_key);
                Log.Info("LedgerBusinessEngine GetByID function completed");

                if (ledger_data.LedgerKey != 0)
                {
                    Ledger ledger = MapLedgerDataToLedger(ledger_data);

                    return ledger;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Ledger with key {0} is not in database", ledger_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Ledger> GetLedgersByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerRepository ledger_repo = _data_repository_factory.GetDataRepository<ILedgerRepository>();
                // _business_engine_factory
                List<Ledger> ledgers = new List<Ledger>();
                CompanyData comp = new CompanyData();
                comp.CompanyKey = company.CompanyKey;

                IEnumerable<LedgerData> ledgers_data = ledger_repo.GetAll(comp);

                foreach (LedgerData ledger_data in ledgers_data)
                {
                    Ledger ledger = MapLedgerDataToLedger(ledger_data);
                    ledgers.Add(ledger);
                }
                return ledgers;
            });
        }
        private Ledger MapLedgerDataToLedger(LedgerData ledger_data)
        {
            Ledger ledger = new Ledger()
            {
                AddedUserID = ledger_data.AuditAddUserId,
                AddedDateTime = ledger_data.AuditAddDatetime,
                UpdateUserID = ledger_data.AuditUpdateUserId,
                UpdateDateTime = ledger_data.AuditUpdateDatetime
            };

            return ledger;
        }
        private LedgerData MapLedgerToLedgerData(Ledger ledger)
        {
            LedgerData ledger_data = new LedgerData()
            {

            };

            return ledger_data;
        }
    }
}