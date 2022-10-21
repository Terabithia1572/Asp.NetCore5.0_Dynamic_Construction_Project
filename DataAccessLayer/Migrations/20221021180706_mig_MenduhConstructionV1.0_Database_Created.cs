using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_MenduhConstructionV10_Database_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CategoryID",
                table: "Employees",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Categories_CategoryID",
                table: "Employees",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Categories_CategoryID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CategoryID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Employees");
        }
    }
}
