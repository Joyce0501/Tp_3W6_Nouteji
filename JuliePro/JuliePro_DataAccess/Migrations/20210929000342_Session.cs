using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class Session : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMin = table.Column<int>(type: "int", nullable: false),
                    WithTrainer = table.Column<bool>(type: "bit", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    TrainingId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledSession", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_TrainingId",
                table: "ScheduledSession",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_TrainingId1",
                table: "ScheduledSession",
                column: "TrainingId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingEquipment_Equipment_Id",
                table: "TrainingEquipment",
                column: "Equipment_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledSession");

            migrationBuilder.DropTable(
                name: "TrainingEquipment");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Training");
        }
    }
}
