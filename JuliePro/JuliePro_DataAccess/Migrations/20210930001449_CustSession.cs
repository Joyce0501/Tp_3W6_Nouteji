using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class CustSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "ScheduledSession",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "ScheduledSession",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledSession_CustomerId",
                table: "ScheduledSession",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledSession_Customer_CustomerId",
                table: "ScheduledSession",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledSession_Customer_CustomerId",
                table: "ScheduledSession");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledSession_CustomerId",
                table: "ScheduledSession");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ScheduledSession");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "ScheduledSession");
        }
    }
}
