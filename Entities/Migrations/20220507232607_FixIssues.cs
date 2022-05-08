﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Entities.Migrations
{
    public partial class FixIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //   name: "FK_CustomerLoans_Customers_CustomerId",
            //   table: "CustomerLoans");

            //migrationBuilder.AlterColumn<int>(
            //    name: "CustomerId",
            //    table: "CustomerLoans",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "CustomerLoans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "CustomerLoans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CustomerLoans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LoanProductId",
                table: "CustomerLoans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LoanPurpose",
                table: "CustomerLoans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsToPayback",
                table: "CustomerLoans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLoans_LoanProductId",
                table: "CustomerLoans",
                column: "LoanProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CustomerLoans_Customers_CustomerId",
            //    table: "CustomerLoans",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CustomerLoans_LoanProducts_LoanProductId",
            //    table: "CustomerLoans",
            //    column: "LoanProductId",
            //    principalTable: "LoanProducts",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}