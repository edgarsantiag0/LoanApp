using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext repositoryContext)
        : base(repositoryContext)
        { }
    }
}
