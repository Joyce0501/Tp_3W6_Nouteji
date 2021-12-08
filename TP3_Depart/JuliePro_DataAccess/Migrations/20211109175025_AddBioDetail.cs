using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class AddBioDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Trainer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "ScheduledSession",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "8624af64-2685-459a-a1cc-816c0695d760.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Photo",
                value: "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Photo",
                value: "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Photo",
                value: "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 7,
                column: "Photo",
                value: "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "ScheduledSession");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 5,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 6,
                column: "Photo",
                value: "");

            migrationBuilder.UpdateData(
                table: "Trainer",
                keyColumn: "Id",
                keyValue: 7,
                column: "Photo",
                value: "");
        }
    }
}
