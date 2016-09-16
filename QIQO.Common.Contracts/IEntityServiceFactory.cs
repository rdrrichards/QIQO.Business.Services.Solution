namespace QIQO.Common.Contracts
{
    public interface IEntityServiceFactory
    {
        T GetEntityService<T>() where T : IEntityService;
    }
}
