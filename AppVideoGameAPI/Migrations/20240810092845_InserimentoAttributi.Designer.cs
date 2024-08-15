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
    [Migration("20240810092845_InserimentoAttributi")]
    partial class InserimentoAttributi
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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                            Id = "0a699396-aa09-47b6-ab31-2192633139d0",
                            AccessFailedCount = 0,
                            Cognome = "Sartini",
                            ConcurrencyStamp = "5c204f41-b192-4c8d-9a2d-549e24787ccb",
                            Email = "fabiansartini@gmail.com",
                            EmailConfirmed = true,
                            IndirizzoUtente = "Via Pragelato 20",
                            LockoutEnabled = false,
                            Nome = "Fabian",
                            NormalizedEmail = "FABIANSARTINI@GMAIL.COM",
                            NormalizedUserName = "FABIANSARTINI@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEDZenxzzbh9xxKb8PirCE7JIzSXwT6+cDIKSkyV7LwoeJVa+zioGDDsyMX8yxhv0HA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "741a24d3-d8d0-4855-b830-6929dda76adc",
                            TwoFactorEnabled = false,
                            UserName = "fabiansartini@gmail.com"
                        },
                        new
                        {
                            Id = "251efda0-4a69-49e9-8efd-2ab35ad55374",
                            AccessFailedCount = 0,
                            Cognome = "Sartini",
                            ConcurrencyStamp = "6be8804b-5cf4-4084-a608-32f1286f99a1",
                            Email = "spaceplayer98@gmail.com",
                            EmailConfirmed = true,
                            IndirizzoUtente = "Via Russo 238",
                            LockoutEnabled = false,
                            Nome = "Fabian",
                            NormalizedEmail = "SPACEPLAYER98@GMAIL.COM",
                            NormalizedUserName = "SPACEPLAYER98@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGGMqsMmfjv90Cj2Onq/btsNjbIOZB9VVlQAfechMAXav8/WhYZqs7kKe0V30nrKMg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "87229948-5a46-4cdf-9b23-c9fcf52b9adc",
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

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
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

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
                        .HasMaxLength(450)
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
                        .HasMaxLength(450)
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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LivelloRichiestoId")
                        .HasColumnType("int");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Processore")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SchedaGrafica")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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
                            UserId = "0a699396-aa09-47b6-ab31-2192633139d0",
                            RoleId = "2"
                        },
                        new
                        {
                            UserId = "251efda0-4a69-49e9-8efd-2ab35ad55374",
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
