using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserManagementService.Migrations
{
    public partial class NewAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEL0+HtHZGcctssHegA6T28jtrmIAuHadjb25KJIrrX4ja6AlCXXFTyFRnORVFuKD9A==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6233), "AQAAAAEAACcQAAAAEKVc1vi8MVcN3p3iddVHat8zjXgpYR1Wu7BZzpfcCiKN3QeuuSnHyInNCzwxBivFWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEL3W+0Em9YCHPfSfuABXrpXT7RpdNcO1fH4RuRwoDiOW6+A3ocLlb/JGCfeHJrbAcQ==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6223), "AQAAAAEAACcQAAAAEDL1AMl5ZcIv4JJ6cX7YcLcVKt18GA/NZEJvDWVmKWdZ4t8ZFodRR33khqZ+PoF/aw==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ChiliUserRoleId", "Email", "PasswordHash", "RegistrationDate", "SecretAnswer", "SecretQuestionId", "UserName" },
                values: new object[] { new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"), new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"), "nis@chiliboard.de", "AQAAAAEAACcQAAAAEBzA6WvKNoJrYZJr2bNMv9nqVtizfSrZmfRPksxSV+nA6WHGvpMbTd0FYtVvHHQsnQ==", new DateTime(2022, 1, 6, 8, 20, 36, 707, DateTimeKind.Local).AddTicks(6179), "AQAAAAEAACcQAAAAENSqp3BOlNJvbUKU0+CnTXrooFYBg1GbtHwQuf4ZZgqstLdMSDGCHKb2V7dxW/95ow==", new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"), "nis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAENpCczfwPH9rnfB1Ki4/v8miKnEhs0CgRLLjr7snW3HkxcPvzJpHGZ0IZv8CDJtNYw==", new DateTime(2022, 1, 6, 7, 54, 2, 732, DateTimeKind.Local).AddTicks(5315), "AQAAAAEAACcQAAAAEPDxDx997XMEPPGqw27iNVf5jTK98fLkBLW0r6i58NBRx27dMxnMH40x1Xav6D6AvA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEPvJbJKhr6D84/m9P8SQn0EeHgjHy4DrgdA+9fOlRNz76FkUFEs4Jx1zeW1dhh9i0g==", new DateTime(2022, 1, 6, 7, 54, 2, 735, DateTimeKind.Local).AddTicks(5784), "AQAAAAEAACcQAAAAEPIeueJyNdlbX8Yrvywgb+g/5iADnjTr+03rJvwIQDFFp4FYrI2e3PdRhCdJX8s88Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEHY5TG9LC8VDWJddX6KdHhb528h4y3b+fgJKBjhBxOAZ+PelefUnGwoUAPJzoE/FCA==", new DateTime(2022, 1, 6, 7, 54, 2, 735, DateTimeKind.Local).AddTicks(5747), "AQAAAAEAACcQAAAAEBzsdybkOERahl6Tls9xq/PwbxqTp+QZDqza7clSgqU64gpR8piz2g3u/cPvYSNiWQ==" });
        }
    }
}
