using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;

namespace Viewtance.Teaching.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AbpCommonDbProperties.DbTablePrefix = "Teaching";
            TextTemplateManagementDbProperties.DbTablePrefix = "Teaching";

            AbpIdentityDbProperties.DbTablePrefix = "Teaching";
            AbpPermissionManagementDbProperties.DbTablePrefix = "Teaching";


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
#if DEBUG
                .MinimumLevel.Override("Viewtance.Teaching", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("Viewtance.Teaching", LogEventLevel.Information)
#endif
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt", rollingInterval: RollingInterval.Day))
                .WriteTo.Async(c => c.Console())
                .CreateLogger();

            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddAppSettingsSecretsJson()
                .ConfigureLogging((context, logging) => logging.ClearProviders())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });
    }
}
