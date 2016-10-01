using System.ServiceProcess;

namespace QIQO.WindowsServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WindowsServiceHost()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
