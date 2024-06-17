using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class addedsizetoservicetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotPrice",
                table: "WinterstoreSpots");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ServiceTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "ServiceTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "SpotPrice",
                table: "WinterstoreSpots",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
