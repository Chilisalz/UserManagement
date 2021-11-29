using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementService.Migrations
{
    public partial class UserSecretAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecretQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretQuestion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretQuestion", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "SecretAnswers",
                columns: table => new
                {
                    AnswerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecretAnswer = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretAnswers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_SecretAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecretAnswers_SecretQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SecretQuestion",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0da09c36-50ac-44fb-a102-8b528bcbad51",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEK0fJlW/cn+346r0wreDXMO9vjUl1AtwqC//XIoW4RESARd78sapmEjAnz+UzUMYDA==", new DateTime(2021, 11, 21, 18, 51, 18, 405, DateTimeKind.Local).AddTicks(8207) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c8dd0dd-a6b6-478d-a298-1011cb5bf060",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEMS19rs4jDcplE4Wg3OspGEipKzd2ZBBJ4dWyOoFi/A2hYURDHXnOxuBIGsQNC1KLw==", new DateTime(2021, 11, 21, 18, 51, 18, 409, DateTimeKind.Local).AddTicks(3319) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf9657c5-0827-44bb-b902-f627d24c0313",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEDbRoA4UqChjY2WLD8MSHjLOgbo8oY15oMiSc3flezrfAmAe40XLWGKfDP6NZ2pjMg==", new DateTime(2021, 11, 21, 18, 51, 18, 409, DateTimeKind.Local).AddTicks(3241) });

            migrationBuilder.CreateIndex(
                name: "IX_SecretAnswers_QuestionId",
                table: "SecretAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretAnswers_UserId",
                table: "SecretAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecretAnswers");

            migrationBuilder.DropTable(
                name: "SecretQuestion");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0da09c36-50ac-44fb-a102-8b528bcbad51",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEBwVLuMhWFGDuFcurTuLa43TV0D1H4eMckFl2MReYzCb6dmHUq2r5MVReQNusIJGyw==", new DateTime(2021, 11, 14, 12, 23, 44, 278, DateTimeKind.Local).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c8dd0dd-a6b6-478d-a298-1011cb5bf060",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAENxUCfS0CgnIcJ5orovDoxOaDuqa3/ovj7H8892I4vRhVCOt7pgCj1jTCev93q460w==", new DateTime(2021, 11, 14, 12, 23, 44, 284, DateTimeKind.Local).AddTicks(3523) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf9657c5-0827-44bb-b902-f627d24c0313",
                columns: new[] { "PasswordHash", "RegistrationDate" },
                values: new object[] { "AQAAAAEAACcQAAAAEHu8QZFLJlg43NyyZZ0gpXvkhGRRzX1KgxXuJJAqTqc9r8dT5AIUuyAoq4rcNaJ3nQ==", new DateTime(2021, 11, 14, 12, 23, 44, 284, DateTimeKind.Local).AddTicks(3410) });
        }
    }
}
