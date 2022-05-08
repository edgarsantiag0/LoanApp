using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    MonthlyNetIncome = table.Column<decimal>(nullable: false),
                    SourceIncome = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    StreetAddress1 = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    SSN = table.Column<string>(nullable: true),
                    CreditRating = table.Column<int>(nullable: false),
                    RiskRating = table.Column<int>(nullable: false),
                    LateLoanPayments = table.Column<int>(nullable: false),
                    TotalDebt = table.Column<decimal>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    DemographicModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_DemographicModels_DemographicModelId",
                        column: x => x.DemographicModelId,
                        principalTable: "DemographicModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DemographicModelId",
                table: "Customers",
                column: "DemographicModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
