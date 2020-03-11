using Repository.Interfaces;
using Service.Notifications;
using Service.Services;
using Service.Interfaces;
using Repository.Context;
using Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration
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
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IJobOfferService, JobOfferService>();


            return services;
        }
    }
}
