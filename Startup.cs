// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Xyz">
//  copyright 
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ContactInfoWeb
{
    using AutoMapper;

    using ContactInfo.Application.Interfaces;
    using ContactInfo.Application.Services;
    using ContactInfo.Core.Configuration;
    using ContactInfo.Core.Interfaces;
    using ContactInfo.Core.Repositories;
    using ContactInfo.Core.Repositories.Base;
    using ContactInfo.Infrastructure.Data;
    using ContactInfo.Infrastructure.Logging;
    using ContactInfo.Infrastructure.Repository;
    using ContactInfo.Infrastructure.Repository.Base;
    using ContactInfo.Services;

    using ContactInfoWeb.HealthChecks;
    using ContactInfoWeb.Interfaces;
    using ContactInfoWeb.Services;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  // This method gets called by the runtime. Use this method to add services to the container.
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {            
            // aspnetrun dependencies
            ConfigureAspnetRunServices(services);            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages();
        }

        /// <summary>
        ///  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {   
                endpoints.MapRazorPages();
            });
        }

        /// <summary>
        /// The configure aspnet run services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ContactInfoWebSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
           
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Add Application Layer
            services.AddScoped<IContactInfoService, ContactInfoService>();
         

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IContactInfoPageService, ContactInfoPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddCheck<IndexPageHealthCheck>("home_page_health_check");
        }

        /// <summary>
        /// The configure databases.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ContactInfoContext>(c =>
                c.UseInMemoryDatabase("ContactInfoConnection"));

            //// use real database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection")));
        }
    }
}
