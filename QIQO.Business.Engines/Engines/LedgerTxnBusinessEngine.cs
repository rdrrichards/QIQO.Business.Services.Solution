using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class LedgerTxnBusinessEngine : EngineBase, ILedgerTxnBusinessEngine
    {
        public LedgerTxnBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {

        }

        public bool LedgerTxnDelete(LedgerTxn ledger_txn)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerTxnRepository ledger_txn_repo = _data_repository_factory.GetDataRepository<ILedgerTxnRepository>();
                LedgerTxnData ledger_txn_data = MapLedgerTxnToLedgerTxnData(ledger_txn);

                ledger_txn_repo.Delete(ledger_txn_data);
                return true;
            });
        }

        public int LedgerTxnSave(LedgerTxn ledger_txn)
        {
            if (ledger_txn == null)
                throw new ArgumentNullException(nameof(ledger_txn));

            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerTxnRepository ledger_txn_repo = _data_repository_factory.GetDataRepository<ILedgerTxnRepository>();

                int ledger_txn_key;
                LedgerTxnData prod_data = MapLedgerTxnToLedgerTxnData(ledger_txn);

                ledger_txn_key = ledger_txn_repo.Insert(prod_data);

                return ledger_txn_key;
            });
        }

        public LedgerTxn GetLedgerTxnByCode(string ledger_txn_code, Company company)
        {
            return GetLedgerTxnByCode(ledger_txn_code, company.CompanyCode);
        }

        public LedgerTxn GetLedgerTxnByCode(string ledger_txn_code, string company_code)
        {
            Log.Info("Accessing LedgerTxnBusinessEngine GetLedgerTxnByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerTxnRepository ledger_txn_repo = _data_repository_factory.GetDataRepository<ILedgerTxnRepository>();
                LedgerTxnData ledger_txn_data = ledger_txn_repo.GetByCode(ledger_txn_code, company_code);
                Log.Info("LedgerTxnBusinessEngine GetLedgerTxnByCode function completed");

                if (ledger_txn_data.LedgerTxnKey != 0)
                {
                    LedgerTxn ledger_txn = MapLedgerTxnDataToLedgerTxn(ledger_txn_data);

                    return ledger_txn;
                }
                else
                {
                NotFoundException ex = new NotFoundException(string.Format("LedgerTxn with code {0} is not in database", ledger_txn_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public LedgerTxn GetLedgerTxnByID(int ledger_txn_key)
        {
            Log.Info("Accessing LedgerTxnBusinessEngine GetLedgerTxnByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                ILedgerTxnRepository ledger_txn_repo = _data_repository_factory.GetDataRepository<ILedgerTxnRepository>();
                LedgerTxnData ledger_txn_data = ledger_txn_repo.GetByID(ledger_txn_key);
                Log.Info("LedgerTxnBusinessEngine GetByID function completed");

                if (ledger_txn_data.LedgerTxnKey != 0)
                {
                    LedgerTxn ledger_txn = MapLedgerTxnDataToLedgerTxn(ledger_txn_data);

                    return ledger_txn;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("LedgerTxn with key {0} is not in database", ledger_txn_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        //public List<LedgerTxn> GetLedgerTxnsByCompany(Company company)
        //{
        //    if (company == null)
        //        throw new ArgumentNullException(nameof(company));

        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        ILedgerTxnRepository ledger_txn_repo = _data_repository_factory.GetDataRepository<ILedgerTxnRepository>();
        //        // _business_engine_factory
        //        List<LedgerTxn> ledger_txns = new List<LedgerTxn>();
        //        CompanyData comp = new CompanyData();
        //        comp.CompanyKey = company.CompanyKey;

        //        IEnumerable<LedgerTxnData> ledger_txns_data = ledger_txn_repo.GetAll(comp);

        //        foreach (LedgerTxnData ledger_txn_data in ledger_txns_data)
        //        {
        //            LedgerTxn ledger_txn = MapLedgerTxnDataToLedgerTxn(ledger_txn_data);
        //            ledger_txns.Add(ledger_txn);
        //        }
        //        return ledger_txns;
        //    });
        //}

        private LedgerTxn MapLedgerTxnDataToLedgerTxn(LedgerTxnData ledger_txn_data)
        {
            LedgerTxn ledger_txn = new LedgerTxn()
            {
                AddedUserID = ledger_txn_data.AuditAddUserId,
                AddedDateTime = ledger_txn_data.AuditAddDatetime,
                UpdateUserID = ledger_txn_data.AuditUpdateUserId,
                UpdateDateTime = ledger_txn_data.AuditUpdateDatetime
            };

            return ledger_txn;
        }
        private LedgerTxnData MapLedgerTxnToLedgerTxnData(LedgerTxn ledger_txn)
        {
            LedgerTxnData ledger_txn_data = new LedgerTxnData()
            {

            };

            return ledger_txn_data;
        }
    }
}