namespace QIQO.Common.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IRepository;
        T GetIdentityDataRepository<T>() where T : IIdentityRepository;
    }
}
