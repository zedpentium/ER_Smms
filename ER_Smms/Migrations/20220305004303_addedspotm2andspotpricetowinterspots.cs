using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class addedspotm2andspotpricetowinterspots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SpotM2",
                table: "WinterstoreSpots",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SpotPrice",
                table: "WinterstoreSpots",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotM2",
                table: "WinterstoreSpots");

            migrationBuilder.DropColumn(
                name: "SpotPrice",
                table: "WinterstoreSpots");
        }
    }
}
