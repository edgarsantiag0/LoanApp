using Entities.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LoanApp.ViewModels
{
    public class CustomerLoanAddUpdateViewModel
    {
        public CustomerAddUpdateDto Customer { get; set; }

        public Entities.Models.Business Business { get; set; }

        // Business selected

        [Required]
        public int BusinessId { get; set; }

        // Loan application

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int MonthsToPayback { get; set; }

        [Required]
        public string LoanPurpose { get; set; }

        [Required]
        public int LoanProductId { get; set; }
    }
}
