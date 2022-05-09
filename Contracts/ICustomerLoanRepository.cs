using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerLoanRepository : IRepositoryBase<CustomerLoan>
    {
        Task<IEnumerable<CustomerLoan>> GetAllAsync(bool trackChanges);

        Task<PagedList<CustomerLoan>> GetAsync(CustomerLoanParameters parameters, bool trackChanges);

        Task<CustomerLoan> GetAsync(int id, bool trackChanges);

        IEnumerable<CustomerLoan> GetAll(bool trackChanges);

        CustomerLoan Get(int id, bool trackChanges);

        Task<IEnumerable<CustomerLoan>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);

        IEnumerable<CustomerLoan> GetByIds(IEnumerable<int> ids, bool trackChanges);

        bool ExistsLoanNumber(int id, string loanNumber);


    }
}
