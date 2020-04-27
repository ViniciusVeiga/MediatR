using System;
using System.Reflection;
using DBContext.Repository;
using Domain.Provider;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mediator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddDbContext<InfraContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-H0F1K97;Database=examples;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddTransient(serviceProvider =>
            {
                var contextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                if (contextAccessor != null)
                    if (contextAccessor.HttpContext.Request.Headers.TryGetValue("x-tenant-id", out var tenantHeaderValue) && Guid.TryParse(tenantHeaderValue, out var tenantId))
                        return new TenantProvider(tenantId);

                throw new ArgumentNullException("x-tenant-id", "Empresa não informada");
            });

            services.AddTransient<TenantRepository, TenantRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddMediatR(Assembly.Load("Domain"));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
