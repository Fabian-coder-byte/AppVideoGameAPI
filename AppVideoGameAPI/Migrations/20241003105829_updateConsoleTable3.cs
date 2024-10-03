using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateConsoleTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consoles_VideoGiochi_VideoGiocoId",
                table: "Consoles");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGiochi_ModelliConsole_ModelloConsoleId",
                table: "VideoGiochi");

            migrationBuilder.DropIndex(
                name: "IX_VideoGiochi_ModelloConsoleId",
                table: "VideoGiochi");

            migrationBuilder.DropIndex(
                name: "IX_Consoles_VideoGiocoId",
                table: "Consoles");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "856eddc8-d6d9-46f2-8ee1-42796b55ebe5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "a210dc57-9cf7-4419-8833-ea3011beb723" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "856eddc8-d6d9-46f2-8ee1-42796b55ebe5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a210dc57-9cf7-4419-8833-ea3011beb723");

            migrationBuilder.DropColumn(
                name: "ModelloConsoleId",
                table: "VideoGiochi");

            migrationBuilder.DropColumn(
                name: "VideoGiocoId",
                table: "Consoles");

            migrationBuilder.AlterColumn<int>(
                name: "ConsoleId",
                table: "ModelliConsole",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ModelloConsoleVideoGioco",
                columns: table => new
                {
                    ConsolesId = table.Column<int>(type: "int", nullable: false),
                    VideoGiochiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelloConsoleVideoGioco", x => new { x.ConsolesId, x.VideoGiochiId });
                    table.ForeignKey(
                        name: "FK_ModelloConsoleVideoGioco_ModelliConsole_ConsolesId",
                        column: x => x.ConsolesId,
                        principalTable: "ModelliConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelloConsoleVideoGioco_VideoGiochi_VideoGiochiId",
                        column: x => x.VideoGiochiId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "0a6f4744-ff67-4932-a400-c03fc8709a46", 0, "Sartini", "06e9ff06-4a14-4108-8a5c-a6b646c67f29", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEG6Lr/oaYGJvjctenCb8hGFh/8gjLZkTeTdlviTZRX+IUh2aN8iNWE+DK47N1R1EJw==", null, false, "280ba06b-5ddd-42af-97e2-d4b33bf3ec01", false, null, "spaceplayer98@gmail.com" },
                    { "0d251a2d-3bf7-4c8f-b037-40912e73ccda", 0, "Sartini", "151fe3cc-ee33-45a8-822d-1a2927ba1451", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEACG4qywv6L9V/LpFXgnjCNSWdnjphAQ7Sb8nhLgEGsLx6MrhIxK2RJkOz1XoN8Bcw==", null, false, "70b5a094-293d-4b1b-82b6-28bc141f1d7f", false, null, "fabiansartini@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "0a6f4744-ff67-4932-a400-c03fc8709a46" },
                    { "2", "0d251a2d-3bf7-4c8f-b037-40912e73ccda" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelloConsoleVideoGioco_VideoGiochiId",
                table: "ModelloConsoleVideoGioco",
                column: "VideoGiochiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelloConsoleVideoGioco");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0a6f4744-ff67-4932-a400-c03fc8709a46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "0d251a2d-3bf7-4c8f-b037-40912e73ccda" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a6f4744-ff67-4932-a400-c03fc8709a46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d251a2d-3bf7-4c8f-b037-40912e73ccda");

            migrationBuilder.AddColumn<int>(
                name: "ModelloConsoleId",
                table: "VideoGiochi",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConsoleId",
                table: "ModelliConsole",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VideoGiocoId",
                table: "Consoles",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "856eddc8-d6d9-46f2-8ee1-42796b55ebe5", 0, "Sartini", "3ed5d381-4299-4562-b7fd-2e749d9e8c33", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEAoc6z4oLYei36IwxCVqwuDslN6z7tyfk6typk2ky9NUP7wcK4Pi3qRtdXZoBAd7PA==", null, false, "1c8f7887-59cb-429e-bea9-5ad6b3a39cc2", false, null, "fabiansartini@gmail.com" },
                    { "a210dc57-9cf7-4419-8833-ea3011beb723", 0, "Sartini", "4c668b53-0aca-4e28-8777-5fe319b9e555", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEFNgvkNpCqVXcjhYwIf1t9lkbZdQV9KAlHiYReVLDU8y60XZM8QYfwPJ3n9M5hTRGQ==", null, false, "e84dddf9-1ef1-45a7-a9a0-9de6928fd0ba", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "VideoGiocoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "VideoGiocoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "VideoGiocoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Consoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "VideoGiocoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelloConsoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelloConsoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "VideoGiochi",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelloConsoleId",
                value: null);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "856eddc8-d6d9-46f2-8ee1-42796b55ebe5" },
                    { "1", "a210dc57-9cf7-4419-8833-ea3011beb723" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGiochi_ModelloConsoleId",
                table: "VideoGiochi",
                column: "ModelloConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_VideoGiocoId",
                table: "Consoles",
                column: "VideoGiocoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consoles_VideoGiochi_VideoGiocoId",
                table: "Consoles",
                column: "VideoGiocoId",
                principalTable: "VideoGiochi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGiochi_ModelliConsole_ModelloConsoleId",
                table: "VideoGiochi",
                column: "ModelloConsoleId",
                principalTable: "ModelliConsole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
