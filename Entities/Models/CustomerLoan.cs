using System;

namespace Entities.Models
{
    public class CustomerLoan
    {

        public decimal Amount { get; set; }

        public int MonthsToPayback { get; set; }

        public float APR { get; set; }

        public string LoanPurpose { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
    }
}
