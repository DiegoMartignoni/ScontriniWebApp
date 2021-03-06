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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ScontriniWebApp.Models.Options;
using ScontriniWebApp.Models.Services.Application;
using ScontriniWebApp.Models.Services.Infrastructure;

namespace ScontriniWebApp
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
            services.AddResponseCaching();
            services.AddMvc(options =>
            {
                CacheProfile homeProfile = new CacheProfile();
                Configuration.Bind("ResponseCache:Home", homeProfile);
                options.CacheProfiles.Add("Home", homeProfile);
            });
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            //services.AddTransient<IReceiptService, AdoNetReceiptService>();
            services.AddTransient<IReceiptService, EfCoreReceiptService>();
            services.AddTransient<IErrorService, SwitcherErrorService>();
            services.AddTransient<IDatabaseManager, SqliteDatabaseManager>();
            services.AddTransient<IChachedReceiptService, MemoryCachedReceiptService>();

            //services.AddScoped<ScontriniWebAppDbContext>();
            services.AddDbContextPool<ScontriniWebAppDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlite(Configuration.GetConnectionString("Default"));
            });

            //----------- Options
            services.Configure<ReceiptsOptions>(Configuration.GetSection("Receipts"));
            services.Configure<CacheOptions>(Configuration.GetSection("Cache"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseCaching();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
