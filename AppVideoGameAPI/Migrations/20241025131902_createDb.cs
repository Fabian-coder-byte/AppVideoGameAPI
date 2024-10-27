using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppVideoGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UltimoAccesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccettaUsoDati = table.Column<bool>(type: "bit", nullable: false),
                    SaldoDisponibile = table.Column<double>(type: "float", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaratteristicheTecniche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GPU = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Memoria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SchedaArchiviazione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaratteristicheTecniche", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseProduttrici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseProduttrici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceColore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipiAllegati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipiAllegati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagemento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrelloOrdini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrelloOrdini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrelloOrdini_AspNetUsers_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndirizzoResidenza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeIndirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCitta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirizzoResidenza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndirizzoResidenza_AspNetUsers_DataUserId",
                        column: x => x.DataUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoGiochi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataRilascio = table.Column<DateOnly>(type: "date", nullable: true),
                    CasaProduttriceId = table.Column<int>(type: "int", nullable: false),
                    CaratteristicaTecnicaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGiochi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGiochi_CaratteristicheTecniche_CaratteristicaTecnicaId",
                        column: x => x.CaratteristicaTecnicaId,
                        principalTable: "CaratteristicheTecniche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VideoGiochi_CaseProduttrici_CasaProduttriceId",
                        column: x => x.CasaProduttriceId,
                        principalTable: "CaseProduttrici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelliConsole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelliConsole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelliConsole_Consoles_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Consoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllegatiUtente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoAllegatoId = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AllegatiUtente_TipiAllegati_TipoAllegatoId",
                        column: x => x.TipoAllegatoId,
                        principalTable: "TipiAllegati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVC = table.Column<int>(type: "int", nullable: false),
                    Instatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataScadenza = table.Column<DateOnly>(type: "date", nullable: false),
                    TipoPagamentoId = table.Column<int>(type: "int", nullable: false),
                    SaldoDisponibile = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetodoPagamento_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetodoPagamento_TipoPagemento_TipoPagamentoId",
                        column: x => x.TipoPagamentoId,
                        principalTable: "TipoPagemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllegatiVideoGiochi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VideoGiocoId = table.Column<int>(type: "int", nullable: false),
                    TipoAllegatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegatiVideoGiochi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllegatiVideoGiochi_TipiAllegati_TipoAllegatoId",
                        column: x => x.TipoAllegatoId,
                        principalTable: "TipiAllegati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllegatiVideoGiochi_VideoGiochi_VideoGiocoId",
                        column: x => x.VideoGiocoId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funzionalitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoGiocoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funzionalitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funzionalitas_VideoGiochi_VideoGiocoId",
                        column: x => x.VideoGiocoId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GenereVideoGioco",
                columns: table => new
                {
                    GeneriId = table.Column<int>(type: "int", nullable: false),
                    VideoGiochiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenereVideoGioco", x => new { x.GeneriId, x.VideoGiochiId });
                    table.ForeignKey(
                        name: "FK_GenereVideoGioco_Generi_GeneriId",
                        column: x => x.GeneriId,
                        principalTable: "Generi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenereVideoGioco_VideoGiochi_VideoGiochiId",
                        column: x => x.VideoGiochiId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recensioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voto = table.Column<short>(type: "smallint", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoGiocoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recensioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recensioni_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recensioni_VideoGiochi_VideoGiocoId",
                        column: x => x.VideoGiocoId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoGiocoId = table.Column<int>(type: "int", nullable: false),
                    FormatoGiocoId = table.Column<int>(type: "int", nullable: false),
                    ConsoleId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<short>(type: "smallint", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Consoles_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Consoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Formati_FormatoGiocoId",
                        column: x => x.FormatoGiocoId,
                        principalTable: "Formati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_VideoGiochi_VideoGiocoId",
                        column: x => x.VideoGiocoId,
                        principalTable: "VideoGiochi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "StockConsoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelloConsoleId = table.Column<int>(type: "int", nullable: false),
                    ColoreId = table.Column<int>(type: "int", nullable: false),
                    CaratteristcaTecnicaId = table.Column<int>(type: "int", nullable: false),
                    CaratteristichaTecnicaId = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockConsoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockConsoles_CaratteristicheTecniche_CaratteristichaTecnicaId",
                        column: x => x.CaratteristichaTecnicaId,
                        principalTable: "CaratteristicheTecniche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockConsoles_Colori_ColoreId",
                        column: x => x.ColoreId,
                        principalTable: "Colori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockConsoles_ModelliConsole_ModelloConsoleId",
                        column: x => x.ModelloConsoleId,
                        principalTable: "ModelliConsole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UtenteId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    MetodoPagamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordini_AspNetUsers_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordini_MetodoPagamento_MetodoPagamentoId",
                        column: x => x.MetodoPagamentoId,
                        principalTable: "MetodoPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllegatiVideoGiochiStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VideoGiocoStockId = table.Column<int>(type: "int", nullable: false),
                    TipoAllegatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllegatiVideoGiochiStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllegatiVideoGiochiStocks_Stocks_VideoGiocoStockId",
                        column: x => x.VideoGiocoStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllegatiVideoGiochiStocks_TipiAllegati_TipoAllegatoId",
                        column: x => x.TipoAllegatoId,
                        principalTable: "TipiAllegati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementoProferito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    StockVideoGiocoId = table.Column<int>(type: "int", nullable: false),
                    DataInserimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoProferito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementoProferito_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementoProferito_Stocks_StockVideoGiocoId",
                        column: x => x.StockVideoGiocoId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCarrello",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<short>(type: "smallint", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    CarrelloId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCarrello", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsCarrello_CarrelloOrdini_CarrelloId",
                        column: x => x.CarrelloId,
                        principalTable: "CarrelloOrdini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsCarrello_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrdini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Quantita = table.Column<short>(type: "smallint", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    OrdineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrdini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrdini_Ordini_OrdineId",
                        column: x => x.OrdineId,
                        principalTable: "Ordini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemOrdini_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "Id", "AccessFailedCount", "AccettaUsoDati", "Cognome", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SaldoDisponibile", "SecurityStamp", "TwoFactorEnabled", "UltimoAccesso", "UserName" },
                values: new object[,]
                {
                    { "e896fe41-1823-4d0e-96cc-f473b1db1773", 0, false, "Sartini", "54020900-0fc1-4d5c-bbf2-debf79e4dad7", "fabiansartini@gmail.com", true, false, null, "Fabian", "FABIANSARTINI@GMAIL.COM", "FABIANSARTINI@GMAIL.COM", "AQAAAAIAAYagAAAAEM8x0bvGJfA31pSR57f+Qhz36dqOUUkirIAs3AYlsrWxLpJ4643j7hjWO4dJKGw2BQ==", null, false, 200.0, "40085141-5b8c-4599-ac92-39c91e7a5c60", false, null, "fabiansartini@gmail.com" },
                    { "f57ab10e-1410-4a11-b309-3d49e283d56a", 0, false, "Sartini", "8b7fb0b6-f5fb-4951-a1cb-d70995031d9e", "spaceplayer98@gmail.com", true, false, null, "Fabian", "SPACEPLAYER98@GMAIL.COM", "SPACEPLAYER98@GMAIL.COM", "AQAAAAIAAYagAAAAELZoP79LLoC05s4zWyXAIOAwu+rgz+Qmzf9/Kc9bWUpgv/8XqZ4e7xVG6xv71EAQWA==", null, false, 300.0, "12caa113-d0c9-4371-a698-10c4b682a9d1", false, null, "spaceplayer98@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "CaratteristicheTecniche",
                columns: new[] { "Id", "AdditionalNotes", "CPU", "GPU", "Memoria", "SchedaArchiviazione" },
                values: new object[] { 1, null, "i7", "GeForce 3050", "16Gb", "1024" });

            migrationBuilder.InsertData(
                table: "CaseProduttrici",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Insomniac Games" },
                    { 2, "Sony" },
                    { 3, "Nintendo" },
                    { 4, "Microsoft" },
                    { 5, "Naughty Dogs" }
                });

            migrationBuilder.InsertData(
                table: "Colori",
                columns: new[] { "Id", "CodiceColore" },
                values: new object[,]
                {
                    { 1, "#ffffff" },
                    { 2, "#000000" }
                });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Xbox" },
                    { 2, "PlayStation" },
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
                table: "TipiAllegati",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Foto Profilo" },
                    { 2, "Immagini Slider" },
                    { 3, "Video Trailer" },
                    { 4, "Documentazione Gioco" },
                    { 5, "Foto Gioco" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "e896fe41-1823-4d0e-96cc-f473b1db1773" },
                    { "1", "f57ab10e-1410-4a11-b309-3d49e283d56a" }
                });

            migrationBuilder.InsertData(
                table: "ModelliConsole",
                columns: new[] { "Id", "ConsoleId", "Nome" },
                values: new object[,]
                {
                    { 1, 1, "Xbox 360" },
                    { 2, 2, "PlayStation 4" },
                    { 3, 2, "PlayStation 5" },
                    { 4, 2, "PlayStation 3" },
                    { 5, 3, "Kata GF66" }
                });

            migrationBuilder.InsertData(
                table: "VideoGiochi",
                columns: new[] { "Id", "CaratteristicaTecnicaId", "CasaProduttriceId", "DataRilascio", "Descrizione", "Nome" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateOnly(2020, 5, 12), null, "Ratchet e Clank " },
                    { 2, 1, 4, new DateOnly(2020, 5, 12), null, "Gears of War" },
                    { 3, 1, 5, new DateOnly(2020, 5, 12), null, "The Last of Us" }
                });

            migrationBuilder.InsertData(
                table: "Funzionalitas",
                columns: new[] { "Id", "Descrizione", "Nome", "VideoGiocoId" },
                values: new object[,]
                {
                    { 1, null, "Giocatore Singolo", 2 },
                    { 2, null, "Co-Op", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiUtente_TipoAllegatoId",
                table: "AllegatiUtente",
                column: "TipoAllegatoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiUtente_UserId",
                table: "AllegatiUtente",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiVideoGiochi_TipoAllegatoId",
                table: "AllegatiVideoGiochi",
                column: "TipoAllegatoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiVideoGiochi_VideoGiocoId",
                table: "AllegatiVideoGiochi",
                column: "VideoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiVideoGiochiStocks_TipoAllegatoId",
                table: "AllegatiVideoGiochiStocks",
                column: "TipoAllegatoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllegatiVideoGiochiStocks_VideoGiocoStockId",
                table: "AllegatiVideoGiochiStocks",
                column: "VideoGiocoStockId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarrelloOrdini_UtenteId",
                table: "CarrelloOrdini",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoProferito_StockVideoGiocoId",
                table: "ElementoProferito",
                column: "StockVideoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoProferito_UserId",
                table: "ElementoProferito",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Funzionalitas_VideoGiocoId",
                table: "Funzionalitas",
                column: "VideoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_GenereVideoGioco_VideoGiochiId",
                table: "GenereVideoGioco",
                column: "VideoGiochiId");

            migrationBuilder.CreateIndex(
                name: "IX_IndirizzoResidenza_DataUserId",
                table: "IndirizzoResidenza",
                column: "DataUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdini_OrdineId",
                table: "ItemOrdini",
                column: "OrdineId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdini_StockId",
                table: "ItemOrdini",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrello_CarrelloId",
                table: "ItemsCarrello",
                column: "CarrelloId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrello_StockId",
                table: "ItemsCarrello",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagamento_TipoPagamentoId",
                table: "MetodoPagamento",
                column: "TipoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagamento_UserId",
                table: "MetodoPagamento",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelliConsole_ConsoleId",
                table: "ModelliConsole",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelloConsoleVideoGioco_VideoGiochiId",
                table: "ModelloConsoleVideoGioco",
                column: "VideoGiochiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_MetodoPagamentoId",
                table: "Ordini",
                column: "MetodoPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_UtenteId",
                table: "Ordini",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recensioni_UserId",
                table: "Recensioni",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recensioni_VideoGiocoId",
                table: "Recensioni",
                column: "VideoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_StockConsoles_CaratteristichaTecnicaId",
                table: "StockConsoles",
                column: "CaratteristichaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_StockConsoles_ColoreId",
                table: "StockConsoles",
                column: "ColoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StockConsoles_ModelloConsoleId",
                table: "StockConsoles",
                column: "ModelloConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ConsoleId",
                table: "Stocks",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_FormatoGiocoId",
                table: "Stocks",
                column: "FormatoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VideoGiocoId",
                table: "Stocks",
                column: "VideoGiocoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGiochi_CaratteristicaTecnicaId",
                table: "VideoGiochi",
                column: "CaratteristicaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGiochi_CasaProduttriceId",
                table: "VideoGiochi",
                column: "CasaProduttriceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllegatiUtente");

            migrationBuilder.DropTable(
                name: "AllegatiVideoGiochi");

            migrationBuilder.DropTable(
                name: "AllegatiVideoGiochiStocks");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ElementoProferito");

            migrationBuilder.DropTable(
                name: "Funzionalitas");

            migrationBuilder.DropTable(
                name: "GenereVideoGioco");

            migrationBuilder.DropTable(
                name: "IndirizzoResidenza");

            migrationBuilder.DropTable(
                name: "ItemOrdini");

            migrationBuilder.DropTable(
                name: "ItemsCarrello");

            migrationBuilder.DropTable(
                name: "ModelloConsoleVideoGioco");

            migrationBuilder.DropTable(
                name: "Recensioni");

            migrationBuilder.DropTable(
                name: "StockConsoles");

            migrationBuilder.DropTable(
                name: "TipiAllegati");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Generi");

            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "CarrelloOrdini");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Colori");

            migrationBuilder.DropTable(
                name: "ModelliConsole");

            migrationBuilder.DropTable(
                name: "MetodoPagamento");

            migrationBuilder.DropTable(
                name: "Formati");

            migrationBuilder.DropTable(
                name: "VideoGiochi");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipoPagemento");

            migrationBuilder.DropTable(
                name: "CaratteristicheTecniche");

            migrationBuilder.DropTable(
                name: "CaseProduttrici");
        }
    }
}
