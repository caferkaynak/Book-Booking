using bookbooking.Data;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using bookbooking.Web.Areas.Administration.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bookbooking
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IUserService,UserService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<ICardService, CardService>();
            // services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddMvc();
            //services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddAuthentication();
            services.AddIdentity<User, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            services.AddEntityFrameworkSqlServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                         name: "MyArea",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
            SeedData.Seed(app);
            BaseController baseController = new BaseController();
        }
    }
}
