using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "0a699396-aa09-47b6-ab31-2192633139d0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "251efda0-4a69-49e9-8efd-2ab35ad55374" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a699396-aa09-47b6-ab31-2192633139d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "251efda0-4a69-49e9-8efd-2ab35ad55374");

            migrationBuilder.AddColumn<double>(
                name: "Prezzo",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "f451a2a5-1097-4ad3-b215-8d92ff1958d2", 0, "Sartini", "af65968b-8309-453d-80cf-b98e63b5bbc8", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEITHm+oGUyU3YSjTj34dUvqDkCn4h5kJULllHQFBAFQxLFUup7AkovBjSVPqadBr5w==", null, false, "824eec2f-5d56-4860-86a2-3a41ec268d62", false, null, "spaceplayer98@gmail.com" },
                    { "f94fecbf-0e21-4c72-b957-8e904a6db696", 0, "Sartini", "2f612269-4a28-4cda-b21f-91de278236e8", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEAN1/AseKLR9ztXjIh4No56eklJpgrCpOW4nEn8RB9WBnduJwdmUODOtzEYHgQ4AwQ==", null, false, "8f6cd979-9f98-4465-8622-13928c25c2b4", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "f451a2a5-1097-4ad3-b215-8d92ff1958d2" },
                    { "2", "f94fecbf-0e21-4c72-b957-8e904a6db696" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f451a2a5-1097-4ad3-b215-8d92ff1958d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "f94fecbf-0e21-4c72-b957-8e904a6db696" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f451a2a5-1097-4ad3-b215-8d92ff1958d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94fecbf-0e21-4c72-b957-8e904a6db696");

            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Stocks");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "0a699396-aa09-47b6-ab31-2192633139d0", 0, "Sartini", "5c204f41-b192-4c8d-9a2d-549e24787ccb", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEDZenxzzbh9xxKb8PirCE7JIzSXwT6+cDIKSkyV7LwoeJVa+zioGDDsyMX8yxhv0HA==", null, false, "741a24d3-d8d0-4855-b830-6929dda76adc", false, null, "fabiansartini@gmail.com" },
                    { "251efda0-4a69-49e9-8efd-2ab35ad55374", 0, "Sartini", "6be8804b-5cf4-4084-a608-32f1286f99a1", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEGGMqsMmfjv90Cj2Onq/btsNjbIOZB9VVlQAfechMAXav8/WhYZqs7kKe0V30nrKMg==", null, false, "87229948-5a46-4cdf-9b23-c9fcf52b9adc", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "0a699396-aa09-47b6-ab31-2192633139d0" },
                    { "1", "251efda0-4a69-49e9-8efd-2ab35ad55374" }
                });
        }
    }
}
