using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserManagementService.Migrations
{
    public partial class AddedSecretQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretAnswer",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SecretQuestionId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "Id", "Question" },
                values: new object[,]
                {
                    { new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff"), "Was ist Ihr Lieblingsessen?" },
                    { new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "Wie lautet der Geburtsname Ihrer Mutter?" },
                    { new Guid("f7f78ebd-22d5-4861-893e-7dceee4ee4fe"), "Wie lautet Ihre Lieblingsprimzahl?" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer", "SecretQuestionId" },
                values: new object[] { "AQAAAAEAACcQAAAAEDvk/MXTuFjzEuAY/616lcseXUhlM98AM9Drar+fBgJhOE/k/bqTFSA0/1OEOIEzEQ==", new DateTime(2021, 11, 30, 8, 46, 16, 484, DateTimeKind.Local).AddTicks(3519), "AQAAAAEAACcQAAAAEIwLFhw9HzCoIafOYKApLYjpGMMBsAaA3qNZ1bY6N/souakiYfxl7mtXRzWK/VXZ0w==", new Guid("f7f78ebd-22d5-4861-893e-7dceee4ee4fe") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer", "SecretQuestionId" },
                values: new object[] { "AQAAAAEAACcQAAAAELd5Zjr9HGC5P+80nX0riQo1KEPYlG38lr0NjPdsdE+OVlH09O6JrGGSBO2GWrWVpA==", new DateTime(2021, 11, 30, 8, 46, 16, 487, DateTimeKind.Local).AddTicks(676), "AQAAAAEAACcQAAAAEG75q8wwBU393tQRiMQ1Z73Kuy3X45ojTl8mh2xJgYClS5P8ZjEb+yF9sXowID3WpA==", new Guid("f3124fb0-79ce-403b-8cd4-eceafaf2a0ff") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer", "SecretQuestionId" },
                values: new object[] { "AQAAAAEAACcQAAAAEOokVgGp0g6JVCSqh/bp9bRVkGThGSylF/m8DkAZ3mcy7j9KkzUj2D1SpLdCEMgpqQ==", new DateTime(2021, 11, 30, 8, 46, 16, 487, DateTimeKind.Local).AddTicks(633), "AQAAAAEAACcQAAAAEBueZ99jjd+lfOQh4VVbe+y4c7UWKD8SWwwrjg4ZGdNp7Nc1cUJpG0W3rb/cgqaRWg==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SecretQuestionId",
                table: "Users",
                column: "SecretQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SecurityQuestions_SecretQuestionId",
                table: "Users",
                column: "SecretQuestionId",
                principalTable: "SecurityQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SecurityQuestions_SecretQuestionId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Users_SecretQuestionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecretAnswer",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecretQuestionId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEL/yQSo+xSO34YAJasxiJXYziTGtPJlU+kMBViaXvi+utEcsMRREoyPO2Q5WBxSUuQ==", new DateTime(2021, 11, 29, 18, 8, 8, 938, DateTimeKind.Local).AddTicks(8326) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEL59mDOmOd6PhsQv7ewydn7n/ueWPHbJKrQzYlO/+iv8u1/DA5WwwEW1YK+yRhw7ZA==", new DateTime(2021, 11, 29, 18, 8, 8, 941, DateTimeKind.Local).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEEaX1d68pEAzCPNY6sfwtUCtVfRS/nNNQ2Ap5POX+d0DqrUvURsLjHxtRBYmyCy8ow==", new DateTime(2021, 11, 29, 18, 8, 8, 941, DateTimeKind.Local).AddTicks(9809) });
        }
    }
}
