using Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public class CustomerAddUpdateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Gender Gender { get; set; } = Gender.Male;

        [Required]
        public string Email { get; set; }

        [Required]
        public decimal MonthlyNetIncome { get; set; }

        [Required]
        public string SourceIncome { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string StreetAddress1 { get; set; }

        public string StreetAddress2 { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        public int CityId { get; set; }




        // these fields are calculated by a procedure

        //public int CreditRating { get; set; }
        //public int LateLoanPayments { get; set; }
        //public decimal TotalDebt { get; set; }
        //public int DemographicModelId { get; set; }
        //public int RiskRating { get; set; }



    }
}
