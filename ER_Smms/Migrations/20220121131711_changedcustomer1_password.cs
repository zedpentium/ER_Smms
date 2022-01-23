using Microsoft.EntityFrameworkCore.Migrations;

namespace ER_Smms.Migrations
{
    public partial class changedcustomer1_password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0948bea6-fb82-49c9-8cd8-fec213fe8e8a",
                column: "ConcurrencyStamp",
                value: "c5814d4d-30d3-454f-88f0-02e4ddaeb831");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "438db5c8-0513-43a0-a84c-cd416c4e3a54",
                column: "ConcurrencyStamp",
                value: "73560a86-d1af-4672-9b91-596c78249885");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022",
                column: "ConcurrencyStamp",
                value: "033f0d7d-93c1-474e-9334-4be93d4dfb86");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Postcode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0fc7006f-1864-4244-958d-a4cf378298a5", 0, null, null, "a23a8037-e116-4e06-876a-cb43fe346fee", "superadmin@email.com", false, null, null, false, null, "SUPERADMIN@EMAIL.COM", "SUPERADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEOm/Tt/orkL0XD8dHZMe/BcS7ejzIv1P710oXWX5NZ0usanKr7sU1+V/Mk8qZ5vlMQ==", null, false, 0, "8cbd64b8-c408-465f-a90a-0bff2c9ee798", false, "superadmin@email.com" },
                    { "95d95d35-ae78-4aac-8fb7-a62ee9a068c7", 0, null, null, "1975f345-256a-44ca-9b67-ac52345ab61f", "admin@email.com", false, null, null, false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEKs3jZzomz4+YsLVY0HSb5zirvrEaZ8mfLT5b3oMN6u3/8a53iGyNRPVczjYd0e03Q==", null, false, 0, "2a0644e8-c0e7-442b-9a42-406b8bb7132d", false, "admin@email.com" },
                    { "4c31146d-59fa-4e29-a013-0096afc6d903", 0, null, null, "6345ec60-070f-467e-b198-12fd14f99ec8", "customer1@email.com", false, null, null, false, null, "CUSTOMER1@EMAIL.COM", "CUSTOMER1", "AQAAAAEAACcQAAAAEGBCa1rWOmIIpKcDNyX5NH9wZri38TnuV+awmZsvkvMhZk3lPIMzLAVv7bx0E9xDNA==", null, false, 0, "01d44e16-2bd3-407b-820d-64a656ea75c6", false, "customer1@email.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0fc7006f-1864-4244-958d-a4cf378298a5", "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "95d95d35-ae78-4aac-8fb7-a62ee9a068c7", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4c31146d-59fa-4e29-a013-0096afc6d903", "0948bea6-fb82-49c9-8cd8-fec213fe8e8a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0fc7006f-1864-4244-958d-a4cf378298a5", "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4c31146d-59fa-4e29-a013-0096afc6d903", "0948bea6-fb82-49c9-8cd8-fec213fe8e8a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "95d95d35-ae78-4aac-8fb7-a62ee9a068c7", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fc7006f-1864-4244-958d-a4cf378298a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c31146d-59fa-4e29-a013-0096afc6d903");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95d95d35-ae78-4aac-8fb7-a62ee9a068c7");

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022",
                column: "ConcurrencyStamp",
                value: "fdc84bce-e08d-41dd-8e40-86b07499268e");

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
                values: new object[] { "779f124d-d6a1-488d-bdfb-eb40554930c4", "4a4490c0-ca96-4ace-8e9f-4fc1e91f0022" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "885e5c9a-880b-404f-a6b6-c9a6f611ca61", "438db5c8-0513-43a0-a84c-cd416c4e3a54" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ae413acf-423c-47b6-8902-1056e0bbccff", "0948bea6-fb82-49c9-8cd8-fec213fe8e8a" });
        }
    }
}
