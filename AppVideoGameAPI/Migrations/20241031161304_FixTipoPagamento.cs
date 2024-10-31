using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixTipoPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "22e43cf4-58ed-4e29-af3f-0f334113fc5b" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "9ab5de7f-df7e-40dd-adaa-22a085c70ce3" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "22e43cf4-58ed-4e29-af3f-0f334113fc5b");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "9ab5de7f-df7e-40dd-adaa-22a085c70ce3");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "2ea85bd0-5388-474a-83cc-cd7e924933ba", 0, false, "Sartini", "6c12fbd0-7742-4b91-8f6f-d06908ee4057", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAENHT3z/BguZGK+MyRKr+JN516N4EHFNRIEXAaIeNO3O15HCgxj+/3EQTmXZe7R8/8w==", null, false, 200.0, "f22a52e5-953f-40be-8aa6-396f8c0ce0fc", false, null, "fabiansartini@gmail.com" },
            //        { "4eaf52d9-8013-4295-854b-c673fb128f91", 0, false, "Sartini", "82c4ca78-bf69-4ae6-92f8-b99103394f8f", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEIyz/FYtpQIriFYSmSFvAyTErou5cXjjkfZGJhUH3n3wGJyJhojt3OgPDYNhqcm5vg==", null, false, 300.0, "158a88c9-7ed1-43b9-b249-963e435d898d", false, null, "spaceplayer98@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "2", "2ea85bd0-5388-474a-83cc-cd7e924933ba" },
            //        { "1", "4eaf52d9-8013-4295-854b-c673fb128f91" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2ea85bd0-5388-474a-83cc-cd7e924933ba" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4eaf52d9-8013-4295-854b-c673fb128f91" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ea85bd0-5388-474a-83cc-cd7e924933ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4eaf52d9-8013-4295-854b-c673fb128f91");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "22e43cf4-58ed-4e29-af3f-0f334113fc5b", 0, false, "Sartini", "dc06ef70-394d-4e22-96d4-91a6aa4b4b55", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAECEgOhJ3k0LcMiLKhGfrZ35iB3Rz5ktiMX4uewloXBYix1c9InbIkDySgMXtpvNudw==", null, false, 300.0, "3cc925e5-3350-48ce-9c7a-c1accb22c50d", false, null, "spaceplayer98@gmail.com" },
                    { "9ab5de7f-df7e-40dd-adaa-22a085c70ce3", 0, false, "Sartini", "21e247b9-bbe6-4268-a445-e35216f3d155", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEO/2r2DE3D/i0f/5FRf4/D+S+2xWyMgFYGQfoQtTGyUzqOjRa/It3Oz81j7EOXci3w==", null, false, 200.0, "623fd5ad-c233-44a4-b222-1af4653491fe", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "22e43cf4-58ed-4e29-af3f-0f334113fc5b" },
                    { "2", "9ab5de7f-df7e-40dd-adaa-22a085c70ce3" }
                });
        }
    }
}
