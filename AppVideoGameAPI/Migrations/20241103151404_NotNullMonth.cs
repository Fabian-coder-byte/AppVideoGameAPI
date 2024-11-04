using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class NotNullMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "2ea85bd0-5388-474a-83cc-cd7e924933ba" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "4eaf52d9-8013-4295-854b-c673fb128f91" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "2ea85bd0-5388-474a-83cc-cd7e924933ba");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "4eaf52d9-8013-4295-854b-c673fb128f91");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Ordini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "975ab10c-9e65-4cbc-9821-ee653781cb3e", 0, false, "Sartini", "8da7a0aa-f79a-4208-a0ab-09d72b8d268e", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEPsdm6m+wPQGJC3afBL5Hg9AWXOUIxgO4h+C1bRq+J8ZARp0Z74up8ot7VuDXU5EAA==", null, false, 200.0, "30ac5c9a-49bb-4391-be74-e72144ede291", false, null, "fabiansartini@gmail.com" },
            //        { "b020d857-3be7-496e-b316-3a5643fb324f", 0, false, "Sartini", "f36c06e6-80b0-4ba3-9646-65d1a93580f3", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEFnhEUaKbK45slparuHQzqkAtiwYDnl8Gkgn8fx86BuD3FxQADYbKL447nCRmOGQCg==", null, false, 300.0, "82fa8512-e7ea-4ff1-af6b-d82cc3c3008a", false, null, "spaceplayer98@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "2", "975ab10c-9e65-4cbc-9821-ee653781cb3e" },
            //        { "1", "b020d857-3be7-496e-b316-3a5643fb324f" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "975ab10c-9e65-4cbc-9821-ee653781cb3e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "b020d857-3be7-496e-b316-3a5643fb324f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "975ab10c-9e65-4cbc-9821-ee653781cb3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b020d857-3be7-496e-b316-3a5643fb324f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Ordini",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "2ea85bd0-5388-474a-83cc-cd7e924933ba", 0, false, "Sartini", "6c12fbd0-7742-4b91-8f6f-d06908ee4057", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAENHT3z/BguZGK+MyRKr+JN516N4EHFNRIEXAaIeNO3O15HCgxj+/3EQTmXZe7R8/8w==", null, false, 200.0, "f22a52e5-953f-40be-8aa6-396f8c0ce0fc", false, null, "fabiansartini@gmail.com" },
                    { "4eaf52d9-8013-4295-854b-c673fb128f91", 0, false, "Sartini", "82c4ca78-bf69-4ae6-92f8-b99103394f8f", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEIyz/FYtpQIriFYSmSFvAyTErou5cXjjkfZGJhUH3n3wGJyJhojt3OgPDYNhqcm5vg==", null, false, 300.0, "158a88c9-7ed1-43b9-b249-963e435d898d", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "2ea85bd0-5388-474a-83cc-cd7e924933ba" },
                    { "1", "4eaf52d9-8013-4295-854b-c673fb128f91" }
                });
        }
    }
}
