using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using OdataSample.App.Models;
using OdataSample.App.Services;

namespace OdataSample.App
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var connectionString = Configuration.GetConnectionString("MondialDbContext");

            services.AddDbContext<MondialDbContext>(builder => builder.UseSqlServer(connectionString));
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(builder =>
            {
                builder.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                builder.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
                builder.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel(app));
                builder.EnableDependencyInjection();
            });
        }

        private static IEdmModel GetEdmModel(IApplicationBuilder app)
        {
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EntitySet<Group>("Groups").EntityType.HasKey(g => g.Id);
            builder.EntitySet<Team>("Teams").EntityType.HasKey(t => t.Id);
            builder.EntitySet<Player>("Players").EntityType.HasKey(p => p.Id);

            return builder.GetEdmModel();
        }
    }
}
