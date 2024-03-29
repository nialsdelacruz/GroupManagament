﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayBall.GroupManagement.Web.Demo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PlayBall.GroupManagement.Business.Services;
using PlayBall.GroupMangament.Business.Imp.Services;

namespace Coding.PlayBall.GroupManagement.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IGroupsService, InMemoryGroupsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Powered-By", "Nials De La Cruz");
                    return Task.CompletedTask;
                });

                //if (!context.Request.Path.Value.EndsWith("1"))
                //{
                //    await next.Invoke();
                //}

                await next.Invoke();
            });



            app.UseMvc();
        }
    }
}
