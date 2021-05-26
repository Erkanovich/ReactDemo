using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class Installer
    {
        public static void SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurriculumVitaeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    ssoa => ssoa.MigrationsAssembly("Data"));
            });
        }
    }
}
