using System;
using System.ServiceModel;
using System.Threading;
using QIQO.Common.Core;
using QIQO.Common.Contracts;
using QIQO.Business.Entities;

namespace QIQO.Business.Services
{
    public class ServiceBase
    {
        public ServiceBase()
        {
            OperationContext context = OperationContext.Current;
            if (context != null)
            {
                try
                {
                    _LoginName = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("String", "System");
                    if (_LoginName.IndexOf(@"\") > -1) _LoginName = string.Empty;
                }
                catch
                {
                    _LoginName = string.Empty;
                }
            }

            if (!string.IsNullOrWhiteSpace(_LoginName))
                _AuthorizationAccount = LoadAuthorizationValidationAccount(_LoginName);
        }

        protected virtual Account LoadAuthorizationValidationAccount(string loginName)
        {
            return null;
        }

        Account _AuthorizationAccount = null;
        string _LoginName = string.Empty;

        protected void ValidateAuthorization(IAccountOwnedEntity entity)
        {
            if (!Thread.CurrentPrincipal.IsInRole(Security.QIQOOrderEntryAdminRole))
            {
                if (_AuthorizationAccount != null)
                {
                    if (_LoginName != string.Empty && entity.OwnerAccountKey != _AuthorizationAccount.AccountKey)
                    {
                        AuthorizationValidationException ex = new AuthorizationValidationException("Attempt to access a secure record with improper user authorization validation.");
                        throw new FaultException<AuthorizationValidationException>(ex, ex.Message);
                    }
                }
            }
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codetoExecute)
        {
            try
            {
                return codetoExecute.Invoke();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
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
                throw ex;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
