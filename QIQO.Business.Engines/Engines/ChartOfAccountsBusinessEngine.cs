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
    public class ChartOfAccountBusinessEngine : EngineBase, IChartOfAccountBusinessEngine
    {
        private readonly IChartOfAccountsRepository _chart_of_accounts_repo;
        private readonly IChartOfAccountEntityService _chart_of_accounts_es;
        public ChartOfAccountBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _chart_of_accounts_repo = _data_repository_factory.GetDataRepository<IChartOfAccountsRepository>();
            _chart_of_accounts_es = _entity_service_factory.GetEntityService<IChartOfAccountEntityService>();
        }

        public bool ChartOfAccountDelete(ChartOfAccount chart_of_account)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var chart_of_accounts_data = _chart_of_accounts_es.Map(chart_of_account);
                _chart_of_accounts_repo.Delete(chart_of_accounts_data);
                return true;
            });
        }

        public int ChartOfAccountSave(ChartOfAccount chart_of_accounts)
        {
            if (chart_of_accounts == null)
                throw new ArgumentNullException(nameof(chart_of_accounts));

            return ExecuteFaultHandledOperation(() =>
            {
                int chart_of_accounts_key;
                var prod_data = _chart_of_accounts_es.Map(chart_of_accounts);
                chart_of_accounts_key = _chart_of_accounts_repo.Insert(prod_data);

                return chart_of_accounts_key;
            });
        }

        public ChartOfAccount GetChartOfAccountByCode(string chart_of_accounts_code, Company company)
        {
            return GetChartOfAccountByCode(chart_of_accounts_code, company.CompanyCode);
        }

        public ChartOfAccount GetChartOfAccountByCode(string chart_of_accounts_code, string company_code)
        {
            Log.Info("Accessing ChartOfAccountBusinessEngine GetChartOfAccountByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                ChartOfAccountsData chart_of_accounts_data = _chart_of_accounts_repo.GetByCode(chart_of_accounts_code, company_code);
                Log.Info("ChartOfAccountBusinessEngine GetChartOfAccountByCode function completed");

                if (chart_of_accounts_data.CoaKey != 0)
                {
                    var chart_of_accounts = _chart_of_accounts_es.Map(chart_of_accounts_data);
                    return chart_of_accounts;
                }
                else
                {
                    NotFoundException ex = new NotFoundException($"ChartOfAccount with code {chart_of_accounts_code} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }
        public ChartOfAccount GetChartOfAccountByID(int chart_of_accounts_key)
        {

            Log.Info("Accessing ChartOfAccountBusinessEngine GetChartOfAccountByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                ChartOfAccountsData chart_of_accounts_data = _chart_of_accounts_repo.GetByID(chart_of_accounts_key);
                Log.Info("ChartOfAccountBusinessEngine GetByID function completed");

                if (chart_of_accounts_data.CoaKey != 0)
                {
                    var chart_of_accounts = _chart_of_accounts_es.Map(chart_of_accounts_data);
                    return chart_of_accounts;
                }
                else
                {
                     NotFoundException ex = new NotFoundException($"ChartOfAccount with key {chart_of_accounts_key} is not in database");
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<ChartOfAccount> GetChartOfAccountsByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var chart_of_accounts = new List<ChartOfAccount>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };

                var chart_of_accounts_data = _chart_of_accounts_repo.GetAll(comp);

                foreach (ChartOfAccountsData chart_of_account_data in chart_of_accounts_data)
                {
                    var chart_of_account = _chart_of_accounts_es.Map(chart_of_account_data);
                    chart_of_accounts.Add(chart_of_account);
                }
                return chart_of_accounts;
            });
        }
    }
}