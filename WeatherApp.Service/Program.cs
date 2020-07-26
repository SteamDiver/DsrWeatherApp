using System.ServiceProcess;

namespace WeatherApp.Service
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        private static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WeatherApiService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}