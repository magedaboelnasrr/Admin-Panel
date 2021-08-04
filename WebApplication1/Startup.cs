using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.BL.Interface;
using WebApplication1.BL.Mapper;
using WebApplication1.BL.Repository;
using WebApplication1.DAL.Database;


namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


            services.AddDbContextPool<Dbcontainer>(opts => opts.UseSqlServer(Configuration.GetConnectionString("SharpDbConnection")));

            //--------- Auto Mapper-------------//
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            //services.AddTransient<DepartmentRep>();                     // one instance to one operation by default
            services.AddScoped<IDepartmentRep, DepartmentRep>();          // one instance to on user (Crud operations)
            services.AddScoped<IEmployeeRep, EmployeeRep>();             //services.AddSingleton<DepartmentRep>();  // one instance shared to users


            //------------------- IDENTITY------------------

            services.AddIdentity<IdentityUser, IdentityRole>(options =>

            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<Dbcontainer>().AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);



            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();

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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
