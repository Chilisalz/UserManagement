using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UserManagementService.Migrations
{
    public partial class NewTestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad51"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEAdJXavdRynohCvJOvY2Wpv2Xq5S8KrDwzMmYZ7cgH5lHfIviLwUuVx8ZvUdRaFF/g==", new DateTime(2022, 1, 11, 19, 15, 48, 873, DateTimeKind.Local).AddTicks(7956), "AQAAAAEAACcQAAAAEAud5bCLrgnTxxRZwEAaLE8m2/zbWig6pryJjG9AeJ7gmlZbhfVlKXlsgSHf1d27tw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0da09c36-50ac-44fb-a102-8b528bcbad58"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEK+exn1vYmkvrp2Dr5j4K63J38U28w5sEKD/X1XUvfn7Nh51MjcbQnY5JPpY7oo4kA==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8694), "AQAAAAEAACcQAAAAEM6XxJmfFqvjCoJAbIKHmw1Dy9MqTvybKNTNBNrNY1QxFTXAwUaQv5zOjFc6JvCwmw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c8dd0dd-a6b6-478d-a298-1011cb5bf060"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAECjj1TmdUDnBfqt7tWifyLxjBb6LVNQS/cxT0bgSiMKx3YKYQ1lBTDe66Bjaanarxw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8743), "AQAAAAEAACcQAAAAEFkcn8oRFRyC1ThHq20AuFE/jhSuDYUxiRuRqUCCuczpnGy2aC9mAZ/FCYlY7mUZRQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf9657c5-0827-44bb-b902-f627d24c0313"),
                columns: new[] { "PasswordHash", "RegistrationDate", "SecretAnswer" },
                values: new object[] { "AQAAAAEAACcQAAAAEJl4hW6EYhnxkedXG/fCWJp9ayAkJ7jrjKxTKovZ9pLvve7cjw3lhqn1UbMifQJRow==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8733), "AQAAAAEAACcQAAAAEF0IjRa51lQg6xDcSw0q5GuSYRfoSYu5BBQ9Oj8UMElwXqu05oJGJJM6XjxlpsU0UQ==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ChiliUserRoleId", "Email", "PasswordHash", "RegistrationDate", "SecretAnswer", "SecretQuestionId", "UserName" },
                values: new object[,]
                {
                    { new Guid("25ca9040-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "ilial@icloud.com", "AQAAAAEAACcQAAAAELotDZvHMMIifQJ/0BMp3S+zaSgwzgiIfxpcDG9YNFsvKD4UA7XcN30Ky8F6SOpGvQ==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8876), "AQAAAAEAACcQAAAAEDUMVEpuo/2ubRYRNrEPxYqwb2SgnXOcc/wAAadAbOrUaRNYzAz/QKBUHVV9Q2sbYA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "ilial" },
                    { new Guid("25ca8f32-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "chaffar@mac.com", "AQAAAAEAACcQAAAAEIPODGLMvXPegULfpKpiC2XTeai05C5KRxMUdBASD3H8PFlmGL4DfMOyF316GukktQ==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8870), "AQAAAAEAACcQAAAAEIvZyQWcMgo2Pxrd99D09FTNJG65xkz+wHftyFmF3XPsJz8UMSXKmc2Qfz3nMNsUiA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "chaffar" },
                    { new Guid("25ca8e24-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "gmcgath@gmail.com", "AQAAAAEAACcQAAAAENd79gojjfu9mehZ+5U+Lwoe5G0Ilwu5ZIez8KrijxqsrUnMy7/GhjRXtXHAk9sHiw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8864), "AQAAAAEAACcQAAAAECLuhC38SXntGJe/N0hmFMqzGLdJBngfndnU4/JSnBlvcjt4CjyGNFjxkBxQVUqkNQ==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "gmcgath" },
                    { new Guid("25ca8cf8-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "frosal@optonline.net", "AQAAAAEAACcQAAAAEBtu23Z3RYu/bJWr9JIR+ZGdFN8Uf1y3wR4Qacq8YuvKgHd83RuedwGoZ4UoKNq6Tw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8858), "AQAAAAEAACcQAAAAEAgHczcmV8RSYMiT4eM4qKLV0DWSTHlB5AQDjDfIubOji/V+jAHAYTkHD586LjoPMQ==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "frosal" },
                    { new Guid("25ca8bcc-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "fudrucker@sbcglobal.net", "AQAAAAEAACcQAAAAEMc7slgeUJBR6EpORgv3ofA3cAbtyOqvnGenvZNY4nBgrXKASdqWTGBAIghSG9KUWw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8850), "AQAAAAEAACcQAAAAEEVjahbsl1OwvJuvQFjeJJJ+0foXX/UEGBIrgKOiS91JtWupyQTnDNztLkoBlvwKkw==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "fudrucker" },
                    { new Guid("25ca8aa0-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "kosact@hotmail.com", "AQAAAAEAACcQAAAAEJ4e3mfuOtK4pEgWw2ji8q4r6mCiW5eDj4Qn851LbH3sRIPtsodJMzClfZtEVZ0Rww==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8844), "AQAAAAEAACcQAAAAEAwixjdyIGk5iYyvCIX3z1qwLxWvPioApkD9hlFEsm9rXZ7qXFpU843FZLsuUOyWkw==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "kosact" },
                    { new Guid("25ca896a-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "mfleming@mac.com", "AQAAAAEAACcQAAAAEH0saf64rIf5Fi5+IpqKdw4/JX4oIzKoC1vSqIB7gWYnatuF66X28/s7wNXu301RmA==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8837), "AQAAAAEAACcQAAAAEPbObPMEBJLy4XOwDvgBtmrk0Y5ki2Hzgew1ee4UHPv5NSuXRZyFq/0NA57a4NqIyw==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "mfleming" },
                    { new Guid("25ca856e-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "kewley@aol.com", "AQAAAAEAACcQAAAAEHE0/1o41zNvbYcuf3W0i2u1Bq9WnFIroXJVqV7QN/OEmNvAZZG0EErY3ZZAJ9iKEA==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8830), "AQAAAAEAACcQAAAAEEmwhG+lqKHy5xMyJE0IrKST1Wf5CgSAJNBFiiMFK8+FbXIr1usKk+5kREALmgkpBQ==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "kewley" },
                    { new Guid("25ca8442-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "violinhi@me.com", "AQAAAAEAACcQAAAAEMCqqjf+ao7E96/Vb6HURR7J8jH90ERGgYwfmlR3vvWEqf9wB8AJAXwNQGPUMGu76g==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8825), "AQAAAAEAACcQAAAAEDpVtj14iwLggyW579luKibypZcIkblCrWgvwsBriE3Lan6zbPW2zl4P/i2lCcwNTA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "violinhi" },
                    { new Guid("25ca81f4-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "janneh@mac.com", "AQAAAAEAACcQAAAAEBq0Mv1ZO5DYwl/204bAT+pYkWbAlo3I+QW8g98xxux3E9LcoHsDd2emwQGyJmq7dg==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8812), "AQAAAAEAACcQAAAAEE/FeBsxjSTk1AuCAWBXlNDwxLyIKMGQB3ofmPEfi68VsLh/CyLsMsgbviX0kg3Wvw==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "janneh" },
                    { new Guid("25ca80d2-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "dinther@sbcglobal.net", "AQAAAAEAACcQAAAAEA5+Zus3u+9ZB/iIQQPsLnV89JZHD6r9B86OafYypreCvtTxY5NDr0G7F6weqUj4Dw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8806), "AQAAAAEAACcQAAAAECWoJc/+aP5gGEnK9tl6fskUODNmcmvAYJE/qMtLMPHKu5ODWfwZgCLkXB/Ug0CFGw==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "dinther" },
                    { new Guid("25ca7fa6-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "kspiteri@comcast.net", "AQAAAAEAACcQAAAAEKnEvj2zqp1LhbkVNFUqM57vZXoB20aHSOu5OXTXCBnlDQDys+ihsi/SMCpv6ELpRg==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8799), "AQAAAAEAACcQAAAAEJMRzNWNZf7IOWVJcpYN8Wt7mGTFOJzTDju70Na4r+PP1hPgYzFHBRIeyQboOA2zYA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "kspiteri" },
                    { new Guid("25ca7e8e-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "moonlapse@comcast.net", "AQAAAAEAACcQAAAAECFNkKvCs+y0IsNSMXYwm6pzIied7oA5i2wQd+sO9NyqgrULOKuP3WxE4Lp2yuWxAA==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8792), "AQAAAAEAACcQAAAAEJ6HOZ6HF/aGRfh1iSrZnb4YNel1urJ7EYw4Qe9Vf0/euc1gLtIz4AmHVTWJr2IWOA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "moonlapse" },
                    { new Guid("25ca7d44-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "sharon@yahoo.com", "AQAAAAEAACcQAAAAEPJJ8UMQ7dsDvuL+US6sEQ5vL9tZT8+9HK6G7OmKfolVD0v1krPtpXATbfvFsGGDTg==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8785), "AQAAAAEAACcQAAAAEJqIIDEKTRWE6pPsR6tKgRmPUL/ImQLEqLhkVK1Z/E55fCb4nj2aSltL83OO+vEjpg==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "sharon" },
                    { new Guid("25ca7a4c-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "kempsonc@yahoo.ca", "AQAAAAEAACcQAAAAEFPc4RSpKFVziGSDRkJucy1l74X948PiVvamsRvvOzxPLyQSUeN5rVr5PJMKI0F2Eg==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8778), "AQAAAAEAACcQAAAAEMhQ1+sr9s9CIY79rml2CZV5b1o9LE2G++/DA6DI4cMGLXlUA/2ta1bss/Qp2v/UsA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "kempsonc" },
                    { new Guid("25ca7920-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "rnelson@sbcglobal.net", "AQAAAAEAACcQAAAAENSbcKei8yjFZpSGIiPom4nUkl5ZY5fKGUpfYwz5PSZ13B4Q15hYt+FN5iuLW1wYtg==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8771), "AQAAAAEAACcQAAAAEEJ2aadah21YW5Qdk/lA7j8MfZbkUD8sCxlybSCFOukoGof9ajdLgN9qydf0nTHCoA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "rnelson" },
                    { new Guid("25ca77e0-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "kempsonc@comcast.net", "AQAAAAEAACcQAAAAEBLHtQuoXxZpjIb9Haq+SCWN8dmWywhjZYTNwb+JHaW4mPbvcKORaWoWPaWDVgjm3A==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8765), "AQAAAAEAACcQAAAAEMydsUyqq9ndISuZWsd3vV2M68MZDVw1HcKbvZcZ0h1CbRr9EUH20zAuOJkNz1sA+Q==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "kempsonc" },
                    { new Guid("25ca7696-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "pajas@sbcglobal.net", "AQAAAAEAACcQAAAAEF+V5vLhclRXxzC7V7RsEmX+ZppXOJVsAWSkHUjzRHHRHadKecizlJOUYCMfFuoa2w==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8757), "AQAAAAEAACcQAAAAEG741f/9nNEEmhjsGuZEMjB9hRSquno0e19ouCkrRc8OeZqzvwm+Qg22VKnP1kilJA==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "pajas" },
                    { new Guid("25ca8320-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "dwheeler@icloud.com", "AQAAAAEAACcQAAAAEApkFXBuwBIacTy5sc1doviy1Tu4GEsStGjmn7JlbrsRAzt6tFiX2KqECASl7T9rfw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8818), "AQAAAAEAACcQAAAAENVt5rU6V7O6kcENgL72ZC4ZkleBcS0ASt1hE057vt5T752WE8rKQNFr22DXAlZ80Q==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "dwheeler" },
                    { new Guid("25ca7448-72d4-11ec-90d6-0242ac120003"), new Guid("372a7671-ab69-4450-b77f-306aeb4eb8f1"), "rcwil@att.net", "AQAAAAEAACcQAAAAEPFtngb5JKxmgauIVoVzvRcq5S0M+/tqUHyhs2aGzwN3D1cTTr9PC1Pe6emTmoiZKw==", new DateTime(2022, 1, 11, 19, 15, 48, 876, DateTimeKind.Local).AddTicks(8751), "AQAAAAEAACcQAAAAEIzmIf8woR/vnYUEmNCJgl7ZbHpBCPlxQPdvjOEQSxQhuiJivX71QPZMH7WsWUCmqQ==", new Guid("5e1e640d-17cc-4d36-8e50-81deaeb6b215"), "rcwil" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7448-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7696-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca77e0-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7920-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7a4c-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7d44-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7e8e-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca7fa6-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca80d2-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca81f4-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8320-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8442-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca856e-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca896a-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8aa0-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8bcc-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8cf8-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8e24-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca8f32-72d4-11ec-90d6-0242ac120003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("25ca9040-72d4-11ec-90d6-0242ac120003"));

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
    }
}
