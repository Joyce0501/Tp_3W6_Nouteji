using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class Seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AchievedDate",
                table: "Objective",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vélo" },
                    { 2, "Ensemble dumbels" },
                    { 3, "Tapis" },
                    { 4, "Step" },
                    { 5, "Ensemble barre altère" },
                    { 6, "Bloc yoga" },
                    { 7, "Elastiques" },
                    { 8, "Ballon d'exercice" }
                });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Réhabilitation" },
                    { 3, "Althérophilie" },
                    { 2, "Course" },
                    { 1, "Perte de poids" }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "Cardio", "Step" },
                    { 2, "Étirement", "Yoga" },
                    { 3, "Musculaire", "CrossFit" },
                    { 4, "Cardio", "Course" },
                    { 5, "Cardio", "Zumba" },
                    { 6, "Musculaire", "Spinning" },
                    { 7, "Étirement", "Taichi" }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Photo", "Speciality_Id" },
                values: new object[,]
                {
                    { 1, "Chrystal.lapierre@juliepro.ca", "Chrysal", "Lappierre", "", 1 },
                    { 3, "Frank.StJohn@juliepro.ca", "François", "Saint-John", "", 1 },
                    { 2, "Felix.trudeau@juliePro.ca", "Félix", "Trudeau", "", 2 },
                    { 6, "Karine.Lachance@juliepro.ca", "Karine", "Lachance", "", 2 },
                    { 5, "JinLee.godette@juliepro.ca", "Jin Lee", "Godette", "", 3 },
                    { 7, "Ramone.Esteban@juliepro.ca", "Ramone", "Esteban", "", 3 },
                    { 4, "JC.Bastien@juliepro.ca", "Jean-Claude", "Bastien", "", 4 }
                });

            migrationBuilder.InsertData(
                table: "TrainingEquipment",
                columns: new[] { "Equipment_Id", "Training_Id" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 7, 1 },
                    { 3, 2 },
                    { 6, 2 },
                    { 8, 2 },
                    { 2, 3 },
                    { 5, 3 },
                    { 4, 3 },
                    { 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Photo", "StartWeight", "Trainer_Id" },
                values: new object[] { 1, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "arthurLaroche@gmail.com", "Arthur", "Laroche", "", null, 3 });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "Customer_Id", "DistanceKm", "LostWeight", "Name" },
                values: new object[] { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "Customer_Id", "DistanceKm", "LostWeight", "Name" },
                values: new object[] { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.0, 5.0, "" });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "Customer_Id", "DistanceKm", "LostWeight", "Name" },
                values: new object[] { 3, null, 1, 0.0, 5.0, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "TrainingEquipment",
                keyColumns: new[] { "Equipment_Id", "Training_Id" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Training",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AchievedDate",
                table: "Objective",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
