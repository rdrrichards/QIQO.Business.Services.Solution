namespace QIQO.Common.Core.Caching
{ 
    public enum CacheType
    {
        Null = 0,
        Memory,
        NCacheExpress,
        AppFabric,
        Memcached,
        AzureTableStorage,
        Disk
    }
}
