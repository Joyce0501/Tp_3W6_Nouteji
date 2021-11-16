using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingEquipment",
                columns: table => new
                {
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    Equipment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingEquipment", x => new { x.Training_Id, x.Equipment_Id });
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Equipment_Equipment_Id",
                        column: x => x.Equipment_Id,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingEquipment_Training_Training_Id",
                        column: x => x.Training_Id,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartWeight = table.Column<double>(type: "float", nullable: false),
                    Trainer_Id = table.Column<int>(type: "int", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Trainer_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LostWeight = table.Column<double>(type: "float", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    AchievedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objective_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMin = table.Column<int>(type: "int", nullable: false),
                    WithTrainer = table.Column<bool>(type: "bit", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    TrainingId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledSession_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledSession_Trainer_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledSession_Training_TrainingId1",
                        column: x => x.TrainingId1,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "Photo", "StartWeight", "TrainerId", "Trainer_Id" },
                values: new object[] { 1, new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "arthurLaroche@gmail.com", "Arthur", "Laroche", "", 0.0, null, 3 });

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
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "CustomerId", "Customer_Id", "DistanceKm", "LostWeight", "Name" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0.0, 5.0, "" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0.0, 5.0, "" },
                    { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 0.0, 5.0, "" }
                });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Perte de poids" },
                    { 2, "Course" },
                    { 3, "Althérophilie" },
                    { 4, "Réhabilitation" }
                });

            migrationBuilder.InsertData(
                table: "Training",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 6, "Musculaire", "Spinning" },
                    { 1, "Cardio", "Step" },
                    { 2, "Étirement", "Yoga" },
                    { 3, "Musculaire", "CrossFit" },
                    { 4, "Cardio", "Course" },
                    { 5, "Cardio", "Zumba" },
                    { 7, "Étirement", "Taichi" }
                });

            migrationBuilder.InsertData(
                table: "Trainer",
                columns: new[] { "Id", "Biography", "Email", "FirstName", "LastName", "Photo", "SpecialityId" },
                values: new object[,]
                {
                    { 1, null, "Chrystal.lapierre@juliepro.ca", "Chrysal", "Lappierre", "8624af64-2685-459a-a1cc-816c0695d760.png", 1 },
                    { 3, null, "Frank.StJohn@juliepro.ca", "François", "Saint-John", "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png", 1 },
                    { 2, null, "Felix.trudeau@juliePro.ca", "Félix", "Trudeau", "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 },
                    { 6, null, "Karine.Lachance@juliepro.ca", "Karine", "Lachance", "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png", 2 },
                    { 5, null, "JinLee.godette@juliepro.ca", "Jin Lee", "Godette", "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png", 3 },
                    { 7, null, "Ramone.Esteban@juliepro.ca", "Ramone", "Esteban", "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png", 3 },
                    { 4, null, "JC.Bastien@juliepro.ca", "Jean-Claude", "Bastien", "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png", 4 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TrainerId",
                table: "Customer",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_CustomerId",
                table: "Objective",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_CustomerId",
                table: "ScheduledSession",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_TrainingId",
                table: "ScheduledSession",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_TrainingId1",
                table: "ScheduledSession",
                column: "TrainingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_SpecialityId",
                table: "Trainer",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_Equipment_Id",
                table: "TrainingEquipment",
                column: "Equipment_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "ScheduledSession");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}
