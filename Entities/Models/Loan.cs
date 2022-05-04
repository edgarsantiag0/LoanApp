using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    internal class Loan
    {

        public decimal Amount { get; set; }

        public int MonthsToPayback { get; set; }

        public float APR { get; set; }

        public string LoanPurpose { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
    }
}
