using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class superadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piers_Harbours_HarbourId",
                table: "Piers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "200c8ec2-ca09-4b2d-bef3-c933066c5350", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200c8ec2-ca09-4b2d-bef3-c933066c5350");

            migrationBuilder.AddColumn<int>(
                name: "PierId",
                table: "Boatslips",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "2da6d210-e46c-4933-bdf5-3e0b288045cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "fd43e59d-c35a-44a5-86c8-d958f087f970");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022", "fdc84bce-e08d-41dd-8e40-86b07499268e", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Postcode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "779f124d-d6a1-488d-bdfb-eb40554930c4", 0, null, null, "76b2d927-66ac-48a9-b4e5-b580162d6b67", "superadmin@email.com", false, null, null, false, null, "SUPERADMIN@EMAIL.COM", "SUPERADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEGY8MkOiyZ9gOdB/grpcpT0WQytX9tevY6llDwnJs+edOqKda1GtPYQ2iST5DDVXIw==", null, false, 0, "332e3b4e-b9a5-4f08-a7a3-7e982317a68e", false, "superadmin@email.com" },
                    { "885e5c9a-880b-404f-a6b6-c9a6f611ca61", 0, null, null, "b1d7071e-ba2c-48ca-af05-f67163bf0a3b", "admin@email.com", false, null, null, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEPJ34qg8OqK8zZt0BwnhEI0kpfS0904FyQGobEoqM61AEkBIzKhvroTCxhqVISi7dA==", null, false, 0, "e3177e74-402e-4835-baf7-94dc1c1cc4d2", false, "admin@email.com" },
                    { "ae413acf-423c-47b6-8902-1056e0bbccff", 0, null, null, "bd7097c6-eaf8-4441-ad37-c7011c372255", "customer1@email.com", false, null, null, false, null, "CUSTOMER1@EMAIL.COM", "CUSTOMER1", "AQAAAAEAACcQAAAAEBgO26UA3RthNLHmPsVVQSZDm6lDLrJBkFcAJPeVCoC2OJIQxZ0h0KmCAzO+/g/UDA==", null, false, 0, "f5ec9a60-6d87-4cc8-a095-e8f0788e282c", false, "customer1@email.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "885e5c9a-880b-404f-a6b6-c9a6f611ca61", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ae413acf-423c-47b6-8902-1056e0bbccff", "0948bea6-fb82-49c9-8cd8-fec213fe8e8a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "779f124d-d6a1-488d-bdfb-eb40554930c4", "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022" });

            migrationBuilder.CreateIndex(
                name: "IX_Boatslips_PierId",
                table: "Boatslips",
                column: "PierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boatslips_Piers_PierId",
                table: "Boatslips",
                column: "PierId",
                principalTable: "Piers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Piers_Harbours_HarbourId",
                table: "Piers",
                column: "HarbourId",
                principalTable: "Harbours",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boatslips_Piers_PierId",
                table: "Boatslips");

            migrationBuilder.DropForeignKey(
                name: "FK_Piers_Harbours_HarbourId",
                table: "Piers");

            migrationBuilder.DropIndex(
                name: "IX_Boatslips_PierId",
                table: "Boatslips");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "779f124d-d6a1-488d-bdfb-eb40554930c4", "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "885e5c9a-880b-404f-a6b6-c9a6f611ca61", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ae413acf-423c-47b6-8902-1056e0bbccff", "0948bea6-fb82-49c9-8cd8-fec213fe8e8a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "779f124d-d6a1-488d-bdfb-eb40554930c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "885e5c9a-880b-404f-a6b6-c9a6f611ca61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae413acf-423c-47b6-8902-1056e0bbccff");

            migrationBuilder.DropColumn(
                name: "PierId",
                table: "Boatslips");

            migrationBuilder.CreateTable(
                name: "HarbourPier",
                columns: table => new
                {
                    Harbour_Id = table.Column<int>(type: "int", nullable: false),
                    Pier_Id = table.Column<int>(type: "int", nullable: false),
                    PierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarbourPier", x => new { x.Harbour_Id, x.Pier_Id });
                    table.ForeignKey(
                        name: "FK_HarbourPier_Harbours_Harbour_Id",
                        column: x => x.Harbour_Id,
                        principalTable: "Harbours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HarbourPier_Piers_PierId",
                        column: x => x.PierId,
                        principalTable: "Piers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "071a3d52-844c-482f-bf37-9d5810623c9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "4c573c26-f694-4d3d-b084-3b1030fcbbe3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Postcode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "200c8ec2-ca09-4b2d-bef3-c933066c5350", 0, null, null, "9043a5ba-faab-415b-8671-d123d11fcc3c", "admin@email.com", false, null, null, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEHWfxVF9XeD1+dsrtjuzBRKzdo/JvgnqbQVzEGW0dmFANaSva7jJuuwx1CbYi9EmCw==", null, false, 0, "9c0d71da-7560-4363-b415-22983092ac9a", false, "admin@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "200c8ec2-ca09-4b2d-bef3-c933066c5350", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.CreateIndex(
                name: "IX_HarbourPier_PierId",
                table: "HarbourPier",
                column: "PierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piers_Harbours_HarbourId",
                table: "Piers",
                column: "HarbourId",
                principalTable: "Harbours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
