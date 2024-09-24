using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class TabelleAllegati : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllegatoVideoGioco_VideoGiochi_VideoGiocoId",
                table: "AllegatoVideoGioco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllegatoVideoGioco",
                table: "AllegatoVideoGioco");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "5e6f6e11-d790-49d1-a4a7-47b1265ca28b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "cc784fd0-4eb3-4942-affe-80d584c8cc0b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e6f6e11-d790-49d1-a4a7-47b1265ca28b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc784fd0-4eb3-4942-affe-80d584c8cc0b");

            migrationBuilder.RenameTable(
                name: "AllegatoVideoGioco",
                newName: "AllegatiVideoGiochi");

            migrationBuilder.RenameIndex(
                name: "IX_AllegatoVideoGioco_VideoGiocoId",
                table: "AllegatiVideoGiochi",
                newName: "IX_AllegatiVideoGiochi_VideoGiocoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllegatiVideoGiochi",
                table: "AllegatiVideoGiochi",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllegatiUtente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegatiUtente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllegatiUtente_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiUtente_UserId",
                table: "AllegatiUtente",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllegatiVideoGiochi_VideoGiochi_VideoGiocoId",
                table: "AllegatiVideoGiochi",
                column: "VideoGiocoId",
                principalTable: "VideoGiochi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllegatiVideoGiochi_VideoGiochi_VideoGiocoId",
                table: "AllegatiVideoGiochi");

            migrationBuilder.DropTable(
                name: "AllegatiUtente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllegatiVideoGiochi",
                table: "AllegatiVideoGiochi");

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

            migrationBuilder.RenameTable(
                name: "AllegatiVideoGiochi",
                newName: "AllegatoVideoGioco");

            migrationBuilder.RenameIndex(
                name: "IX_AllegatiVideoGiochi_VideoGiocoId",
                table: "AllegatoVideoGioco",
                newName: "IX_AllegatoVideoGioco_VideoGiocoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllegatoVideoGioco",
                table: "AllegatoVideoGioco",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "IndirizzoUtente", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "5e6f6e11-d790-49d1-a4a7-47b1265ca28b", 0, "Sartini", "6dda13f8-eb01-4d8a-94eb-d0a9e37cc8ef", "fabiansartini@gmail.com", true, "Via Pragelato 20", false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEJc5OY/cKK14W/FjwlDgDCMCJKjKPjYQhgdB/TdT3aJepcRmXTsY2i4Ycf06LMEJ2w==", null, false, "9c314dd8-25ca-4cc6-9300-a99ba8b27475", false, null, "fabiansartini@gmail.com" },
                    { "cc784fd0-4eb3-4942-affe-80d584c8cc0b", 0, "Sartini", "ceb9e7de-b834-4557-be04-3d8e96e7f778", "spaceplayer98@gmail.com", true, "Via Russo 238", false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAEGqjFUGglGhSYG8tG1sD2GFPs0sFde0Win+eaRvPoOswABrMhfodm2jAtHl6i0DmtA==", null, false, "42f94b19-7c24-4d01-b1c3-d0e4994122a4", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "5e6f6e11-d790-49d1-a4a7-47b1265ca28b" },
                    { "1", "cc784fd0-4eb3-4942-affe-80d584c8cc0b" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AllegatoVideoGioco_VideoGiochi_VideoGiocoId",
                table: "AllegatoVideoGioco",
                column: "VideoGiocoId",
                principalTable: "VideoGiochi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
