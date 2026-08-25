using ERPSystem.Application.Interfaces;
using ERPSystem.Infrastructure.Data;
using ERPSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ERPSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var connectionStringName = environment.IsProduction() ? "AzureSQLConnection" : "DefaultConnection";
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(connectionStringName)));

            services.AddScoped<IStateCascadeService, StateCascadeService>();
            services.AddScoped<IEntityStateLookupService, EntityStateLookupService>();
            services.AddScoped<IReportCalculationService, ReportCalculationService>();
            services.AddScoped<IMentorLookupService, MentorLookupService>();
            services.AddScoped<IPhotoUploadService, PhotoUploadService>();

            return services;
        }
    }
}
