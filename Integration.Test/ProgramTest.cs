
using DivisoresApplication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Test
{
    public class ProgramTest
    {
        public IHost Host { get; }

        public ProgramTest()
        {
            var hostBuilder = new HostBuilder()
                    .ConfigureWebHost(webHost =>
                    {
                        webHost.UseTestServer();
                        webHost.UseEnvironment("Development");
                        webHost.UseStartup<Startup>();
                    });

            Host = Program.ConfigureHostBuilder(hostBuilder)
                .Start();
        }
    }
}
