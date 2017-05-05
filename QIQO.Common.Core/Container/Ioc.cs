using SimpleInjector;

namespace QIQO.Common.Core
{
    //public static class Unity
    //{
    //    public static IUnityContainer Container { get; set; }
    //}
    public static class IocContainer
    {
        public static Container Container { get; set; } = new Container();
    }
}
