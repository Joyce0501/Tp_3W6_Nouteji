using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class Certfication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Trainer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CertificationCenter = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainerCertification",
                columns: table => new
                {
                    Trainer_Id = table.Column<int>(type: "int", nullable: false),
                    Certification_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerCertification", x => new { x.Trainer_Id, x.Certification_Id });
                    table.ForeignKey(
                        name: "FK_TrainerCertification_Certification_Certification_Id",
                        column: x => x.Certification_Id,
                        principalTable: "Certification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainerCertification_Trainer_Trainer_Id",
                        column: x => x.Trainer_Id,
                        principalTable: "Trainer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Active",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainerCertification_Certification_Id",
                table: "TrainerCertification",
                column: "Certification_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainerCertification");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Trainer");
        }
    }
}
