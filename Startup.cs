using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tekus.Models;

namespace Tekus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("tekus"));

            services.AddDbContext<tekusContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Tekus"));
            });


            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext contex)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }



            app.UseCors(builder => {
                builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .DisallowCredentials();
                //.WithOrigins("http://localhost:4200");
            });


            app.UseHttpsRedirection();
            app.UseMvc();

            //if (!contex.Paises.Any())
            //{
            //    contex.Paises.AddRange(new List<Pais>
            //    {
            //        new Pais() {Nombre = "República Dominicana"},
            //        new Pais() {Nombre = "México"},
            //        new Pais() {Nombre = "Argentina"}
            //    });

            //    contex.SaveChanges();
            //}
        }
    }
}
