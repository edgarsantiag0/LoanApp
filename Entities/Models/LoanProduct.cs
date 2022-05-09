using System.Collections.Generic;

namespace Entities.Models
{
    public class LoanProduct : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public float APR { get; set; }

        public decimal MinAmount { get; set; }

        public decimal MaxAmount { get; set; }

        public decimal MonthlyPayment { get; set; }

        public int Length { get; set; }

        public int BusinessId { get; set; }

        public Business Business { get; set; }

        public ICollection<CustomerLoan> CustomerLoans { get; set; }

    }
}
