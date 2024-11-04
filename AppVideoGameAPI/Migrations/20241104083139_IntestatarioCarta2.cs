using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class IntestatarioCarta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "03b2001b-2849-4fa2-ab39-c1d6c31feb33" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "fd94746f-3b7f-44bf-a210-3a1f1a2b4552" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "03b2001b-2849-4fa2-ab39-c1d6c31feb33");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "fd94746f-3b7f-44bf-a210-3a1f1a2b4552");

            migrationBuilder.DropColumn(
                name: "Intestatario",
                table: "IndirizzoResidenza");

            migrationBuilder.AddColumn<string>(
                name: "Intestatario",
                table: "MetodoPagamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "676e7dd8-7527-4727-a8ee-710306429427", 0, false, "Sartini", "f2d3af74-1dac-40c3-93e2-9b1cc508f386", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEKXP5ITDLbAHxzN2qmm3+6XK0eurrhLvloMhCyfZpca2Wxl2GP53cTM/ouWrnHF01A==", null, false, 300.0, "f0d3b086-1703-4985-8103-e878f687b576", false, null, "spaceplayer98@gmail.com" },
            //        { "ca15ad04-2ce1-4dc6-b19f-12798c1bf089", 0, false, "Sartini", "9d46edd5-3f23-4c8c-990d-9fc6ae08c23c", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEM7xXYjFEMk/NhuKjRsFjbyNh4fyTd1+svnhgI/nW9LB5o5y0EdUD2EP0851R/6rGg==", null, false, 200.0, "fe15309b-0721-4f99-9176-4c0257f61b48", false, null, "fabiansartini@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "1", "676e7dd8-7527-4727-a8ee-710306429427" },
            //        { "2", "ca15ad04-2ce1-4dc6-b19f-12798c1bf089" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "676e7dd8-7527-4727-a8ee-710306429427" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "ca15ad04-2ce1-4dc6-b19f-12798c1bf089" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "676e7dd8-7527-4727-a8ee-710306429427");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca15ad04-2ce1-4dc6-b19f-12798c1bf089");

            migrationBuilder.DropColumn(
                name: "Intestatario",
                table: "MetodoPagamento");

            migrationBuilder.AddColumn<string>(
                name: "Intestatario",
                table: "IndirizzoResidenza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "03b2001b-2849-4fa2-ab39-c1d6c31feb33", 0, false, "Sartini", "9d8afb99-1874-4a44-8e25-e503d6de7bbc", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEOPxBpWK/5XJX68kY/wJ7B5qTFnbY8ozyMKx6gQAPg9Q2bIErsawtgu1JQ0WpKNfxg==", null, false, 300.0, "604b1c07-4ebd-4d69-8ed6-47cabb8773ac", false, null, "spaceplayer98@gmail.com" },
                    { "fd94746f-3b7f-44bf-a210-3a1f1a2b4552", 0, false, "Sartini", "73e9109e-a4b8-4f5c-8f22-87de81a1bc29", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEKZLmQ5c1wWsB5dwOAyDTiUH5uLkt/O8VDH3ofCEooPmOk3QhQao2qLF3bK9naC/xQ==", null, false, 200.0, "9ced6a7e-a009-42cf-942c-2201f7c47f9b", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "03b2001b-2849-4fa2-ab39-c1d6c31feb33" },
                    { "2", "fd94746f-3b7f-44bf-a210-3a1f1a2b4552" }
                });
        }
    }
}
