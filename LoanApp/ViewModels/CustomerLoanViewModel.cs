using Entities.DTOs;
using Entities.RequestFeatures;

namespace LoanApp.ViewModels
{
    public class CustomerLoanViewModel
    {
        public PagedList<CustomerLoanDto> data { get; set; }

        public CustomerLoanParameters parameters { get; set; }

        public string searchTerm { get; set; }

        public decimal minAmount { get; set; }

        public decimal maxAmount { get; set; }
    }
}
