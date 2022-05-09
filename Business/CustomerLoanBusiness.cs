using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Helpers;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerLoanBusiness : ICustomerLoanBusiness
    {
        private readonly ICustomerLoanRepository _repository;
        private readonly IMapper _mapper;

        public CustomerLoanBusiness(ICustomerLoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task<AddUpdateResult<CustomerLoanDto>> AddAsync(CustomerLoanAddUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AddUpdateResult<CustomerLoanDto>> UpdateAsync(int id, CustomerLoanAddUpdateDto dto, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteResult> DeleteAsync(int id)
        {
            var entity = await _repository.GetAsync(id, trackChanges: true);
            
            if (entity == null) { return DeleteResult.NotFound(); }

            entity.IsDeleted = true;

            _repository.Update(entity);

            await _repository.SaveAsync();

            return DeleteResult.Success();
        }

        public async Task<CustomerLoanAddUpdateDto> GetAsync(int id, bool trackChanges)
        {
            var entity = await _repository.GetAsync(id, trackChanges);

            return _mapper.Map<CustomerLoanAddUpdateDto>(entity);
        }

        public async Task<IEnumerable<CustomerLoanDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            var entities = await _repository.GetByIdsAsync(ids, trackChanges);

            return _mapper.Map<IEnumerable<CustomerLoanDto>>(entities);
        }

        public async Task<PagedList<CustomerLoanDto>> GetPagedListDto(CustomerLoanParameters parameters, bool trackChanges)
        {
            var data = await _repository.GetAsync(parameters, trackChanges);

            var dtos = _mapper.Map<List<CustomerLoanDto>>(data);

            return new PagedList<CustomerLoanDto>(dtos, data.MetaData);
        }


    }
}
