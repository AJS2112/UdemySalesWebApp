using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


using UdemySalesWebApp.DAL;
using Microsoft.AspNetCore.Http;
using Application.Services.Interfaces;
using Application.Services;
using UdemySalesWebApp.Domain.Interfaces;
using UdemySalesWebApp.Domain.Services;
using Domain.Repository;
using Repository.Entitites;

namespace UdemySalesWebApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("MyStock")));

            //services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();

            services.AddHttpContextAccessor();

            services.AddSession();

            //APP
            services.AddScoped<ICategoryServiceApp, CategoryServiceApp>();
            services.AddScoped<IClientServiceApp, ClientServiceApp>();
            services.AddScoped<IProductServiceApp, ProductServiceApp>();

            //DOMAIN
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IProductService, ProductService>();

            //REPOSITORY
            services.AddDbContext<Repository.Context.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyStock")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
