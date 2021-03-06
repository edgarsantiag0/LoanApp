using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int _maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
        public string Fields { get; set; }
        public string SearchTerm { get; set; }
    }
    public class CustomerLoanParameters : RequestParameters
    {

        public CustomerLoanParameters()
        {
            OrderBy = "Date";
        }

        public decimal? Amount { get; set; }

        public decimal MinAmount { get; set; } = 0;

        public decimal MaxAmount { get; set; } = 0;

        public int MinCustomerCreditRating { get; set; } = 0;

        public int MaxCustomerCreditRating { get; set; } = 0;



        public bool ValidAgeRange => MaxAmount > MinAmount;

        public string CustomerName { get; set; }

        public decimal? Balance { get; set; }

        public int? MonthsToPayback { get; set; }

        public string LoanPurpose { get; set; }

        public string LoanRepresentative { get; set; }

        public DateTime? Date { get; set; }

        public int? CustomerId { get; set; } = null;

        public int? LoanProductId { get; set; } = null;


        public string BusinessName { get; set; }


    }
}
