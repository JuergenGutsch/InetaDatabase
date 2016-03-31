using System.Collections.Generic;
using System.IO;
using Gos.Tools.Azure;
using Gos.Tools.Cqs;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure;
using InetaAdmin.Infrastructure.Read;
using InetaAdmin.Infrastructure.Read.Queries;
using InetaAdmin.Infrastructure.Read.QueryHandler;
using InetaAdmin.Infrastructure.Write;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace InetaAdmin
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCqsEngine(s =>
            {
                s.AddQueryHandlers();
                s.AddCommandHandlers();
            });


            //services.AddStorageClient(
            //    new StorageAccountCredentials
            //    {
            //        AccountName = "InetaDatabaseStorage",
            //        KeyValue = "topsecret",
            //        StorageUri = new Uri("https://azure.com/")
            //    });
            services.AddSingleton<ITableClient, MockTableClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();

            app.Use(async (context, next) =>
            {
                await next();

                // If there's no available file and the request doesn't contain an extension, we're probably trying to access a page.
                // Rewrite request to use app root
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html"; // Put your Angular root page here 
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
