using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementService.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEDvk/MXTuFjzEuAY/616lcseXUhlM98AM9Drar+fBgJhOE/k/bqTFSA0/1OEOIEzEQ==", new DateTime(2021, 11, 30, 8, 46, 16, 484, DateTimeKind.Local).AddTicks(3519), "AQAAAAEAACcQAAAAEIwLFhw9HzCoIafOYKApLYjpGMMBsAaA3qNZ1bY6N/souakiYfxl7mtXRzWK/VXZ0w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAELd5Zjr9HGC5P+80nX0riQo1KEPYlG38lr0NjPdsdE+OVlH09O6JrGGSBO2GWrWVpA==", new DateTime(2021, 11, 30, 8, 46, 16, 487, DateTimeKind.Local).AddTicks(676), "AQAAAAEAACcQAAAAEG75q8wwBU393tQRiMQ1Z73Kuy3X45ojTl8mh2xJgYClS5P8ZjEb+yF9sXowID3WpA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEOokVgGp0g6JVCSqh/bp9bRVkGThGSylF/m8DkAZ3mcy7j9KkzUj2D1SpLdCEMgpqQ==", new DateTime(2021, 11, 30, 8, 46, 16, 487, DateTimeKind.Local).AddTicks(633), "AQAAAAEAACcQAAAAEBueZ99jjd+lfOQh4VVbe+y4c7UWKD8SWwwrjg4ZGdNp7Nc1cUJpG0W3rb/cgqaRWg==" });
        }
    }
}
