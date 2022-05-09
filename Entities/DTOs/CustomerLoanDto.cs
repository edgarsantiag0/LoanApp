using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerLoanDto
    {

        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public int MonthsToPayback { get; set; }

        public string LoanPurpose { get; set; }

        public string LoanRepresentative { get; set; }

        public DateTime Date { get; set; }



        public int CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public string LoanNumber { get; set; }





        public int LoanProductId { get; set; }

        public string LoanProductDescription { get; set; }



    }
}
