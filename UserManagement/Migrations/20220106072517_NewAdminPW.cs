using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserManagementService.Migrations
{
    public partial class NewAdminPW : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEMoFpxlv0k75JcYxDckqwIM+Q/OUpBHnG0CGxUrGNbPe8SuCT9BgmnZ5Mb5091WAMg==", new DateTime(2022, 1, 6, 8, 25, 16, 835, DateTimeKind.Local).AddTicks(3218), "AQAAAAEAACcQAAAAEPefExEpvKEFIqh3cSOKiRu93rkydpnnig0u8J1IiQZMUv0ru6X5Y48DItMKhts2Pw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEM4+PFxccFjRIJFhSIFf0yqL97ip4aD4UWCKdTKHszUvf0zx1a0jQ12HZa6Uxq64vQ==", new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9488), "AQAAAAEAACcQAAAAECfEPj0Kc3WkSjRBD+0A4PHc8fGBUFM/kYmOyVciwPGY4XJ6kH9Hd9E/u+VTewEt2Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEOOx54WrvJyqlxKzryYaEVzJ8Epp8gzL5CKDWnN8N63CP/ks1OuUR8eUGaLgjjvE0Q==", new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9533), "AQAAAAEAACcQAAAAENjhiQ0jJfztyQikCFmivAqKRr+w6RrCw/UTPCvTcXxgE0OyWNh4H7Q3rEgtgmilqA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEAnwfh0wE9Wssf31dZoBIG3QHj7ljGR9OTqwK7bQw+LyZm2buE9sx9F1RJEtzFXV3g==", new DateTime(2022, 1, 6, 8, 25, 16, 837, DateTimeKind.Local).AddTicks(9522), "AQAAAAEAACcQAAAAEAwPbNZSxsmcgy6YrkT5lS575mrqdpfNsxEd8A3eZFfjio83riTTcUtVsrgB14fDmA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEBzA6WvKNoJrYZJr2bNMv9nqVtizfSrZmfRPksxSV+nA6WHGvpMbTd0FYtVvHHQsnQ==", new DateTime(2022, 1, 6, 8, 20, 36, 704, DateTimeKind.Local).AddTicks(5899), "AQAAAAEAACcQAAAAENSqp3BOlNJvbUKU0+CnTXrooFYBg1GbtHwQuf4ZZgqstLdMSDGCHKb2V7dxW/95ow==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEBzA6WvKNoJrYZJr2bNMv9nqVtizfSrZmfRPksxSV+nA6WHGvpMbTd0FYtVvHHQsnQ==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6179), "AQAAAAEAACcQAAAAENSqp3BOlNJvbUKU0+CnTXrooFYBg1GbtHwQuf4ZZgqstLdMSDGCHKb2V7dxW/95ow==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEL0+HtHZGcctssHegA6T28jtrmIAuHadjb25KJIrrX4ja6AlCXXFTyFRnORVFuKD9A==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6233), "AQAAAAEAACcQAAAAEKVc1vi8MVcN3p3iddVHat8zjXgpYR1Wu7BZzpfcCiKN3QeuuSnHyInNCzwxBivFWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEL3W+0Em9YCHPfSfuABXrpXT7RpdNcO1fH4RuRwoDiOW6+A3ocLlb/JGCfeHJrbAcQ==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6223), "AQAAAAEAACcQAAAAEDL1AMl5ZcIv4JJ6cX7YcLcVKt18GA/NZEJvDWVmKWdZ4t8ZFodRR33khqZ+PoF/aw==" });
        }
    }
}
