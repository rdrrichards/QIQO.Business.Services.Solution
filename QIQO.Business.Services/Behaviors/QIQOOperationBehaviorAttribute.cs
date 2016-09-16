using QIQO.Business.Contracts;
using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace QIQO.Business.Services.Behaviors
{
    [AttributeUsage(AttributeTargets.Method)]
    public class QIQOOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        public QIQOOperationBehaviorAttribute()
        {
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new QIQOInspector(dispatchOperation.Parent.Type.Name));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}
