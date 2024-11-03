using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiGestores.Migrations
{
    public partial class mssqllocal_migration_529 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "foods");

            migrationBuilder.AddColumn<DateTime>(
                name: "Order_Date",
                table: "foods",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Total_Price",
                table: "foods",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Unit_Price",
                table: "foods",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_Date",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "Total_Price",
                table: "foods");

            migrationBuilder.DropColumn(
                name: "Unit_Price",
                table: "foods");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "foods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "foods",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
