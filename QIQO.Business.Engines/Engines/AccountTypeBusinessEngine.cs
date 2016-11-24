using System;
using System.Linq;
using QIQO.Business.Entities;
using QIQO.Data.Interfaces;
using QIQO.Common.Contracts;
using System.Collections.Generic;
using QIQO.Data.Entities;
using QIQO.Business.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;

namespace QIQO.Business.Engines
{
    public class AccountTypeBusinessEngine : EngineBase, IAccountTypeBusinessEngine  // Try building a base class that implements this and use it
    {
        private readonly ICache _cache;
        private readonly IAccountTypeRepository _repo_acct_type;
        private readonly IAccountTypeEntityService _acct_es;

        public AccountTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_acct_type = _data_repository_factory.GetDataRepository<IAccountTypeRepository>();
            _acct_es = _entity_service_factory.GetEntityService<IAccountTypeEntityService>();
        }


        public List<AccountType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<AccountType> account_types = _cache.Get(CacheKeys.AccountTypes) as List<AccountType>;
                if (account_types == null)
                {
                    Log.Debug("AccountTypeRepository GetAll called");
                    account_types = new List<AccountType>();

                    var account_type_data = _repo_acct_type.GetAll();

                    foreach (var account_type in account_type_data)
                    {
                        account_types.Add(_acct_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.AccountTypes, account_types);
                    Log.Debug("AccountTypeRepository GetAll complete");
                }
                return account_types;
                //return null;
            });
        }

        public int AddOrUpdateType(AccountType account_type)
        {
            if (account_type == null)
                throw new ArgumentNullException(nameof(account_type));

            return ExecuteFaultHandledOperation(() =>
            {
                var account_type_data = _acct_es.Map(account_type);
                return _repo_acct_type.Insert(account_type_data);
            });
        }

        public bool DeleteType(AccountType account_type)
        {
            if (account_type == null)
                throw new ArgumentNullException(nameof(account_type));

            return ExecuteFaultHandledOperation(() =>
            {
                var account_type_data = _acct_es.Map(account_type);
                _repo_acct_type.Delete(account_type_data);
                return true;
            });
        }

        public AccountType GetTypeByKey(int account_type_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var account_types = _cache.Get(CacheKeys.AccountTypes) as List<AccountType>;
                if (account_types != null)
                    return account_types.Where(item => item.AccountTypeKey == account_type_key).FirstOrDefault();
                return GetTypes().Where(item => item.AccountTypeKey == account_type_key).FirstOrDefault();
            });
        }
    }
}
