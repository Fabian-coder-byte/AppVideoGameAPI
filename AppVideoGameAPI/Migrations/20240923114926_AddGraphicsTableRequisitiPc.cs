using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGraphicsTableRequisitiPc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Graphics",
                table: "RequisitiPCs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "af7f5235-8893-45e3-9e28-5de33098e980", 0, "Sartini", "0f6bf848-f41a-4b43-a488-cdac9856ec5d", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEOEJp9tKNn2J+oZDpQr95BUSjnK6467EwU3RyAik+tU7OZUb+x/Y2q8OMgUXEFDMug==", null, false, "e89eaac4-1a47-455d-9a2f-1bc9cc6ce64f", false, null, "spaceplayer98@gmail.com" },
                    { "b7a3f41e-5854-4644-9ce8-c953e3418919", 0, "Sartini", "35796993-e00d-4f64-a5b6-10f7b450dc7c", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEOoZbhH5nBcqZEWl5Ttxz60xAMJV9M/LLRw+bW37twwMQrSYgxpbnPc8CVdn5XlAig==", null, false, "073b1159-a423-4c55-a955-554b8c8c0123", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "af7f5235-8893-45e3-9e28-5de33098e980" },
                    { "2", "b7a3f41e-5854-4644-9ce8-c953e3418919" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "af7f5235-8893-45e3-9e28-5de33098e980" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "b7a3f41e-5854-4644-9ce8-c953e3418919" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af7f5235-8893-45e3-9e28-5de33098e980");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7a3f41e-5854-4644-9ce8-c953e3418919");

            migrationBuilder.DropColumn(
                name: "Graphics",
                table: "RequisitiPCs");
        }
    }
}
