using AutoMapper;
using Entities.Mappers;

namespace LoanApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.AddCustomerLoan();
        }
    }
}
