using Microsoft.EntityFrameworkCore.Migrations;

namespace JuliePro_DataAccess.Migrations
{
    public partial class CustomerObjective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerObjective");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Objective",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_Id",
                table: "Objective",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Objective_CustomerId",
                table: "Objective",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objective_Customer_CustomerId",
                table: "Objective",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objective_Customer_CustomerId",
                table: "Objective");

            migrationBuilder.DropIndex(
                name: "IX_Objective_CustomerId",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Objective");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Objective");

            migrationBuilder.CreateTable(
                name: "CustomerObjective",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    ObjectivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerObjective", x => new { x.CustomersId, x.ObjectivesId });
                    table.ForeignKey(
                        name: "FK_CustomerObjective_Customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerObjective_Objective_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objective",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerObjective_ObjectivesId",
                table: "CustomerObjective",
                column: "ObjectivesId");
        }
    }
}
