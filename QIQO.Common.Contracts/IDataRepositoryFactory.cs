namespace QIQO.Common.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : class, IRepository;
        T GetIdentityDataRepository<T>() where T : class, IIdentityRepository;
    }
}
