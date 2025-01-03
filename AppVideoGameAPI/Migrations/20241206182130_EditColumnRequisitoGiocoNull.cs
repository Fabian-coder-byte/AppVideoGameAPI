using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditColumnRequisitoGiocoNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CaratteristicaTecnicaId",
                table: "VideoGiochi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "30fec306-9c52-4e21-8127-4387adfab5f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "b502993b-9e9b-4226-8921-e72da2befca1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30fec306-9c52-4e21-8127-4387adfab5f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b502993b-9e9b-4226-8921-e72da2befca1");

            migrationBuilder.AlterColumn<int>(
                name: "CaratteristicaTecnicaId",
                table: "VideoGiochi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "bd60e955-e234-4b3c-a382-6dc99538b3cf", 0, false, "Sartini", "dd842e55-be76-4a6d-9555-f391106a4153", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEO+NywULePtDR6EUIAN+oQaUw4VkD0GHEmi46dnYvTwSQVPh3DimNi17wUsU4Om9tQ==", null, false, 200.0, "475b914c-ee9b-4d9c-8739-a9776dd85c48", false, null, "fabiansartini@gmail.com" },
                    { "da853b42-13a8-41a7-8334-cd43420c23b6", 0, false, "Sartini", "12e430b2-5032-4d32-865e-b12326f8ad27", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAELOInxfSKWKvf++eVPc35Y+CYuud4dMDLtWeDIILDRL2bk7kGrHWuzF3/Z92yPmMBg==", null, false, 300.0, "cb17dc7f-e4f1-4b3d-b163-304da08dc3c6", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "bd60e955-e234-4b3c-a382-6dc99538b3cf" },
                    { "1", "da853b42-13a8-41a7-8334-cd43420c23b6" }
                });
        }
    }
}
