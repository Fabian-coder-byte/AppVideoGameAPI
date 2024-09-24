using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class RelazioneAllegato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "6995444a-8e66-4b09-a2cd-4a6c35b94f43" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "9764771f-51b1-4983-b31e-d9eb448e2f1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6995444a-8e66-4b09-a2cd-4a6c35b94f43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9764771f-51b1-4983-b31e-d9eb448e2f1b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "7c7edaf5-ff5b-4475-ad62-12bd7b6d77d0", 0, "Sartini", "e72dd7c1-9f47-4d43-b215-5b912fa4dd8f", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAENlLDocLzaRDDtuPAP73SXKqHM1Bz+EsEtpICDbKT50EzNDB7FDPnTBIHBgEBJYBfg==", null, false, "175306a5-c7fc-40b6-b91e-735a503a28f5", false, null, "spaceplayer98@gmail.com" },
                    { "bdee13a5-d83c-4c76-898d-bffbe3cf1524", 0, "Sartini", "0fe78a4d-a65e-49d8-bca6-6029923ed8ff", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEO3k/8eOd20iRTn8CCmSCifncvC8NBurXGoBieH4uzLoJG6Uh6kyuD0NNNx+u9j+EA==", null, false, "5f26163e-9cf8-4c58-ab33-a952ce177253", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "7c7edaf5-ff5b-4475-ad62-12bd7b6d77d0" },
                    { "2", "bdee13a5-d83c-4c76-898d-bffbe3cf1524" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7c7edaf5-ff5b-4475-ad62-12bd7b6d77d0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "bdee13a5-d83c-4c76-898d-bffbe3cf1524" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c7edaf5-ff5b-4475-ad62-12bd7b6d77d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee13a5-d83c-4c76-898d-bffbe3cf1524");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "6995444a-8e66-4b09-a2cd-4a6c35b94f43", 0, "Sartini", "5746aabc-bd78-4b6f-80dd-b5923bd91d26", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEIsj96YbY26RWOQhMYTDxqs/1sJVnEfuexXQhUddwGCfx6kZbDdtVqaRUfZV0Us66A==", null, false, "c81533e3-405f-4274-ae7a-be2d75465757", false, null, "spaceplayer98@gmail.com" },
                    { "9764771f-51b1-4983-b31e-d9eb448e2f1b", 0, "Sartini", "733d74f4-2500-45be-9815-78d44dbdbf5b", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEODM/G50kCBcU1OqXJEfmUT1Jatzxk5bAkUCuSNYxT5O6abbYMoCcZOZzJd7ZgEegw==", null, false, "800e1b0a-6b08-4848-b6d3-ca3243315da5", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "6995444a-8e66-4b09-a2cd-4a6c35b94f43" },
                    { "2", "9764771f-51b1-4983-b31e-d9eb448e2f1b" }
                });
        }
    }
}
