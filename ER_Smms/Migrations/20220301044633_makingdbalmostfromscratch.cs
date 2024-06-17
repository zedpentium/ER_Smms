using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class makingdbalmostfromscratch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    BrandModel = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Depth = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExtraInfoTextarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    ApplicantId = table.Column<int>(nullable: true),
                    BoatDataId = table.Column<int>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: true),
                    InQueue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceApplications_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceApplications_BoatDatas_BoatDataId",
                        column: x => x.BoatDataId,
                        principalTable: "BoatDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceApplications_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceApplications_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServiceHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    BoatDataId = table.Column<int>(nullable: true),
                    ServiceTypeId = table.Column<int>(nullable: true),
                    BoatslipId = table.Column<int>(nullable: true),
                    WinterstoreSpotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_BoatDatas_BoatDataId",
                        column: x => x.BoatDataId,
                        principalTable: "BoatDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_Boatslips_BoatslipId",
                        column: x => x.BoatslipId,
                        principalTable: "Boatslips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ServiceHistories_WinterstoreSpots_WinterstoreSpotId",
                        column: x => x.WinterstoreSpotId,
                        principalTable: "WinterstoreSpots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApplications_ApplicantId",
                table: "ServiceApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApplications_BoatDataId",
                table: "ServiceApplications",
                column: "BoatDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApplications_CustomerId",
                table: "ServiceApplications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApplications_ServiceTypeId",
                table: "ServiceApplications",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_BoatDataId",
                table: "ServiceHistories",
                column: "BoatDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_BoatslipId",
                table: "ServiceHistories",
                column: "BoatslipId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_CustomerId",
                table: "ServiceHistories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_ServiceTypeId",
                table: "ServiceHistories",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistories_WinterstoreSpotId",
                table: "ServiceHistories",
                column: "WinterstoreSpotId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ServiceApplications");

            migrationBuilder.DropTable(
                name: "ServiceHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Boatslips");

            migrationBuilder.DropTable(
                name: "WinterstoreSpots");

            migrationBuilder.DropTable(
                name: "MooringTypes");

            migrationBuilder.DropTable(
                name: "Piers");

            migrationBuilder.DropTable(
                name: "BoatDatas");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Harbours");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
