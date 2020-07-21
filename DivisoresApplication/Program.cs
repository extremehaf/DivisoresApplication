using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DivisoresApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            await ConfigureHostBuilder(hostBuilder)
                .Build()
                .RunAsync()
                .ConfigureAwait(false);
        }

        public static IHostBuilder ConfigureHostBuilder(IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json");
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
#if DEBUG
                logging.AddConsole();
#endif

            }).UseContentRoot(Directory.GetCurrentDirectory());
    }
}
