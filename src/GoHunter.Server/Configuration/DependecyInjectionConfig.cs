using GoHunter.Business.Interfaces;
using GoHunter.Business.Notifications;
using GoHunter.Business.Services;
using GoHunter.Data.Context;
using GoHunter.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GoHunter.Server.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<GoHunterDbContext>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IJobOfferRepository, JobOfferRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ITechRepository, TechRepository>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICompanyService, CompanyrService>();
            services.AddScoped<IEmployeeService, EmployeeService>();


            return services;
        }
    }
}
