using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstInsrimentoDati : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "7ab05ebd-702b-4a1a-9be0-5e15a51751de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "ffc0b503-32a5-41fb-851a-83e75da29ab1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ab05ebd-702b-4a1a-9be0-5e15a51751de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc0b503-32a5-41fb-851a-83e75da29ab1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd", 0, "Sartini", "3ead14ae-5fe0-474c-9620-64da25094bc4", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEHa4uDaRQTByFxp4DTNxrBVVzcM793XrENeIrsaAUmUY9kRw1hNXOhguM+9GK92/vw==", null, false, "b6cbd5ae-96f9-4072-bf27-287673e0ae09", false, null, "spaceplayer98@gmail.com" },
                    { "9aeca00b-ab93-480e-9b9f-5babf2324102", 0, "Sartini", "3aaec84c-29ff-4a80-ae31-39ad5016aa0e", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEEjbSLD8IunEWp4cfOlkqTY1b8sRfjJdCWLHsGLKpDvyVwwgjvaJ8WKdP2y2p/TlEA==", null, false, "908313fb-fcf4-42d4-a0a2-c8bac420869b", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CaseProduttrici",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Insomniac Games" },
                    { 2, "Sony" },
                    { 3, "Nintendo" },
                    { 4, "Microsoft" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd" },
                    { "2", "9aeca00b-ab93-480e-9b9f-5babf2324102" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "9aeca00b-ab93-480e-9b9f-5babf2324102" });

            migrationBuilder.DeleteData(
                table: "CaseProduttrici",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CaseProduttrici",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CaseProduttrici",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CaseProduttrici",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9aeca00b-ab93-480e-9b9f-5babf2324102");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "7ab05ebd-702b-4a1a-9be0-5e15a51751de", 0, "Sartini", "f218a6a6-cb81-4b3f-a18e-b0de66f21e49", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEMU8918byfNvAHBbST/xaQEiIXceCYSNG+1mPfOWkXafFubu7iNx0usvv2TYhu+J0Q==", null, false, "97035c5d-dfad-450b-8119-675a864be166", false, null, "fabiansartini@gmail.com" },
                    { "ffc0b503-32a5-41fb-851a-83e75da29ab1", 0, "Sartini", "aa801e3a-ddf6-4f25-b7a5-70b1eb04f500", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEIqaovZjN3WMrZW70De1i3HTFrWL+wo4KWHdSzYv8/250MBi2sRKIlY1AJDrrmeOpw==", null, false, "77140147-0a1a-4b27-8e17-50073892bd7e", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "7ab05ebd-702b-4a1a-9be0-5e15a51751de" },
                    { "1", "ffc0b503-32a5-41fb-851a-83e75da29ab1" }
                });
        }
    }
}
