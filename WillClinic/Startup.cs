using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;
using WillClinic.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WillClinic
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
            // ApplicationDbConnection corresponds to the SQL connection string to the
            // production database via Azure Key Vault. Change which AddDbContext call is
            // commented to switch between production and the local development database.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["ProductionConnection"]));

            //Connection string for localDb also stored within Azure KeyVaults and
            //ensures that everyoe has the same setup
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer($"Server=(localdb)\\{Configuration["DefaultConnection"]}"));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Email sending service to send account verifications, matching notifications,
            // and administrative communications to users.
            services.AddTransient<IEmailSender, EmailSender>();
            // TODO(taylorjoshuaw): This is no longer being used for matching. This could be
            //                      removed after performing some integration tests with the service removed.
            services.AddTransient<IMatchService, MatchService>();
            // Used by the ConditionalClassHelper tag helper
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Used for lawyer bar status verification with the WSBA at login, annually, and when making matches
            services.AddTransient<ILawyerVerificationService, LawyerVerificationService>();

            // The following three services are used by Razor Pages as an abstraction to performing queries and
            // CRUD on their respective entity types, as well as abstracting away many-to-many relationships
            // between tables.
            services.AddScoped<ILawyerService, LawyerService>();
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddScoped<IVeteranService, VeteranService>();

            // Enforce HTTPS across the site (do not allow unencrypted connections)
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            // Add in the MVC framework
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            // Set up debugging and error handling based on the environment that the host is running under
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            // Allow for static files under wwwroot/
            app.UseStaticFiles();

            // Establish default routing for MVC and enable support for Razor Pages
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}