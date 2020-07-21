using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.BLLs;
using Application.BLLs;

namespace DivisoresApplication.Config
{
    public static class DependencyInjectionExtencion
    {
        public static void ConfigureBlls(this IServiceCollection services)
        {
            services.AddScoped<IDivisorBll, DivisorBll>();
        }

    }
}
