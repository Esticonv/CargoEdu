using System.Reflection;

namespace OrderManager
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(builder =>
                {
                    builder.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location))
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile("secrets/appsettings.secrets.json", optional: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<Worker>()
                        .AddServices(hostContext.Configuration);

                })
                .Build();
            await host.StartAsync();
            await host.WaitForShutdownAsync();
        }
    }
}