using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class IntestatarioCarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "01997dbe-69a7-4e63-bd5d-6b05dfc78724" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "1d1e09cb-4a1b-461d-bc22-30a4051e91ce" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "01997dbe-69a7-4e63-bd5d-6b05dfc78724");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "1d1e09cb-4a1b-461d-bc22-30a4051e91ce");

            migrationBuilder.AddColumn<string>(
                name: "Intestatario",
                table: "IndirizzoResidenza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "03b2001b-2849-4fa2-ab39-c1d6c31feb33", 0, false, "Sartini", "9d8afb99-1874-4a44-8e25-e503d6de7bbc", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEOPxBpWK/5XJX68kY/wJ7B5qTFnbY8ozyMKx6gQAPg9Q2bIErsawtgu1JQ0WpKNfxg==", null, false, 300.0, "604b1c07-4ebd-4d69-8ed6-47cabb8773ac", false, null, "spaceplayer98@gmail.com" },
            //        { "fd94746f-3b7f-44bf-a210-3a1f1a2b4552", 0, false, "Sartini", "73e9109e-a4b8-4f5c-8f22-87de81a1bc29", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEKZLmQ5c1wWsB5dwOAyDTiUH5uLkt/O8VDH3ofCEooPmOk3QhQao2qLF3bK9naC/xQ==", null, false, 200.0, "9ced6a7e-a009-42cf-942c-2201f7c47f9b", false, null, "fabiansartini@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "1", "03b2001b-2849-4fa2-ab39-c1d6c31feb33" },
            //        { "2", "fd94746f-3b7f-44bf-a210-3a1f1a2b4552" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "03b2001b-2849-4fa2-ab39-c1d6c31feb33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "fd94746f-3b7f-44bf-a210-3a1f1a2b4552" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03b2001b-2849-4fa2-ab39-c1d6c31feb33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd94746f-3b7f-44bf-a210-3a1f1a2b4552");

            migrationBuilder.DropColumn(
                name: "Intestatario",
                table: "IndirizzoResidenza");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "01997dbe-69a7-4e63-bd5d-6b05dfc78724", 0, false, "Sartini", "02258fa4-9cb3-4af3-8a15-d4ba67aa9c41", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEJo2899ZcLXtu7CAeFc3j47n0IMlRqQocXVS64M1s67tKvNxcfcGXFzWGXA3QirAWQ==", null, false, 200.0, "e2203ce7-90ac-46ed-90a3-871c23b63226", false, null, "fabiansartini@gmail.com" },
                    { "1d1e09cb-4a1b-461d-bc22-30a4051e91ce", 0, false, "Sartini", "ae0d1d9b-b00a-4ec9-b17e-7c38aa513ee2", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAECgL/h+13QrPgGxzU8XqG4PPDQdthj1MQZiWgbLl2GzTW+73637xHsZ4lTcmQnaBXw==", null, false, 300.0, "3966fedf-041c-43f0-922d-5a2a3bcddd78", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "01997dbe-69a7-4e63-bd5d-6b05dfc78724" },
                    { "1", "1d1e09cb-4a1b-461d-bc22-30a4051e91ce" }
                });
        }
    }
}
