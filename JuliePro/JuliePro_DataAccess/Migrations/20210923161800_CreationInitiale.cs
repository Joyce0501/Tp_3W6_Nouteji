using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class CreationInitiale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Speciality_Id = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_SpecialityId",
                table: "Trainer",
                column: "SpecialityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}
