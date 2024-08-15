﻿// <auto-generated />
using System;
using AppVideoGameAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppVideoGameAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240810091745_InserimentoDati2")]
    partial class InserimentoDati2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppVideoGameAPI.Models.CasaProduttrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CaseProduttrici");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Insomniac Games"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Sony"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Nintendo"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Microsoft"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Naughty Dogs"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Console", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Xbox 360"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "PlayStation 4"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "PC"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Nintendo"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.DataUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("IndirizzoUtente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UltimoAccesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f69758c2-0481-400b-8464-3627f4a5839e",
                            AccessFailedCount = 0,
                            Cognome = "Sartini",
                            ConcurrencyStamp = "5521c1e4-8a39-4024-8a6a-76f3fc231f0f",
                            Email = "fabiansartini@gmail.com",
                            EmailConfirmed = true,
                            IndirizzoUtente = "Via Pragelato 20",
                            LockoutEnabled = false,
                            Nome = "Fabian",
                            NormalizedEmail = "FABIANSARTINI@GMAIL.COM",
                            NormalizedUserName = "FABIANSARTINI@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOUR5+IURN7b7O0nSlzP/iW9gAGNaiPTVm1bNPd2g3dccN/9J0FzDWVBA5GFb3NuTg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d541451e-833c-43b4-86d8-cad330be94b2",
                            TwoFactorEnabled = false,
                            UserName = "fabiansartini@gmail.com"
                        },
                        new
                        {
                            Id = "efe1b027-6d6c-437a-b070-57c78da7c279",
                            AccessFailedCount = 0,
                            Cognome = "Sartini",
                            ConcurrencyStamp = "50aa9e08-edad-48e6-bbec-ede1f0288ed7",
                            Email = "spaceplayer98@gmail.com",
                            EmailConfirmed = true,
                            IndirizzoUtente = "Via Russo 238",
                            LockoutEnabled = false,
                            Nome = "Fabian",
                            NormalizedEmail = "SPACEPLAYER98@GMAIL.COM",
                            NormalizedUserName = "SPACEPLAYER98@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEE81Qdm04WmirU2KMhSWejDjBy4wPuFLDHn2yuVNiqqGeXP0Dlv4UaUETbPoMeA6Hg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "597f980c-46ac-49d5-8091-578b22d9cae0",
                            TwoFactorEnabled = false,
                            UserName = "spaceplayer98@gmail.com"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.FormatoGioco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formati");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Codice Digitale"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "DVD"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Funzionalita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoGiocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoGiocoId");

                    b.ToTable("Funzionalitas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Giocatore Singolo",
                            VideoGiocoId = 2
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Co-Op",
                            VideoGiocoId = 1
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Genere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Sparatutto"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Horror"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Avventura"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.ItemOrdine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrdineId")
                        .HasColumnType("int");

                    b.Property<short>("Quantita")
                        .HasColumnType("smallint");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdineId");

                    b.HasIndex("StockId");

                    b.ToTable("ItemOrdini");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.LivelloRichiestoPC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LivelliRichiestiPC");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Base"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Minimo"
                        });
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Ordine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("UtenteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UtenteId");

                    b.ToTable("Ordini");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Recensione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VideoGiocoId")
                        .HasColumnType("int");

                    b.Property<short>("Voto")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoGiocoId");

                    b.ToTable("Recensioni");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.RequisitiPC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Audio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LivelloRichiestoId")
                        .HasColumnType("int");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchedaGrafica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VideoGiocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivelloRichiestoId");

                    b.HasIndex("VideoGiocoId");

                    b.ToTable("RequisitiPCs");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsoleId")
                        .HasColumnType("int");

                    b.Property<int>("FormatoGiocoId")
                        .HasColumnType("int");

                    b.Property<short>("Quantita")
                        .HasColumnType("smallint");

                    b.Property<int>("VideoGiocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsoleId");

                    b.HasIndex("FormatoGiocoId");

                    b.HasIndex("VideoGiocoId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.VideoGioco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CasaProduttriceId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DataRilascio")
                        .HasColumnType("date");

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CasaProduttriceId");

                    b.ToTable("VideoGiochi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CasaProduttriceId = 1,
                            DataRilascio = new DateOnly(2020, 5, 12),
                            Nome = "Ratchet e Clank "
                        },
                        new
                        {
                            Id = 2,
                            CasaProduttriceId = 4,
                            DataRilascio = new DateOnly(2020, 5, 12),
                            Nome = "Gears of War"
                        },
                        new
                        {
                            Id = 3,
                            CasaProduttriceId = 5,
                            DataRilascio = new DateOnly(2020, 5, 12),
                            Nome = "The Last of Us"
                        });
                });

            modelBuilder.Entity("ConsoleVideoGioco", b =>
                {
                    b.Property<int>("ConsolesId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGiochiId")
                        .HasColumnType("int");

                    b.HasKey("ConsolesId", "VideoGiochiId");

                    b.HasIndex("VideoGiochiId");

                    b.ToTable("ConsoleVideoGioco");
                });

            modelBuilder.Entity("GenereVideoGioco", b =>
                {
                    b.Property<int>("GeneriId")
                        .HasColumnType("int");

                    b.Property<int>("VideoGiochiId")
                        .HasColumnType("int");

                    b.HasKey("GeneriId", "VideoGiochiId");

                    b.HasIndex("VideoGiochiId");

                    b.ToTable("GenereVideoGioco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "f69758c2-0481-400b-8464-3627f4a5839e",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "efe1b027-6d6c-437a-b070-57c78da7c279",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Funzionalita", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", "VideoGioco")
                        .WithMany("Funzionalitas")
                        .HasForeignKey("VideoGiocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("VideoGioco");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.ItemOrdine", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.Ordine", "Ordine")
                        .WithMany("ItemOrdini")
                        .HasForeignKey("OrdineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.Stock", "Stock")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ordine");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Ordine", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.DataUser", "DataUser")
                        .WithMany()
                        .HasForeignKey("UtenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DataUser");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Recensione", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.DataUser", "Utente")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", "VideoGioco")
                        .WithMany()
                        .HasForeignKey("VideoGiocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Utente");

                    b.Navigation("VideoGioco");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.RequisitiPC", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.LivelloRichiestoPC", "LivelloRichiesto")
                        .WithMany()
                        .HasForeignKey("LivelloRichiestoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", "VideoGioco")
                        .WithMany()
                        .HasForeignKey("VideoGiocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LivelloRichiesto");

                    b.Navigation("VideoGioco");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Stock", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.Console", "Console")
                        .WithMany()
                        .HasForeignKey("ConsoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.FormatoGioco", "Formato")
                        .WithMany()
                        .HasForeignKey("FormatoGiocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", "VideoGioco")
                        .WithMany()
                        .HasForeignKey("VideoGiocoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Console");

                    b.Navigation("Formato");

                    b.Navigation("VideoGioco");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.VideoGioco", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.CasaProduttrice", "CasaProduttrice")
                        .WithMany()
                        .HasForeignKey("CasaProduttriceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CasaProduttrice");
                });

            modelBuilder.Entity("ConsoleVideoGioco", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.Console", null)
                        .WithMany()
                        .HasForeignKey("ConsolesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", null)
                        .WithMany()
                        .HasForeignKey("VideoGiochiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GenereVideoGioco", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.Genere", null)
                        .WithMany()
                        .HasForeignKey("GeneriId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.VideoGioco", null)
                        .WithMany()
                        .HasForeignKey("VideoGiochiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.DataUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.DataUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppVideoGameAPI.Models.DataUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AppVideoGameAPI.Models.DataUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.Ordine", b =>
                {
                    b.Navigation("ItemOrdini");
                });

            modelBuilder.Entity("AppVideoGameAPI.Models.VideoGioco", b =>
                {
                    b.Navigation("Funzionalitas");
                });
#pragma warning restore 612, 618
        }
    }
}
