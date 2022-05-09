using Business;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace LoanApp.Extensions
{
    public static class ServiceBusinessExtension
    {
        public static IServiceCollection AddAppBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICustomerLoanBusiness, CustomerLoanBusiness>();


            return services;

        }



    }
}
