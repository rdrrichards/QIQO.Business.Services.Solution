namespace QIQO.Common.Contracts
{
    public interface IBusinessEngineFactory
    {
        T GetBusinessEngine<T>() where T : IBusinessEngine;
    }
}
