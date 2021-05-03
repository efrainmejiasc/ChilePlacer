using ChilePlacer.Application;
using ChilePlacer.Application.Interfaces;
using ChilePlacer.DataModels;
using ChilePlacer.Repositories;
using ChilePlacer.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChilePlacer
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
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
#if DEBUG
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal")));
#else
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
#endif

            services.AddControllersWithViews();

            //**************************************************************************
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            //*****************************************************************************

            services.AddTransient<MyAppContext, MyAppContext>();
            services.AddTransient<IUtilidad, Utilidad>();
            services.AddTransient<ISendMail, SendMail>();
            services.AddTransient<IImageTool, ImageTool>();
            services.AddTransient<IGirlsRepository, GirlsRepository>();
            services.AddTransient<IAppLogRepository, AppLogRepository>();
            services.AddTransient<ITypesRepository, TypesRepository>();
            services.AddTransient<IGaleriaGirlsRepository, GaleriaGirlsRepository>();
            services.AddTransient<IPortadaGirlsRepository, PortadaGirlsRepository>();
            services.AddTransient<IProfileGirlsRepository, ProfileGirlsRepository>();
            services.AddTransient<IChangePasswordRepository, ChangePasswordRepository>();

#if DEBUG
            EngineData.UrlServerHost = Configuration.GetValue<string>("HostSettings:UrlServerHostLocal");
            EngineData.UrlServerActivacion = Configuration.GetValue<string>("HostSettings:UrlServerActivacionLocal");
            EngineData.ConnectionDb = Configuration.GetValue<string>("ConnectionStrings:DefaultConnectionLocal");

#else

           EngineData.UrlServerHost = Configuration.GetValue<string>("HostSettings:UrlServerHost");
           EngineData.UrlServerActivacion = Configuration.GetValue<string>("HostSettings:UrlServerActivacion");
           EngineData.ConnectionDb = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
#endif




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
            }

            app.UseStaticFiles();
            app.UseSession();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
