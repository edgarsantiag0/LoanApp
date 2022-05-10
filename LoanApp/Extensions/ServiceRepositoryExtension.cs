using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace LoanApp.Extensions
{
    public static class ServiceRepositoryExtension
    {

        public static IServiceCollection AddAppRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();


            services.AddScoped<ICustomerLoanRepository, CustomerLoanRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }


        }
}
