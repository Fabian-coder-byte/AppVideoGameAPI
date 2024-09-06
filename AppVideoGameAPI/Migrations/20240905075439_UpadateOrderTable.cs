using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpadateOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Ordini",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "AllegatoVideoGioco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VideoGiocoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegatoVideoGioco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllegatoVideoGioco_VideoGiochi_VideoGiocoId",
                        column: x => x.VideoGiocoId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AllegatoVideoGioco_VideoGiocoId",
                table: "AllegatoVideoGioco",
                column: "VideoGiocoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllegatoVideoGioco");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Ordini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
