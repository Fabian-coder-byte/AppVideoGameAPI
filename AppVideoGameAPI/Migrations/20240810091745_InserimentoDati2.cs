using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class InserimentoDati2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9aeca00b-ab93-480e-9b9f-5babf2324102");

            migrationBuilder.DropColumn(
                name: "CPU",
                table: "RequisitiPCs");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "efe1b027-6d6c-437a-b070-57c78da7c279", 0, "Sartini", "50aa9e08-edad-48e6-bbec-ede1f0288ed7", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEE81Qdm04WmirU2KMhSWejDjBy4wPuFLDHn2yuVNiqqGeXP0Dlv4UaUETbPoMeA6Hg==", null, false, "597f980c-46ac-49d5-8091-578b22d9cae0", false, null, "spaceplayer98@gmail.com" },
                    { "f69758c2-0481-400b-8464-3627f4a5839e", 0, "Sartini", "5521c1e4-8a39-4024-8a6a-76f3fc231f0f", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEOUR5+IURN7b7O0nSlzP/iW9gAGNaiPTVm1bNPd2g3dccN/9J0FzDWVBA5GFb3NuTg==", null, false, "d541451e-833c-43b4-86d8-cad330be94b2", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CaseProduttrici",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Naughty Dogs" });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Xbox 360" },
                    { 2, "PlayStation 4" },
                    { 3, "PC" },
                    { 4, "Nintendo" }
                });

            migrationBuilder.InsertData(
                table: "Formati",
                columns: new[] { "Id", "Descrizione", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Codice Digitale" },
                    { 2, null, "DVD" }
                });

            migrationBuilder.InsertData(
                table: "Generi",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Sparatutto" },
                    { 2, "Horror" },
                    { 3, "Avventura" }
                });

            migrationBuilder.InsertData(
                table: "LivelliRichiestiPC",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "Minimo" }
                });

            migrationBuilder.InsertData(
                table: "VideoGiochi",
                columns: new[] { "Id", "CasaProduttriceId", "DataRilascio", "Descrizione", "Nome" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2020, 5, 12), null, "Ratchet e Clank " },
                    { 2, 4, new DateOnly(2020, 5, 12), null, "Gears of War" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "efe1b027-6d6c-437a-b070-57c78da7c279" },
                    { "2", "f69758c2-0481-400b-8464-3627f4a5839e" }
                });

            migrationBuilder.InsertData(
                table: "Funzionalitas",
                columns: new[] { "Id", "Descrizione", "Nome", "VideoGiocoId" },
                values: new object[,]
                {
                    { 1, null, "Giocatore Singolo", 2 },
                    { 2, null, "Co-Op", 1 }
                });

            migrationBuilder.InsertData(
                table: "VideoGiochi",
                columns: new[] { "Id", "CasaProduttriceId", "DataRilascio", "Descrizione", "Nome" },
                values: new object[] { 3, 5, new DateOnly(2020, 5, 12), null, "The Last of Us" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "efe1b027-6d6c-437a-b070-57c78da7c279" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "f69758c2-0481-400b-8464-3627f4a5839e" });

            migrationBuilder.DeleteData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Formati",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Formati",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funzionalitas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funzionalitas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LivelliRichiestiPC",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LivelliRichiestiPC",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efe1b027-6d6c-437a-b070-57c78da7c279");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f69758c2-0481-400b-8464-3627f4a5839e");

            migrationBuilder.DeleteData(
                table: "CaseProduttrici",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "CPU",
                table: "RequisitiPCs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "4d70d07d-b48d-4e09-95f5-da9acd4cc3fd", 0, "Sartini", "3ead14ae-5fe0-474c-9620-64da25094bc4", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEHa4uDaRQTByFxp4DTNxrBVVzcM793XrENeIrsaAUmUY9kRw1hNXOhguM+9GK92/vw==", null, false, "b6cbd5ae-96f9-4072-bf27-287673e0ae09", false, null, "spaceplayer98@gmail.com" },
                    { "9aeca00b-ab93-480e-9b9f-5babf2324102", 0, "Sartini", "3aaec84c-29ff-4a80-ae31-39ad5016aa0e", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEEjbSLD8IunEWp4cfOlkqTY1b8sRfjJdCWLHsGLKpDvyVwwgjvaJ8WKdP2y2p/TlEA==", null, false, "908313fb-fcf4-42d4-a0a2-c8bac420869b", false, null, "fabiansartini@gmail.com" }
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
    }
}
