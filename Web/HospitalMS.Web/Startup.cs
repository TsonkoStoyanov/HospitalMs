namespace HospitalMS.Web
{
    using HospitalMS.Data;
    using HospitalMS.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using HospitalMS.Services.Messaging.SendGrid;
    using HospitalMS.Data.Seeding;
    using HospitalMS.Services.Mapping;
    using HospitalMS.Web.ViewModels.Hospital;
    using HospitalMS.Services.Models;
    using System.Reflection;
    using HospitalMS.Services;
    using HospitalMS.Web.InputModels.Hospital;
    using System.Globalization;

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


            services.AddDbContext<HospitalMSDbContext>(
              options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services
                .AddIdentity<HospitalMSUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 3;

                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<HospitalMSDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            //DependancyContainer
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IRoomTypeService, RoomTypeService>();
            services.AddTransient<IBedService, BedService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IReceptionistService, ReceptionistService>();

            //SendGirdConfiguration
            services.Configure<SendGridOptions>(this.Configuration.GetSection("SendGridApiKey"));
            services.AddTransient<IEmailSender, EmailSender>();


            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
              typeof(HospitalDetailsViewModel).GetTypeInfo().Assembly,
              typeof(HospitalEditInputModel).GetTypeInfo().Assembly,
              typeof(HospitalServiceModel).GetTypeInfo().Assembly);

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<HospitalMSDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new HospitalMSDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
