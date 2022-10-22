using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationDetails1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationDetails2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationShortDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationShortDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationShortDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialProducts",
                columns: table => new
                {
                    SpecialProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialProductContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialProducts", x => x.SpecialProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "SpecialProducts");
        }
    }
}
