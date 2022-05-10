using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Helpers;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerLoanBusiness : ICustomerLoanBusiness
    {
        private readonly ICustomerLoanRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerLoanBusiness(ICustomerLoanRepository repository, 
            IMapper mapper,
            ICustomerRepository customerRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _customerRepository = customerRepository;

        }


        public async Task<AddUpdateResult<CustomerLoanDto>> AddAsync(CustomerLoanAddUpdateDto dto)
        {
            var data = Validate(0, dto);

            if (!data.IsValid) { return data; }

            var customer = new Customer
            {
                CityId = dto.Customer.CityId,
                CreditRating = 0,
                DateOfBirth = dto.Customer.DateOfBirth,
                Email = dto.Customer.Email,
                FirstName = dto.Customer.FirstName,
                LastName = dto.Customer.LastName,
                Gender = dto.Customer.Gender,
                IsDeleted = false,
                LateLoanPayments = 0,
                MonthlyNetIncome = dto.Customer.MonthlyNetIncome,
                Phone = dto.Customer.Phone,
                RiskRating = CalculateRiskRating(),
                SourceIncome = dto.Customer.SourceIncome,
                SSN = dto.Customer.SSN,
                StreetAddress1 = dto.Customer.StreetAddress1,
                StreetAddress2 = dto.Customer.StreetAddress2,
                TotalDebt = 0,
                ZipCode = dto.Customer.ZipCode

            };

            _customerRepository.Create(customer);

            var customerLoan = new CustomerLoan
            {
                Amount = dto.Amount,
                Balance = dto.Amount,
                Customer = customer,
                Date = DateTime.Now,
                LoanNumber = "00000x", // generate sequence
                LoanProductId = dto.LoanProductId,
                LoanPurpose = dto.LoanPurpose,
                LoanRepresentative = "Representative x", // assing one
                MonthsToPayback = 20

            };

            _repository.Create(customerLoan);

            // SAVE ALL 
            await _customerRepository.SaveAsync();

            var resultDto = _mapper.Map<CustomerLoanDto>(customerLoan);



            return AddUpdateResult<CustomerLoanDto>.Ok(resultDto);


        }


        private int CalculateRiskRating()
        {
            var ratingNumber = 680;
            var lateLoanPayments = 20;
            var totalDebt = 20000;

            var riskRating = (lateLoanPayments + totalDebt) / ratingNumber;

            return riskRating;
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

        private AddUpdateResult<CustomerLoanDto> Validate(int id, CustomerLoanAddUpdateDto dto)
        {

            if (dto.BusinessId <= 0)
            {
                return AddUpdateResult<CustomerLoanDto>.Error($"The Business info is required.");
            }

            if (dto.LoanProductId <= 0)
            {
                return AddUpdateResult<CustomerLoanDto>.Error($"The Business info is required.");
            }

            if (dto.Amount <= 0)
            {
                return AddUpdateResult<CustomerLoanDto>.Error($"The Amount must be greater than zero.");
            }

            if (dto.MonthsToPayback <= 0)
            {
                return AddUpdateResult<CustomerLoanDto>.Error($"Months to pay back must be greater than zero.");
            }

            if (string.IsNullOrEmpty(dto.LoanPurpose))
            {
                return AddUpdateResult<CustomerLoanDto>.Error($"The Loan Purpose is required.");
            }

            return AddUpdateResult<CustomerLoanDto>.Ok();
        }


    }
}
