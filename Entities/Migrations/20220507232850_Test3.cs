using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CustomerLoans_Customers_CustomerId",
            //    table: "CustomerLoans");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerId",
            //    table: "CustomerLoans",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CustomerLoans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "CustomerLoans",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CustomerLoans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<int>(
            //    name: "LoanProductId",
            //    table: "CustomerLoans",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LoanPurpose",
                table: "CustomerLoans",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsToPayback",
                table: "CustomerLoans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLoans_LoanProductId",
                table: "CustomerLoans",
                column: "LoanProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLoans_Customers_CustomerId",
                table: "CustomerLoans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLoans_LoanProducts_LoanProductId",
                table: "CustomerLoans",
                column: "LoanProductId",
                principalTable: "LoanProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLoans_Customers_CustomerId",
                table: "CustomerLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerLoans_LoanProducts_LoanProductId",
                table: "CustomerLoans");

            migrationBuilder.DropIndex(
                name: "IX_CustomerLoans_LoanProductId",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "LoanProductId",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "LoanPurpose",
                table: "CustomerLoans");

            migrationBuilder.DropColumn(
                name: "MonthsToPayback",
                table: "CustomerLoans");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CustomerLoans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerLoans_Customers_CustomerId",
                table: "CustomerLoans",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
