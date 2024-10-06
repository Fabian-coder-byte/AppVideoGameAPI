using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class tabellaColori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0a6f4744-ff67-4932-a400-c03fc8709a46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "0d251a2d-3bf7-4c8f-b037-40912e73ccda" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a6f4744-ff67-4932-a400-c03fc8709a46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d251a2d-3bf7-4c8f-b037-40912e73ccda");

            migrationBuilder.RenameColumn(
                name: "NomeColore",
                table: "Colori",
                newName: "CodiceColore");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "a784d974-7562-4849-8b81-eca190e919fa", 0, "Sartini", "0552929e-7ee6-40fe-a0a6-031d57a6afb0", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEFGN3zdrqVxjkPM2Uw5OjlzsAjgd7D4ZL87FNhMkQJmHX1cYkTzuXmFv4OdikNzdiw==", null, false, "97d67e09-1ded-4f1f-a0fe-250f5defc6d3", false, null, "fabiansartini@gmail.com" },
                    { "df2b67f2-b0a9-4275-8487-ef8acc289f19", 0, "Sartini", "0e88aeff-bdd9-4659-a223-03b1f922ca9b", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAELfLYI/JUsc2DcBnGpjoXGLubQdsm4CSRD3KSZEirFnMvYmpjCxwuX8+67kJIcBtNg==", null, false, "93962991-82b5-4b4f-a1ca-2b319a03f1b0", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 1,
                column: "CodiceColore",
                value: "#fff");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 2,
                column: "CodiceColore",
                value: "#000");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 3,
                column: "CodiceColore",
                value: "#ffdd00");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 4,
                column: "CodiceColore",
                value: "#ddd");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "a784d974-7562-4849-8b81-eca190e919fa" },
                    { "1", "df2b67f2-b0a9-4275-8487-ef8acc289f19" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "a784d974-7562-4849-8b81-eca190e919fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "df2b67f2-b0a9-4275-8487-ef8acc289f19" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a784d974-7562-4849-8b81-eca190e919fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df2b67f2-b0a9-4275-8487-ef8acc289f19");

            migrationBuilder.RenameColumn(
                name: "CodiceColore",
                table: "Colori",
                newName: "NomeColore");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "0a6f4744-ff67-4932-a400-c03fc8709a46", 0, "Sartini", "06e9ff06-4a14-4108-8a5c-a6b646c67f29", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEG6Lr/oaYGJvjctenCb8hGFh/8gjLZkTeTdlviTZRX+IUh2aN8iNWE+DK47N1R1EJw==", null, false, "280ba06b-5ddd-42af-97e2-d4b33bf3ec01", false, null, "spaceplayer98@gmail.com" },
                    { "0d251a2d-3bf7-4c8f-b037-40912e73ccda", 0, "Sartini", "151fe3cc-ee33-45a8-822d-1a2927ba1451", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEACG4qywv6L9V/LpFXgnjCNSWdnjphAQ7Sb8nhLgEGsLx6MrhIxK2RJkOz1XoN8Bcw==", null, false, "70b5a094-293d-4b1b-82b6-28bc141f1d7f", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 1,
                column: "NomeColore",
                value: "Rosso");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 2,
                column: "NomeColore",
                value: "Giallo");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 3,
                column: "NomeColore",
                value: "Bianco");

            migrationBuilder.UpdateData(
                table: "Colori",
                keyColumn: "Id",
                keyValue: 4,
                column: "NomeColore",
                value: "Nero");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "0a6f4744-ff67-4932-a400-c03fc8709a46" },
                    { "2", "0d251a2d-3bf7-4c8f-b037-40912e73ccda" }
                });
        }
    }
}
