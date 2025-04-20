using System.Reflection;
using dotnet.AppContext;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (builder.Configuration == null) throw new ArgumentNullException(nameof(builder.Configuration));

            // Adding the database context
            builder.Services.AddDbContext<ApplicationContext>(configure =>
            {
                configure.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
            });

        }
    }
}