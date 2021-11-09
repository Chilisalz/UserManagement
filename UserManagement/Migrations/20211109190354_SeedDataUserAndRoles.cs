using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementService.Migrations
{
    public partial class SeedDataUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39bf46f0-cc42-438f-866c-c20c393a307b", "6030eb4c-db57-46ba-8e99-266e2f862379", "Admin", "ADMIN" },
                    { "372a7671-ab69-4450-b77f-306aeb4eb8f1", "c18e2fd3-2f19-466c-bd7d-3723f882f721", "DefaultChiliUser", "DEFAULTCHILIUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0da09c36-50ac-44fb-a102-8b528bcbad51", 0, "51f5dbf9-b09e-4ebf-9c5d-0edd1e35c919", "adminuser@chiliboard.de", false, true, null, "ADMINUSER@CHILIBOARD.DE", "CHILISUPERADMIN", "AQAAAAEAACcQAAAAEPxn5h6jjL/Ha+XhFLCiZfLzkE5VyhVRfHol72kHRPeLVKOlbrAxkj6dOSEzOTJCXA==", null, false, new DateTime(2021, 11, 9, 20, 3, 53, 642, DateTimeKind.Local).AddTicks(8356), "PBBLISBKCX2SC2HZZZBU4WAECY4OOEAQ", false, "ChiliSuperAdmin" },
                    { "bf9657c5-0827-44bb-b902-f627d24c0313", 0, "d4a06fd5-06fb-4fb5-8669-80247ced5cdf", "casualUser@web.de", false, true, null, "CASUALUSER@WEB.DE", "CASUALUSER69420", "AQAAAAEAACcQAAAAECDikza4w6uCucEBshQUfHf1jr2Bx9m0vEFleN7W0XbInL3xCnklLmmZkvPeOuF0Vg==", null, false, new DateTime(2021, 11, 9, 20, 3, 53, 645, DateTimeKind.Local).AddTicks(3722), "LTH2MYEEUUL6EYVUKLWIA5RUWWJZ7USV", false, "CasualUser69420" },
                    { "8c8dd0dd-a6b6-478d-a298-1011cb5bf060", 0, "37dc169f-8a94-4962-bec4-1b826f69238c", "catlover@gmail.com", false, true, null, "CATLOVER@GMAIL.COM", "CATLOVER123", "AQAAAAEAACcQAAAAENA1eoBYGBX4X4HLlowUiAZRXdhZSc5ZfhoT0LqluC8YCwLcbiAU9K6u9K1aFg8+IQ==", null, false, new DateTime(2021, 11, 9, 20, 3, 53, 645, DateTimeKind.Local).AddTicks(3773), "WZ2YPIJWNNJEIXICV3UT5ITRWDK2QPRZ", false, "CatLover123" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "39bf46f0-cc42-438f-866c-c20c393a307b", "0da09c36-50ac-44fb-a102-8b528bcbad51" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "372a7671-ab69-4450-b77f-306aeb4eb8f1", "bf9657c5-0827-44bb-b902-f627d24c0313" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "372a7671-ab69-4450-b77f-306aeb4eb8f1", "8c8dd0dd-a6b6-478d-a298-1011cb5bf060" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39bf46f0-cc42-438f-866c-c20c393a307b", "0da09c36-50ac-44fb-a102-8b528bcbad51" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "372a7671-ab69-4450-b77f-306aeb4eb8f1", "8c8dd0dd-a6b6-478d-a298-1011cb5bf060" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "372a7671-ab69-4450-b77f-306aeb4eb8f1", "bf9657c5-0827-44bb-b902-f627d24c0313" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "372a7671-ab69-4450-b77f-306aeb4eb8f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39bf46f0-cc42-438f-866c-c20c393a307b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0da09c36-50ac-44fb-a102-8b528bcbad51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c8dd0dd-a6b6-478d-a298-1011cb5bf060");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf9657c5-0827-44bb-b902-f627d24c0313");
        }
    }
}
