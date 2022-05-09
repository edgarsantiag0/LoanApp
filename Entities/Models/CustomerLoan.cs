using System;

namespace Entities.Models
{
    public class CustomerLoan : Entity
    {
        public int Id { get; set; }

        public string LoanNumber { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public int MonthsToPayback { get; set; }

        public string LoanPurpose { get; set; }

        public string LoanRepresentative { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int LoanProductId { get; set; }

        public LoanProduct LoanProduct { get; set; }
    }
}
