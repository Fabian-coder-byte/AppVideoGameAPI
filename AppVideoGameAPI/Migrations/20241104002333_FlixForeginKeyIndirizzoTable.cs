using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class FlixForeginKeyIndirizzoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndirizzoResidenza_AspNetUsers_DataUserId",
                table: "IndirizzoResidenza");

            migrationBuilder.DropIndex(
                name: "IX_IndirizzoResidenza_DataUserId",
                table: "IndirizzoResidenza");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "975ab10c-9e65-4cbc-9821-ee653781cb3e" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "b020d857-3be7-496e-b316-3a5643fb324f" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "975ab10c-9e65-4cbc-9821-ee653781cb3e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "b020d857-3be7-496e-b316-3a5643fb324f");

            migrationBuilder.DropColumn(
                name: "DataUserId",
                table: "IndirizzoResidenza");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "IndirizzoResidenza",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "01997dbe-69a7-4e63-bd5d-6b05dfc78724", 0, false, "Sartini", "02258fa4-9cb3-4af3-8a15-d4ba67aa9c41", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEJo2899ZcLXtu7CAeFc3j47n0IMlRqQocXVS64M1s67tKvNxcfcGXFzWGXA3QirAWQ==", null, false, 200.0, "e2203ce7-90ac-46ed-90a3-871c23b63226", false, null, "fabiansartini@gmail.com" },
            //        { "1d1e09cb-4a1b-461d-bc22-30a4051e91ce", 0, false, "Sartini", "ae0d1d9b-b00a-4ec9-b17e-7c38aa513ee2", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAECgL/h+13QrPgGxzU8XqG4PPDQdthj1MQZiWgbLl2GzTW+73637xHsZ4lTcmQnaBXw==", null, false, 300.0, "3966fedf-041c-43f0-922d-5a2a3bcddd78", false, null, "spaceplayer98@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "2", "01997dbe-69a7-4e63-bd5d-6b05dfc78724" },
            //        { "1", "1d1e09cb-4a1b-461d-bc22-30a4051e91ce" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_IndirizzoResidenza_UserId",
                table: "IndirizzoResidenza",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndirizzoResidenza_AspNetUsers_UserId",
                table: "IndirizzoResidenza",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndirizzoResidenza_AspNetUsers_UserId",
                table: "IndirizzoResidenza");

            migrationBuilder.DropIndex(
                name: "IX_IndirizzoResidenza_UserId",
                table: "IndirizzoResidenza");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "01997dbe-69a7-4e63-bd5d-6b05dfc78724" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1d1e09cb-4a1b-461d-bc22-30a4051e91ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01997dbe-69a7-4e63-bd5d-6b05dfc78724");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d1e09cb-4a1b-461d-bc22-30a4051e91ce");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "IndirizzoResidenza",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "DataUserId",
                table: "IndirizzoResidenza",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "975ab10c-9e65-4cbc-9821-ee653781cb3e", 0, false, "Sartini", "8da7a0aa-f79a-4208-a0ab-09d72b8d268e", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEPsdm6m+wPQGJC3afBL5Hg9AWXOUIxgO4h+C1bRq+J8ZARp0Z74up8ot7VuDXU5EAA==", null, false, 200.0, "30ac5c9a-49bb-4391-be74-e72144ede291", false, null, "fabiansartini@gmail.com" },
                    { "b020d857-3be7-496e-b316-3a5643fb324f", 0, false, "Sartini", "f36c06e6-80b0-4ba3-9646-65d1a93580f3", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEFnhEUaKbK45slparuHQzqkAtiwYDnl8Gkgn8fx86BuD3FxQADYbKL447nCRmOGQCg==", null, false, 300.0, "82fa8512-e7ea-4ff1-af6b-d82cc3c3008a", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "975ab10c-9e65-4cbc-9821-ee653781cb3e" },
                    { "1", "b020d857-3be7-496e-b316-3a5643fb324f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndirizzoResidenza_DataUserId",
                table: "IndirizzoResidenza",
                column: "DataUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_IndirizzoResidenza_AspNetUsers_DataUserId",
                table: "IndirizzoResidenza",
                column: "DataUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
