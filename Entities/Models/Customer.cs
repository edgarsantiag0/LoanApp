using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        public string Email { get; set; }

        public decimal MonthlyNetIncome { get; set; }

        public string SourceIncome { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        public int ZipCode { get; set; }

        public string Phone { get; set; }

        public string SSN { get; set; }

        public int CreditRating { get; set; }

        public int LateLoanPayments { get; set; }

        public decimal TotalDebt { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public int DemographicModelId { get; set; }

        public int RiskRating { get; set; }

        public DemographicModel DemographicModel { get; set; }

        public ICollection<CustomerLoan> CustomerLoans { get; set; }


        //public int RiskRating
        //{
        //    get { return (int)((LateLoanPayments + TotalDebt) / CreditRating); }

        //    set
        //    {
        //        RiskRating = (int)((LateLoanPayments + TotalDebt) / CreditRating);
        //    }
        //}


    }
}
