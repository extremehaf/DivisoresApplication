using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.BLLs;
using Application.BLLs;
using Microsoft.OpenApi.Models;

namespace DivisoresApplication.Config
{
    public static class DependencyInjectionExtencion
    {
        public static void ConfigureBlls(this IServiceCollection services)
        {
            services.AddScoped<IDivisorBll, DivisorBll>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Divisores",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1",
                        Contact = new OpenApiContact
                        {
                            Name = "Lucas de Melo",
                            Url = new Uri("https://github.com/extremehaf")
                        }
                    });
            });
        }
    }
}
