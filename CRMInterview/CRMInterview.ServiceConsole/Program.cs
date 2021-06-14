using CRMInterview.BL;
using CRMInterview.DI;
using CRMInterview.ServiceConsole.ServiceSetup;
using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Topshelf;

namespace CRMInterview.ServiceConsole
{
    class Program
    {
        /// <summary>
        /// The class represents CRM mail service logic
        /// For more reliability and scalibility i using here Topshelf framework,
        /// as one of the options with small changes we run service per CrmEvent
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            // Configure IoCC container
            new IoCImpl().Configure();
            var service = IoCC.Instance.Resolve<IMailerService>();

            HostFactory.Run(hostConfig =>
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

                hostConfig.UseLog4Net();

                hostConfig.EnableServiceRecovery(serviceRecovery =>
                {
                    // first failure, 5 minute delay
                    serviceRecovery.RestartService(5);

                });

                hostConfig.RunAsLocalSystem(); ;

                hostConfig.Service<IMailerService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => service);
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());

                    serviceConfig.WhenPaused(s => s.Pause());
                    serviceConfig.WhenContinued(s => s.Resume());
                    serviceConfig.WhenShutdown(s => s.Shutdown());
                });
            });


            //await service.Run();
            Console.WriteLine("Hello World!");
        }
    }
}
