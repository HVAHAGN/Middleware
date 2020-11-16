using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _03.MiddlewareLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // при каждом новом запросе переменная не будет переинициализирована
            // в контексте лямбда-выражения будет проведена операция инкримент по отношению к предыдущему результату вычесления
            // и полученный результат будет отправлен на сторону клиента
            int variable = 0;
            app.Run(async (context) =>
            {
                variable++;
                await context.Response.WriteAsync($"Result: {variable}");
            });
        }
    }
}
