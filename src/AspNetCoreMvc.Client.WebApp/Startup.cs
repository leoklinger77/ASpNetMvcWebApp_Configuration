using AspNetCoreMvc.Client.Domain.Interfaces.Repositorys;
using AspNetCoreMvc.Client.Domain.Interfaces.Services;
using AspNetCoreMvc.Client.Domain.Notifications;
using AspNetCoreMvc.Client.Domain.Services;
using AspNetCoreMvc.Client.Infrastructure.Data;
using AspNetCoreMvc.Client.Infrastructure.Repositorys;
using AspNetCoreMvc.Client.WebApp.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreMvc.Client.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<ClientContext>(option =>
                        option.UseSqlServer(Configuration.GetConnectionString("connection")));

            services.AddScoped<INotifierService, NotifierService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientContext>();            
            
            services.IdentityConfiguration(Configuration);                                   
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");                
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
