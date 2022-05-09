using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerLoanRepository : RepositoryBase<CustomerLoan>, ICustomerLoanRepository
    {
        public CustomerLoanRepository(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }


        public IEnumerable<CustomerLoan> GetAll(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.LoanNumber)
            .ToList();

        public IEnumerable<CustomerLoan> GetByIds(IEnumerable<int> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToList();

        public CustomerLoan Get(int id, bool trackChanges)
        {
            var obj = FindByCondition(c => c.Id.Equals(id), trackChanges)
                .SingleOrDefault();

            return obj;
        }


        public async Task<IEnumerable<CustomerLoan>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.LoanNumber)
            .ToListAsync();

        public async Task<CustomerLoan> GetAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(o => o.Customer)
            .Include(o => o.LoanProduct)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<CustomerLoan>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();

        public async Task<PagedList<CustomerLoan>> GetAsync(CustomerLoanParameters modelParameters, bool trackChanges)
        {
            return await FindAll(trackChanges)
                    .Include(o => o.Customer)
                    .Include(o => o.LoanProduct)
                    .Filter(modelParameters, Filter)
                    .Search(modelParameters, Search)
                    .Sort(modelParameters, Sort)
                    .ToPagedList(modelParameters);
        }

        public bool ExistsLoanNumber(int id, string loanNumber)
        {
            return _entities?.Any(o => o.Id != id && o.LoanNumber == loanNumber && o.IsDeleted == false) ?? false;
        }

        private IQueryable<CustomerLoan> Filter(IQueryable<CustomerLoan> entities, CustomerLoanParameters modelParameters)
        {

            if (modelParameters.Amount != null)
            {
                entities = entities.Where(e => e.Amount == modelParameters.Amount);
            }

            if (modelParameters.Balance != null)
            {
                entities = entities.Where(e => e.Balance == modelParameters.Balance);
            }

            if (string.IsNullOrWhiteSpace(modelParameters.LoanPurpose) == false)
            {
                entities = entities.Where(e => e.LoanPurpose == modelParameters.LoanPurpose);
            }

            if (modelParameters.MonthsToPayback != null)
            {
                entities = entities.Where(e => e.MonthsToPayback == modelParameters.MonthsToPayback);
            }

            if (modelParameters.CustomerId != null)
            {
                entities = entities.Where(e => e.Customer.Id == modelParameters.CustomerId);
            }

            if (modelParameters.LoanProductId != null)
            {
                entities = entities.Where(e => e.LoanProduct.Id == modelParameters.LoanProductId);
            }

            if (modelParameters.Date != null)
            {
                entities = entities.Where(e => e.Date >= modelParameters.Date);
            }

            return entities;
        }

        private IQueryable<CustomerLoan> Search(IQueryable<CustomerLoan> entities, CustomerLoanParameters modelParameters)
        {
            if (string.IsNullOrWhiteSpace(modelParameters.SearchTerm))
            {
                return entities;
            }

            var lowerCaseTerm = modelParameters.SearchTerm.Trim().ToLower();

            return entities.Where(e => e.LoanNumber.ToLower().Contains(lowerCaseTerm));
        }

        private IQueryable<CustomerLoan> Sort(IQueryable<CustomerLoan> entities, CustomerLoanParameters modelParameters)
        {
            if (string.IsNullOrWhiteSpace(modelParameters.OrderBy))
            {
                return entities.OrderBy(e => e.Created);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<CustomerLoan>(modelParameters.OrderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return entities.OrderBy(e => e.Created);
            }

            return entities.OrderBy(e => e.Created);


          //  return entities.OrderBy(orderQuery);
        }
    }


}
