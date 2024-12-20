﻿using AppVideoGameAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppVideoGameAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<DataUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<CasaProduttrice> CaseProduttrici { get; set; }
        public DbSet<Models.Console> Consoles { get; set; }
        public DbSet<FormatoGioco> Formati { get; set; }
        public DbSet<Funzionalita> Funzionalitas { get; set; }
        public DbSet<Genere> Generi { get; set; }
        public DbSet<ItemOrdine> ItemOrdini { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Recensione> Recensioni { get; set; }
        public DbSet<StockVideoGioco> Stocks { get; set; }
        public DbSet<VideoGioco> VideoGiochi { get; set; }
        public DbSet<AllegatoUtente> AllegatiUtente { get; set; }
        public DbSet<AllegatoVideoGioco> AllegatiVideoGiochi { get; set; }
        public DbSet<AllegatoVideoGiocoStock> AllegatiVideoGiochiStocks { get; set; }
        public DbSet<Colore> Colori { get; set; }
        public DbSet<ModelloConsole> ModelliConsole { get; set; }
        public DbSet<StockConsole> StockConsoles { get; set; }
        public DbSet<CaratteristichaTecnica> CaratteristicheTecniche { get; set; }
        public DbSet<TipoAllegato> TipiAllegati { get; set; }
        public DbSet<IndirizzoResidenza> IndirizzoResidenza { get; set; }
        public DbSet<TipoPagamento> TipoPagemento { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamento { get; set; }
        public DbSet<CarrelloOrdine> CarrelloOrdini { get; set; }
        public DbSet<ItemCarrello> ItemsCarrello { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
              new IdentityRole { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
          );

            builder.Entity<TipoAllegato>().HasData(
             new TipoAllegato { Id = 1, Nome = "Foto Profilo" },
             new TipoAllegato { Id = 2, Nome = "Immagini Slider" },
             new TipoAllegato { Id = 3, Nome = "Video Trailer" },
             new TipoAllegato { Id = 4, Nome = "Documentazione Gioco" },
             new TipoAllegato { Id = 5, Nome = "Foto Gioco" }
             );
            DataUser Utente = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "fabiansartini@gmail.com",
                NormalizedUserName = "FABIANSARTINI@GMAIL.COM",
                Email = "fabiansartini@gmail.com",
                NormalizedEmail = "FABIANSARTINI@GMAIL.COM",
                EmailConfirmed = true,
                Nome = "Fabian",
                Cognome = "Sartini",
                SaldoDisponibile=200
            };
            PasswordHasher<DataUser> passwordHasherUtente = new PasswordHasher<DataUser>();
            Utente.PasswordHash = passwordHasherUtente.HashPassword(Utente, "Aa123!");
            builder.Entity<DataUser>().HasData(Utente);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = Utente.Id,
                    RoleId = "2"
                }
            );

            DataUser Admin = new DataUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "spaceplayer98@gmail.com",
                NormalizedUserName = "SPACEPLAYER98@GMAIL.COM",
                Email = "spaceplayer98@gmail.com",
                NormalizedEmail = "SPACEPLAYER98@GMAIL.COM",
                EmailConfirmed = true,
                Nome = "Fabian",
                Cognome = "Sartini",
                SaldoDisponibile=300
            };
            PasswordHasher<DataUser> passwordHasherAdmin = new PasswordHasher<DataUser>();
            Admin.PasswordHash = passwordHasherAdmin.HashPassword(Admin, "Aa123!");
            builder.Entity<DataUser>().HasData(Admin);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = Admin.Id,
                    RoleId = "1"
                }
            );
            builder.Entity<CasaProduttrice>().HasData(
                new CasaProduttrice { Id = 1, Nome = "Insomniac Games" },
                 new CasaProduttrice { Id = 2, Nome = "Sony" },
                 new CasaProduttrice { Id = 3, Nome = "Nintendo" },
                 new CasaProduttrice { Id = 4, Nome = "Microsoft" },
                  new CasaProduttrice { Id = 5, Nome = "Naughty Dogs" }
                );
            builder.Entity<Models.Console>().HasData(
                new Models.Console { Id = 1, Nome = "Xbox", },
                 new Models.Console { Id = 2, Nome = "PlayStation", },
                 new Models.Console { Id = 3, Nome = "PC" },
                 new Models.Console { Id = 4, Nome = "Nintendo" }
                );
            builder.Entity<Models.TipoPagamento>().HasData(
              new Models.TipoPagamento { Id = 1, Nome = "Visa" },
              new Models.TipoPagamento { Id = 2, Nome = "Master Card" }
             );
            builder.Entity<Models.ModelloConsole>().HasData(
              new Models.ModelloConsole { Id = 1, Nome = "Xbox 360",ConsoleId=1 },
              new Models.ModelloConsole { Id = 2, Nome = "PlayStation 4", ConsoleId = 2 },
              new Models.ModelloConsole { Id = 3, Nome = "PlayStation 5", ConsoleId = 2 },
              new Models.ModelloConsole { Id = 4, Nome = "PlayStation 3", ConsoleId = 2 },
              new Models.ModelloConsole { Id = 5, Nome = "Kata GF66", ConsoleId = 3 }
              );
            builder.Entity<FormatoGioco>().HasData(
               new FormatoGioco { Id = 1, Nome = "Codice Digitale" },
                new FormatoGioco { Id = 2, Nome = "DVD" }
               );
            builder.Entity<Funzionalita>().HasData(
              new Funzionalita { Id = 1, Nome = "Giocatore Singolo", VideoGiocoId = 2 },
               new Funzionalita { Id = 2, Nome = "Co-Op", VideoGiocoId = 1 }
              );
            builder.Entity<Genere>().HasData(
             new Genere { Id = 1, Nome = "Sparatutto", },
              new Genere { Id = 2, Nome = "Horror" },
              new Genere { Id = 3, Nome = "Avventura" }
             );

            builder.Entity<Colore>().HasData(
           new Colore { Id = 1, CodiceColore = "#ffffff" },
           new Colore { Id = 2, CodiceColore = "#000000" }
           );

            builder.Entity<CaratteristichaTecnica>().HasData(
           new CaratteristichaTecnica { Id = 1, CPU = "i7", GPU = "GeForce 3050", Memoria = "16Gb", SchedaArchiviazione = "1024" }
           );
            builder.Entity<VideoGioco>().HasData(
           new VideoGioco { Id = 1, Nome = "Ratchet e Clank ", CasaProduttriceId = 1, DataRilascio = new DateOnly(2020, 05, 12), CaratteristicaTecnicaId = 1 },
           new VideoGioco { Id = 2, Nome = "Gears of War", CasaProduttriceId = 4, DataRilascio = new DateOnly(2020, 05, 12), CaratteristicaTecnicaId = 1 },
           new VideoGioco { Id = 3, Nome = "The Last of Us", CasaProduttriceId = 5, DataRilascio = new DateOnly(2020, 05, 12), CaratteristicaTecnicaId = 1 }
           );

        }
    }
}
