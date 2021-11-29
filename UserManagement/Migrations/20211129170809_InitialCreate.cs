using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserManagementService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rolename = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChiliUserRoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_ChiliUserRoleId",
                        column: x => x.ChiliUserRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<Guid>(type: "uuid", nullable: false),
                    JwtId = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Used = table.Column<bool>(type: "boolean", nullable: false),
                    Invalidated = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Rolename" },
                values: new object[,]
                {
                    { new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"), "Admin" },
                    { new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "DefaultChiliUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ChiliUserRoleId", "Email", "PasswordHash", "RegistrationDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"), new Guid("39bf46f0-cc42-438f-866c-c20c393a307b"), "adminuser@chiliboard.de", "AQAAAAEAACcQAAAAEL/yQSo+xSO34YAJasxiJXYziTGtPJlU+kMBViaXvi+utEcsMRREoyPO2Q5WBxSUuQ==", new DateTime(2021, 11, 29, 18, 8, 8, 938, DateTimeKind.Local).AddTicks(8326), "admin" },
                    { new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "casualUser@web.de", "AQAAAAEAACcQAAAAEEaX1d68pEAzCPNY6sfwtUCtVfRS/nNNQ2Ap5POX+d0DqrUvURsLjHxtRBYmyCy8ow==", new DateTime(2021, 11, 29, 18, 8, 8, 941, DateTimeKind.Local).AddTicks(9809), "CasualUser69420" },
                    { new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "catlover@gmail.com", "AQAAAAEAACcQAAAAEL59mDOmOd6PhsQv7ewydn7n/ueWPHbJKrQzYlO/+iv8u1/DA5WwwEW1YK+yRhw7ZA==", new DateTime(2021, 11, 29, 18, 8, 8, 941, DateTimeKind.Local).AddTicks(9852), "CatLover123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChiliUserRoleId",
                table: "Users",
                column: "ChiliUserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
