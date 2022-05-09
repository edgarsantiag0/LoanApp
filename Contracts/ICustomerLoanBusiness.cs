using Entities.DTOs;
using Entities.Helpers;
using Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerLoanBusiness
    {
        Task<CustomerLoanAddUpdateDto> GetAsync(int id, bool trackChanges);

        Task<IEnumerable<CustomerLoanDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);

        Task<PagedList<CustomerLoanDto>> GetPagedListDto(CustomerLoanParameters parameters, bool trackChanges);

        Task<AddUpdateResult<CustomerLoanDto>> AddAsync(CustomerLoanAddUpdateDto dto);

        Task<AddUpdateResult<CustomerLoanDto>> UpdateAsync(int id, CustomerLoanAddUpdateDto dto, bool trackChanges);

        Task<DeleteResult> DeleteAsync(int id);
    }
}
