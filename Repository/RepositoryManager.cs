using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _repositoryContext;

        private ICountryRepository _countryRepository;
        //private IEmployeeRepository _employeeRepository;

        public RepositoryManager(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICountryRepository Country
        {
            get
            {
                if (_countryRepository == null)
                    _countryRepository = new CountryRepository(_repositoryContext);
                return _countryRepository;
            }
        }

        //public IEmployeeRepository Employee
        //{
        //    get
        //    {
        //        if (_employeeRepository == null)
        //            _employeeRepository = new EmployeeRepository(_repositoryContext);
        //        return _employeeRepository;
        //    }
        //}

        public void Save() => _repositoryContext.SaveChanges();

    }
}
