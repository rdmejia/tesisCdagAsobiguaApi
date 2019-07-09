using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Persistence.Contexts;
using tesisCdagAsobiguaApi.Persistence.Repositories;
using tesisCdagAsobiguaApi.Services;

namespace tesisCdagAsobiguaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string _allowAnyOrigin = "AllowAnyOrigin";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options =>
            {
                options.AddPolicy(_allowAnyOrigin,
                    builder => builder.AllowAnyOrigin());
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("tesis-cdag-asobigua-database");
            });

            // First add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShotRepository, ShotRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Then add services
            services.AddScoped<IUserService, UserServices>();
            services.AddScoped<IShotService, ShotService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(_allowAnyOrigin);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
