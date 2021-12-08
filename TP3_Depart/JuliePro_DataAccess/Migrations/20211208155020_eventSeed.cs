using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class eventSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "Compétition" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "Certification" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 3, "Levée de fonds" });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Category_Id", "Date", "Description" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cross Fit  Bahamas" },
                    { 4, 1, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trialthon" },
                    { 1, 2, new DateTime(2021, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niveau Bronze" },
                    { 5, 2, new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niveau Argent" },
                    { 3, 3, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zumba-Thon" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
