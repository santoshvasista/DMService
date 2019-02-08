using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static string DMConnectionString;
        public static void ShareServiceAndConfigurationInstance(this IServiceCollection services,
            IConfiguration configuration)
        {
            DMConnectionString = configuration.GetConnectionString("DMDatabase");
            //string assemblyNamespace = typeof(AppIdentityDbContext).Namespace;

            //var settingsSection = configuration.GetSection("AppIdentitySettings");
            //var settings = settingsSection.Get<AppIdentitySettings>();

            //// Inject AppIdentitySettings so that others can use too
            //services.Configure<AppIdentitySettings>(settingsSection);

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(connectionString, optionsBuilder =>
            //        optionsBuilder.MigrationsAssembly(assemblyNamespace)
            //    )
            //);

            //services.AddIdentity<AppUser, AppRole>(options =>
            //{
            //    // User settings
            //    options.User.RequireUniqueEmail = settings.User.RequireUniqueEmail;

            //    // Password settings
            //    options.Password.RequireDigit = settings.Password.RequireDigit;
            //    options.Password.RequiredLength = settings.Password.RequiredLength;
            //    options.Password.RequireLowercase = settings.Password.RequireLowercase;
            //    options.Password.RequireNonAlphanumeric = settings.Password.RequireNonAlphanumeric;
            //    options.Password.RequireUppercase = settings.Password.RequireUppercase;

            //    // Lockout settings
            //    options.Lockout.AllowedForNewUsers = settings.Lockout.AllowedForNewUsers;
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(settings.Lockout.DefaultLockoutTimeSpanInMins);
            //    options.Lockout.MaxFailedAccessAttempts = settings.Lockout.MaxFailedAccessAttempts;
            //})
            //.AddEntityFrameworkStores<AppIdentityDbContext>()
            //.AddDefaultTokenProviders();
        }
    }
}
