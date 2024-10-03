using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateConsoleTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "c6c36be1-5fc6-4274-b459-c8832bd5acba" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "db4e80d6-846b-43d8-bd2a-19223a13acf0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6c36be1-5fc6-4274-b459-c8832bd5acba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db4e80d6-846b-43d8-bd2a-19223a13acf0");

            migrationBuilder.AlterColumn<int>(
                name: "ConsoleId",
                table: "ModelliConsole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "856eddc8-d6d9-46f2-8ee1-42796b55ebe5", 0, "Sartini", "3ed5d381-4299-4562-b7fd-2e749d9e8c33", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEAoc6z4oLYei36IwxCVqwuDslN6z7tyfk6typk2ky9NUP7wcK4Pi3qRtdXZoBAd7PA==", null, false, "1c8f7887-59cb-429e-bea9-5ad6b3a39cc2", false, null, "fabiansartini@gmail.com" },
                    { "a210dc57-9cf7-4419-8833-ea3011beb723", 0, "Sartini", "4c668b53-0aca-4e28-8777-5fe319b9e555", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEFNgvkNpCqVXcjhYwIf1t9lkbZdQV9KAlHiYReVLDU8y60XZM8QYfwPJ3n9M5hTRGQ==", null, false, "e84dddf9-1ef1-45a7-a9a0-9de6928fd0ba", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "856eddc8-d6d9-46f2-8ee1-42796b55ebe5" },
                    { "1", "a210dc57-9cf7-4419-8833-ea3011beb723" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "856eddc8-d6d9-46f2-8ee1-42796b55ebe5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a210dc57-9cf7-4419-8833-ea3011beb723" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "856eddc8-d6d9-46f2-8ee1-42796b55ebe5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a210dc57-9cf7-4419-8833-ea3011beb723");

            migrationBuilder.AlterColumn<int>(
                name: "ConsoleId",
                table: "ModelliConsole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "c6c36be1-5fc6-4274-b459-c8832bd5acba", 0, "Sartini", "2ebe633e-fb95-427e-9d84-cf38c5751ebb", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEDcrsjuMBRroS35puuJhzG0Us/yYtDf4Ptm7geLjE7eqrJ3ZfKhH05LHzkv7z0wNHg==", null, false, "ab21527c-fab1-4d52-9d21-fadd9250a6dd", false, null, "spaceplayer98@gmail.com" },
                    { "db4e80d6-846b-43d8-bd2a-19223a13acf0", 0, "Sartini", "b3b96a9d-0e69-4347-a5e8-3da10c45a7aa", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEPRt8MWoLritLMQ12QaKa6InvpcD7vuzSkpwCOXyZ8y7plOL9qgSlj8HN/1uLgYbLg==", null, false, "6f944fbe-c155-49c7-96c3-3e0fc463d08d", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "c6c36be1-5fc6-4274-b459-c8832bd5acba" },
                    { "2", "db4e80d6-846b-43d8-bd2a-19223a13acf0" }
                });
        }
    }
}
