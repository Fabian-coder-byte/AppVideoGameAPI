using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateConsoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "83326a62-8e95-4032-a179-e906d35744ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "c4b38e66-b15e-44fd-b124-b3782b1df2e0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "83326a62-8e95-4032-a179-e906d35744ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4b38e66-b15e-44fd-b124-b3782b1df2e0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "83326a62-8e95-4032-a179-e906d35744ea", 0, "Sartini", "bdc5609e-4474-4513-a01f-922b82bc2437", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEHDSYji9dy7DIulBo6LMv4+gsko40grHJ+W5+VefPKx+hcqgxAOtQSZTdGPOxxoWpA==", null, false, "2ed7dedb-6d0e-481b-9b2b-503327364a38", false, null, "fabiansartini@gmail.com" },
                    { "c4b38e66-b15e-44fd-b124-b3782b1df2e0", 0, "Sartini", "937870f9-78c8-4655-9326-e5e014522954", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEGt7DuO4fVxGaIB9Wgfpt/TPaxUBLnBiIs3zMjfZLdqyzqSkKhLyI2wAUG2Z8Ciq6g==", null, false, "89542520-f8f7-4474-9a68-6d407129bc28", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "83326a62-8e95-4032-a179-e906d35744ea" },
                    { "1", "c4b38e66-b15e-44fd-b124-b3782b1df2e0" }
                });
        }
    }
}
