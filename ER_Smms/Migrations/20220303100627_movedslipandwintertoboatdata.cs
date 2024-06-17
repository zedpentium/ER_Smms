using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class movedslipandwintertoboatdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boatslips_BoatDatas_BoatDataId",
                table: "Boatslips");

            migrationBuilder.DropForeignKey(
                name: "FK_WinterstoreSpots_BoatDatas_BoatDataId",
                table: "WinterstoreSpots");

            migrationBuilder.DropIndex(
                name: "IX_WinterstoreSpots_BoatDataId",
                table: "WinterstoreSpots");

            migrationBuilder.DropIndex(
                name: "IX_Boatslips_BoatDataId",
                table: "Boatslips");

            migrationBuilder.DropColumn(
                name: "BoatDataId",
                table: "WinterstoreSpots");

            migrationBuilder.DropColumn(
                name: "BoatDataId",
                table: "Boatslips");

            migrationBuilder.AddColumn<int>(
                name: "BoatDataIdRef",
                table: "WinterstoreSpots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoatDataIdRef",
                table: "Boatslips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoatslipId",
                table: "BoatDatas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinterstoreSpotId",
                table: "BoatDatas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoatDatas_BoatslipId",
                table: "BoatDatas",
                column: "BoatslipId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatDatas_WinterstoreSpotId",
                table: "BoatDatas",
                column: "WinterstoreSpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatDatas_Boatslips_BoatslipId",
                table: "BoatDatas",
                column: "BoatslipId",
                principalTable: "Boatslips",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_BoatDatas_WinterstoreSpots_WinterstoreSpotId",
                table: "BoatDatas",
                column: "WinterstoreSpotId",
                principalTable: "WinterstoreSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatDatas_Boatslips_BoatslipId",
                table: "BoatDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_BoatDatas_WinterstoreSpots_WinterstoreSpotId",
                table: "BoatDatas");

            migrationBuilder.DropIndex(
                name: "IX_BoatDatas_BoatslipId",
                table: "BoatDatas");

            migrationBuilder.DropIndex(
                name: "IX_BoatDatas_WinterstoreSpotId",
                table: "BoatDatas");

            migrationBuilder.DropColumn(
                name: "BoatDataIdRef",
                table: "WinterstoreSpots");

            migrationBuilder.DropColumn(
                name: "BoatDataIdRef",
                table: "Boatslips");

            migrationBuilder.DropColumn(
                name: "BoatslipId",
                table: "BoatDatas");

            migrationBuilder.DropColumn(
                name: "WinterstoreSpotId",
                table: "BoatDatas");

            migrationBuilder.AddColumn<int>(
                name: "BoatDataId",
                table: "WinterstoreSpots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BoatDataId",
                table: "Boatslips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WinterstoreSpots_BoatDataId",
                table: "WinterstoreSpots",
                column: "BoatDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boatslips_BoatDataId",
                table: "Boatslips",
                column: "BoatDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boatslips_BoatDatas_BoatDataId",
                table: "Boatslips",
                column: "BoatDataId",
                principalTable: "BoatDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WinterstoreSpots_BoatDatas_BoatDataId",
                table: "WinterstoreSpots",
                column: "BoatDataId",
                principalTable: "BoatDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
