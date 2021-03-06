using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace Entities.Mappers
{
    public static class LoanAppMapper
    {

        public static Profile AddCustomerLoan(this Profile map)
        {
            map.CreateMap<CustomerLoan, CustomerLoanDto>()
               .ForMember(v => v.CustomerFullName,
                   opt => opt.MapFrom(x => x.Customer == null ? "" : x.Customer.FirstName + " " + x.Customer.LastName))
               .ForMember(v => v.LoanProductDescription,
                   opt => opt.MapFrom(x => x.LoanProduct == null ? "" : x.LoanProduct.Description))
               
               ;

            map.CreateMap<CustomerLoan, CustomerLoanAddUpdateDto>();

            map.CreateMap<Customer, CustomerAddUpdateDto>();

            map.CreateMap<CustomerLoanAddUpdateDto, CustomerLoan>();              


            return map;
        }



    }
}
