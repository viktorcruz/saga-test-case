using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saga.TestCase.Application.Clientes.Queries.QueryHandler;
using Saga.TestCase.Application.IoC;
using Saga.TestCase.Infrastructure.Interfaces;
using Saga.TestCase.Infrastructure.IoC;
using Saga.TestCase.Presentation.Mdi;
using Saga.TestCase.Transversal.IoC;
using System.Reflection;

namespace Saga.TestCase.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddCustomApplicationIoC()
                .AddCustomInfrastructureIoC(configuration)
                .AddCustomTransversalIoC()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllClientesQueryHandler).Assembly))
                .AddTransient<MDIStartup>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .BuildServiceProvider();

            NLog.GlobalDiagnosticsContext.Set("Environment", "Development");
            NLog.GlobalDiagnosticsContext.Set("ServerName", Environment.MachineName);
            NLog.GlobalDiagnosticsContext.Set("IdCorrelation", Guid.NewGuid().ToString());
            //NLog.GlobalDiagnosticsContext.Set("MonoliticName", System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name);
            
            // inferencia para mediar entre objetos
            var mediator = serviceProvider.GetRequiredService<IMediator>();
            // inferencia para las excepciones globales
            var globalExceptions = serviceProvider.GetRequiredService<IGlobalExceptionHandler>();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            System.Windows.Forms.Application.Run(new MDIStartup(mediator, globalExceptions));
        }
    }
}