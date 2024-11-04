using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "1", "676e7dd8-7527-4727-a8ee-710306429427" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2", "ca15ad04-2ce1-4dc6-b19f-12798c1bf089" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "676e7dd8-7527-4727-a8ee-710306429427");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "ca15ad04-2ce1-4dc6-b19f-12798c1bf089");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminato",
                table: "MetodoPagamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
            //    values: new object[,]
            //    {
            //        { "bd60e955-e234-4b3c-a382-6dc99538b3cf", 0, false, "Sartini", "dd842e55-be76-4a6d-9555-f391106a4153", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEO+NywULePtDR6EUIAN+oQaUw4VkD0GHEmi46dnYvTwSQVPh3DimNi17wUsU4Om9tQ==", null, false, 200.0, "475b914c-ee9b-4d9c-8739-a9776dd85c48", false, null, "fabiansartini@gmail.com" },
            //        { "da853b42-13a8-41a7-8334-cd43420c23b6", 0, false, "Sartini", "12e430b2-5032-4d32-865e-b12326f8ad27", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAELOInxfSKWKvf++eVPc35Y+CYuud4dMDLtWeDIILDRL2bk7kGrHWuzF3/Z92yPmMBg==", null, false, 300.0, "cb17dc7f-e4f1-4b3d-b163-304da08dc3c6", false, null, "spaceplayer98@gmail.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "2", "bd60e955-e234-4b3c-a382-6dc99538b3cf" },
            //        { "1", "da853b42-13a8-41a7-8334-cd43420c23b6" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "bd60e955-e234-4b3c-a382-6dc99538b3cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "da853b42-13a8-41a7-8334-cd43420c23b6" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd60e955-e234-4b3c-a382-6dc99538b3cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da853b42-13a8-41a7-8334-cd43420c23b6");

            migrationBuilder.DropColumn(
                name: "Eliminato",
                table: "MetodoPagamento");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "676e7dd8-7527-4727-a8ee-710306429427", 0, false, "Sartini", "f2d3af74-1dac-40c3-93e2-9b1cc508f386", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEKXP5ITDLbAHxzN2qmm3+6XK0eurrhLvloMhCyfZpca2Wxl2GP53cTM/ouWrnHF01A==", null, false, 300.0, "f0d3b086-1703-4985-8103-e878f687b576", false, null, "spaceplayer98@gmail.com" },
                    { "ca15ad04-2ce1-4dc6-b19f-12798c1bf089", 0, false, "Sartini", "9d46edd5-3f23-4c8c-990d-9fc6ae08c23c", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEM7xXYjFEMk/NhuKjRsFjbyNh4fyTd1+svnhgI/nW9LB5o5y0EdUD2EP0851R/6rGg==", null, false, 200.0, "fe15309b-0721-4f99-9176-4c0257f61b48", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "676e7dd8-7527-4727-a8ee-710306429427" },
                    { "2", "ca15ad04-2ce1-4dc6-b19f-12798c1bf089" }
                });
        }
    }
}
