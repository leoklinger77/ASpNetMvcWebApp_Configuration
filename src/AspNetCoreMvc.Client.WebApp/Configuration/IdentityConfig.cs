using AspNetCoreMvc.Client.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMvc.Client.WebApp.Configuration
{
    public static class IdentityConfig
    {
        public static void IdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(option =>
                        option.UseSqlServer(configuration.GetConnectionString("connection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.AddRazorPages();
        }
    }
}
