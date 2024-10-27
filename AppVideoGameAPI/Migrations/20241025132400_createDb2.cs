using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class createDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "e896fe41-1823-4d0e-96cc-f473b1db1773" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f57ab10e-1410-4a11-b309-3d49e283d56a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e896fe41-1823-4d0e-96cc-f473b1db1773");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f57ab10e-1410-4a11-b309-3d49e283d56a");

            migrationBuilder.DropColumn(
                name: "Instatario",
                table: "MetodoPagamento");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "22e43cf4-58ed-4e29-af3f-0f334113fc5b", 0, false, "Sartini", "dc06ef70-394d-4e22-96d4-91a6aa4b4b55", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAECEgOhJ3k0LcMiLKhGfrZ35iB3Rz5ktiMX4uewloXBYix1c9InbIkDySgMXtpvNudw==", null, false, 300.0, "3cc925e5-3350-48ce-9c7a-c1accb22c50d", false, null, "spaceplayer98@gmail.com" },
                    { "9ab5de7f-df7e-40dd-adaa-22a085c70ce3", 0, false, "Sartini", "21e247b9-bbe6-4268-a445-e35216f3d155", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEO/2r2DE3D/i0f/5FRf4/D+S+2xWyMgFYGQfoQtTGyUzqOjRa/It3Oz81j7EOXci3w==", null, false, 200.0, "623fd5ad-c233-44a4-b222-1af4653491fe", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "TipoPagemento",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "Master Card" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "22e43cf4-58ed-4e29-af3f-0f334113fc5b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "9ab5de7f-df7e-40dd-adaa-22a085c70ce3" });

            migrationBuilder.DeleteData(
                table: "TipoPagemento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPagemento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22e43cf4-58ed-4e29-af3f-0f334113fc5b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ab5de7f-df7e-40dd-adaa-22a085c70ce3");

            migrationBuilder.AddColumn<string>(
                name: "Instatario",
                table: "MetodoPagamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "e896fe41-1823-4d0e-96cc-f473b1db1773", 0, false, "Sartini", "54020900-0fc1-4d5c-bbf2-debf79e4dad7", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEM8x0bvGJfA31pSR57f+Qhz36dqOUUkirIAs3AYlsrWxLpJ4643j7hjWO4dJKGw2BQ==", null, false, 200.0, "40085141-5b8c-4599-ac92-39c91e7a5c60", false, null, "fabiansartini@gmail.com" },
                    { "f57ab10e-1410-4a11-b309-3d49e283d56a", 0, false, "Sartini", "8b7fb0b6-f5fb-4951-a1cb-d70995031d9e", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAELZoP79LLoC05s4zWyXAIOAwu+rgz+Qmzf9/Kc9bWUpgv/8XqZ4e7xVG6xv71EAQWA==", null, false, 300.0, "12caa113-d0c9-4371-a698-10c4b682a9d1", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "e896fe41-1823-4d0e-96cc-f473b1db1773" },
                    { "1", "f57ab10e-1410-4a11-b309-3d49e283d56a" }
                });
        }
    }
}
