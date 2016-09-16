using System;
using System.ServiceModel;
using QIQO.Common.Core.Logging;
using QIQO.Common.Contracts;

namespace QIQO.Business.Engines
{
    public class EngineBase
    {
        protected IDataRepositoryFactory _data_repository_factory;
        protected IBusinessEngineFactory _business_engine_factory;
        protected IEntityServiceFactory _entity_service_factory;

        public EngineBase(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
        {
            _data_repository_factory = data_repo_fact;
            _business_engine_factory = bus_eng_fact;
            _entity_service_factory = ent_serv_fact;
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (FaultException ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                    throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codetoExecute)
        {
            try
            {
                codetoExecute.Invoke();
            }
            catch (FaultException ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Source}:{ex.Message}");
                throw new FaultException(ex.Message);
            }
        }
    }
}
