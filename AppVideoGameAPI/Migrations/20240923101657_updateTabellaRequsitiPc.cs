using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateTabellaRequsitiPc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "7c7edaf5-ff5b-4475-ad62-12bd7b6d77d0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdee13a5-d83c-4c76-898d-bffbe3cf1524");

            migrationBuilder.RenameColumn(
                name: "SchedaGrafica",
                table: "RequisitiPCs",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "RAM",
                table: "RequisitiPCs",
                newName: "Processor");

            migrationBuilder.RenameColumn(
                name: "Processore",
                table: "RequisitiPCs",
                newName: "Memory");

            migrationBuilder.RenameColumn(
                name: "Audio",
                table: "RequisitiPCs",
                newName: "DirectX");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalNotes",
                table: "RequisitiPCs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalNotes",
                table: "RequisitiPCs");

            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "RequisitiPCs",
                newName: "SchedaGrafica");

            migrationBuilder.RenameColumn(
                name: "Processor",
                table: "RequisitiPCs",
                newName: "RAM");

            migrationBuilder.RenameColumn(
                name: "Memory",
                table: "RequisitiPCs",
                newName: "Processore");

            migrationBuilder.RenameColumn(
                name: "DirectX",
                table: "RequisitiPCs",
                newName: "Audio");

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
    }
}
