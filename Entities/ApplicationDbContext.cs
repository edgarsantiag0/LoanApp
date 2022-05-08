using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<DemographicModel> DemographicModels { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<LoanProduct> LoanProducts { get; set; }

        public DbSet<CustomerLoan> CustomerLoans { get; set; }

    }
}
