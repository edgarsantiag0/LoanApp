using Contracts;
using Entities.Models;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }




    }
}
