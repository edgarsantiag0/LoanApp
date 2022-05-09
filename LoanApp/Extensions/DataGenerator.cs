using Entities;
using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanApp.Extensions
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any board games.
                //if (context.Countries.Any())
                //{
                //    return;   // Data was already seeded
                //}

                //Countries

                context.Countries.AddRange(
                    new Country
                    {
                        Id = 1,
                        Name = "United States"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "Canada"
                    }, 
                    new Country
                    {
                        Id = 3,
                        Name = "Dominican Republic"
                    }
                    );

                //States

                context.States.AddRange(
                    new State
                    {
                        Id = 1,
                        Name = "Virginia",
                        CountryId = 1
                    },
                    new State
                    {
                        Id = 2,
                        Name = "New York",
                        CountryId = 1
                    },
                    new State
                    {
                        Id = 3,
                        Name = "California",
                        CountryId = 1
                    }
                    );

                //Cities

                context.Cities.AddRange(
                   new City
                   {
                       Id = 1,
                       Name = "Centreville",
                       StateId = 1
                   },
                    new City
                    {
                        Id = 2,
                        Name = "Bronx",
                        StateId = 2
                    },
                    new City
                    {
                        Id = 3,
                        Name = "San Francisco",
                        StateId = 3
                    },
                     new City
                     {
                         Id = 4,
                         Name = "Chantilly",
                         StateId = 1
                     },
                      new City
                      {
                          Id = 5,
                          Name = "Brooklyn",
                          StateId = 2
                      },
                      new City
                      {
                          Id = 6,
                          Name = "Los Angeles",
                          StateId = 3
                      }
                   );


                // Business

                context.Businesses.AddRange(
                    new Entities.Models.Business
                    {
                        Id = 1,
                        Name = "Financial 001",
                        About = "",
                        CityId = 1,
                        Email = "contact@financial001.com",
                        Phone = "703-854-8969",
                        LogoURL = "",
                        StreetAddress1 = "123 Ave",
                        StreetAddress2 = "Suite 236",
                        WebsiteURL = "",
                        ZipCode = 20120
                    },
                     new Entities.Models.Business
                     {
                         Id = 2,
                         Name = "Good Loans xyz",
                         About = "",
                         CityId = 2,
                         Email = "contact@goodloanxyz.com",
                         Phone = "703-854-1234",
                         LogoURL = "",
                         StreetAddress1 = "First st",
                         StreetAddress2 = "Suite 123",
                         WebsiteURL = "",
                         ZipCode = 10150
                     },
                      new Entities.Models.Business
                      {
                          Id = 3,
                          Name = "Jhon Loans",
                          About = "",
                          CityId = 3,
                          Email = "contact@jhonloan.com",
                          Phone = "703-222-7412",
                          LogoURL = "",
                          StreetAddress1 = "George Ave",
                          StreetAddress2 = "Suite 789",
                          WebsiteURL = "",
                          ZipCode = 15124
                      }
                    );

                //Loan products

                Random rnd = new Random();
              

                context.LoanProducts.AddRange(
                    new LoanProduct
                    {
                        Id = 1,
                        APR = rnd.Next(4, 13),
                        BusinessId = 1,
                        Description = "Loan to improve your home",
                        Length = 48,
                        MinAmount = 2000,
                        MaxAmount = 5000,
                        MonthlyPayment = 230                  
                    },
                     new LoanProduct
                     {
                         Id = 2,
                         APR = rnd.Next(4, 13),
                         BusinessId = 2,
                         Description = "Personal loan",
                         Length = 60,
                         MinAmount = 5000,
                         MaxAmount = 10000,
                         MonthlyPayment = 230
                     },
                      new LoanProduct
                      {
                          Id = 3,
                          APR = rnd.Next(4, 13),
                          BusinessId = 3,
                          Description = "Loan to travel to Europe",
                          Length = 72,
                          MinAmount = 8000,
                          MaxAmount = 12000,
                          MonthlyPayment = 230
                      }
                    );


                // DemographicModel

                context.DemographicModels.AddRange(
                   new DemographicModel
                   {
                       Id = 1,
                       Characteristics = "Upper middle class, high education, etc ",
                       Name = "Demo 1"
                   },
                    new DemographicModel
                    {
                        Id = 2,
                        Characteristics = "Middle class, xyz",
                        Name = "Demo 2"
                    },
                    new DemographicModel
                    {
                        Id = 3,
                        Characteristics = "Lower middle class, ijk",
                        Name = "Demo 3"
                    },
                    new DemographicModel
                    {
                        Id = 4,
                        Characteristics = "Poor, 123 ",
                        Name = "Demo 4"
                    }
                   );


                // Customers

                context.Customers.AddRange(
                  new Customer
                  {
                      Id = 1,
                      DemographicModelId = 1,
                      CityId = 1,
                      CreditRating = rnd.Next(600, 751),
                      DateOfBirth  = new DateTime(1991, 12, 31),
                      Email = "cm@hola.com",
                      FirstName = "Carla",
                      LastName = "Smith",
                      Gender =  Gender.Female,
                      LateLoanPayments = rnd.Next(15),
                      MonthlyNetIncome = 6700,
                      Phone = "123-874-9658",
                      SourceIncome = "Job 123",
                      SSN = "123-58-9874",
                      StreetAddress1 = "123 Ave",
                      StreetAddress2 =  "apt 547",
                      TotalDebt = rnd.Next(25000, 1000000),
                      ZipCode = 20120
                      
                  },
                   new Customer
                   {
                       Id = 2,
                       DemographicModelId = 2,
                       CityId = 2,
                       CreditRating = rnd.Next(600, 751),
                       DateOfBirth = new DateTime(1993, 12, 31),
                       Email = "mp@hola.com",
                       FirstName = "Marcus",
                       LastName = "Place",
                       Gender = Gender.Male,
                       LateLoanPayments = rnd.Next(15),
                       MonthlyNetIncome = 5200,
                       Phone = "123-785-9658",
                       SourceIncome = "Job xyz",
                       SSN = "123-74-1177",
                       StreetAddress1 = "ijk st",
                       StreetAddress2 = "apt 896",
                       TotalDebt = rnd.Next(25000, 1000000),
                       ZipCode = 11258

                   },
                   new Customer
                   {
                       Id = 3,
                       DemographicModelId = 3,
                       CityId = 3,
                       CreditRating = rnd.Next(600, 751),
                       DateOfBirth = new DateTime(1995, 12, 31),
                       Email = "aj@hola.com",
                       FirstName = "Albert",
                       LastName = "Jobs",
                       Gender = Gender.Male,
                       LateLoanPayments = rnd.Next(15),
                       MonthlyNetIncome = 2800,
                       Phone = "789-741-9658",
                       SourceIncome = "Job soft loan",
                       SSN = "321-87-9865",
                       StreetAddress1 = "123 Ave",
                       StreetAddress2 = "apt 741",
                       TotalDebt = rnd.Next(25000, 1000000),
                       ZipCode = 12745

                   },
                   new Customer
                   {
                       Id = 4,
                       DemographicModelId = 4,
                       CityId = 1,
                       CreditRating = rnd.Next(600, 751),
                       DateOfBirth = new DateTime(1996, 12, 31),
                       Email = "bm@hola.com",
                       FirstName = "Bill",
                       LastName = "Musk",
                       Gender = Gender.Male,
                       LateLoanPayments = rnd.Next(15),
                       MonthlyNetIncome = 2500,
                       Phone = "123-874-9658",
                       SourceIncome = "Micro tesla",
                       SSN = "741-32-7452",
                       StreetAddress1 = "Trin Pkwy",
                       StreetAddress2 = "apt 316",
                       TotalDebt = rnd.Next(25000, 1000000),
                       ZipCode = 20120

                   },
                   new Customer
                   {
                       Id = 5,
                       DemographicModelId = 2,
                       CityId = 3,
                       CreditRating = rnd.Next(600, 751),
                       DateOfBirth = new DateTime(1992, 12, 31),
                       Email = "hp@hola.com",
                       FirstName = "Hillary",
                       LastName = "Payton",
                       Gender = Gender.Female,
                       LateLoanPayments = rnd.Next(15),
                       MonthlyNetIncome = 4700,
                       Phone = "123-852-7452",
                       SourceIncome = "Secretary of State",
                       SSN = "123-12-8563",
                       StreetAddress1 = "NW 123 Ave",
                       StreetAddress2 = "apt 745",
                       TotalDebt = rnd.Next(25000, 1000000),
                       ZipCode = 19852

                   }
                  );


                var customerLoans = new List<CustomerLoan>();

                for (int i = 1; i <= 1000; i++)
                {

                    var obj = new CustomerLoan()
                    {
                        Id = i,
                        Amount = rnd.Next(4000, 6001),
                        Balance = rnd.Next(500, 3501),
                        CustomerId = rnd.Next(1, 6),
                        Date = RandomDay(),
                        LoanProductId = rnd.Next(1, 4),
                        LoanPurpose = "Purpose: "+ i,
                        LoanRepresentative = "LoanRepresentative: "+ i,
                        MonthsToPayback = rnd.Next(48, 61),
                        IsDeleted = false
                    };

                    customerLoans.Add(obj);
                }

                context.CustomerLoans.AddRange(customerLoans);

               context.SaveChanges();
            }
        }

        private static Random gen = new Random();

        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
