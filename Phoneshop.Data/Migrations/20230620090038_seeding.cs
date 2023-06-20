using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoneshop.Data.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pronoun" });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandID", "Description", "Price", "Stock", "Type" },
                values: new object[] { 1, 1, "our newest phone comrade", 5m, 0, "ourphone" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}