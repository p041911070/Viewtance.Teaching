using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;

namespace Viewtance.Teaching
{
    public class Program
    {
        public static int Main(string[] args)
        {
            AbpCommonDbProperties.DbTablePrefix = "Teaching";
            TextTemplateManagementDbProperties.DbTablePrefix = "Teaching";
#if DEBUG
            AbpIdentityDbProperties.DbTablePrefix = "Teaching";
            AbpPermissionManagementDbProperties.DbTablePrefix = "Teaching";
#else
            AbpIdentityDbProperties.DbTablePrefix = "SRP";
            AbpPermissionManagementDbProperties.DbTablePrefix = "SRP";
#endif

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt", rollingInterval: RollingInterval.Day))
#if DEBUG
                .WriteTo.Async(c => c.Console())
#endif
                .CreateLogger();

            try
            {
                Log.Information("Starting Viewtance.Teaching.HttpApi.Host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddAppSettingsSecretsJson()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();
    }
}
