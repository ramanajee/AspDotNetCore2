using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCore2.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspDotNetCore2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConferenceService, ConferenceService>();
            services.AddSingleton<IProposalService, ProposalService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,next) =>
            {
                logger.LogInformation("Before Second");
                //await context.Response.WriteAsync("Hello World!\n");
                await next();
                logger.LogInformation("After Second");
            });

            app.Use(async (context,next) =>
            {
                logger.LogInformation("Second");
                await context.Response.WriteAsync("Hello Ramanajee!\n");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello RJ!\n");
            });
        }
    }
}
