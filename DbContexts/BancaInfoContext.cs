using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BancaApi.DbContexts
{
    public class BancaInfoContext : DbContext
    {
        public BancaInfoContext(DbContextOptions<BancaInfoContext> options)
            : base(options)
        {
        }

        public DbSet<BancaEntity> Banche { get; set; }
        public DbSet<UtenteEntity> Utenti { get; set; }
        public DbSet<ContoEntity> Conti { get; set; }
        public DbSet<OperazioneEntity> Operazioni { get; set; }
        public DbSet<FunzionalitaEntity> Funzionalita { get; set; }
        public DbSet<BancheFunzionalitaEntity> BancheFunzionalita { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancaEntity>().HasData(
                new BancaEntity { Id = 1, Nome = "Fineco" },
                new BancaEntity { Id = 2, Nome = "BPM" },
                new BancaEntity { Id = 3, Nome = "Che Banche!" },
                new BancaEntity { Id = 4, Nome = "Intesa San Paolo" },
                new BancaEntity { Id = 5, Nome = "Credit Agricole" }
            );

            modelBuilder.Entity<UtenteEntity>().HasData(
                new UtenteEntity { Id = 1, IdBanca = 1, NomeUtente = "dario", Password = PasswordHasher.HashPassword("dario"), Token = "", Role = "teacher", Bloccato = false },
                new UtenteEntity { Id = 2, IdBanca = 2, NomeUtente = "sidy", Password = PasswordHasher.HashPassword("sidy"), Token = "", Role = "student", Bloccato = false },
                new UtenteEntity { Id = 3, IdBanca = 3, NomeUtente = "sandro", Password = PasswordHasher.HashPassword("sandro"), Token = "", Role = "student", Bloccato = true },
                new UtenteEntity { Id = 4, IdBanca = 2, NomeUtente = "sara", Password = PasswordHasher.HashPassword("sara"), Token = "", Role = "student", Bloccato = true }
            );



            modelBuilder.Entity<ContoEntity>().HasData(
                new ContoEntity { Id = 1, IdUtente = 1, Saldo = 1000, DataUltimaOperazione = DateTime.Now },
                new ContoEntity { Id = 2, IdUtente = 2, Saldo = 2000, DataUltimaOperazione = DateTime.Now },
                new ContoEntity { Id = 3, IdUtente = 3, Saldo = 2000, DataUltimaOperazione = DateTime.Now },
                new ContoEntity { Id = 4, IdUtente = 4, Saldo = 2000, DataUltimaOperazione = DateTime.Now }
            );

            modelBuilder.Entity<OperazioneEntity>().HasData(
                new OperazioneEntity { Id = 1, IdBanca = 1, IdUtente = 1, Funzionalita = "Deposito", Quantita = 500, DataOperazione = DateTime.Now },
                new OperazioneEntity { Id = 2, IdBanca = 2, IdUtente = 2, Funzionalita = "Prelievo", Quantita = 300, DataOperazione = DateTime.Now }
            );

            modelBuilder.Entity<FunzionalitaEntity>().HasData(
                new FunzionalitaEntity { Id = 1, Nome = "Versamento"},
                new FunzionalitaEntity { Id = 2, Nome = "Prelievo"},
                new FunzionalitaEntity { Id = 3, Nome = "Saldo"},
                new FunzionalitaEntity { Id = 4, Nome = "Registro Operazioni"}

            );

            modelBuilder.Entity<BancheFunzionalitaEntity>().HasData(
                new BancheFunzionalitaEntity { Id = 1, IdBanca = 1, IdFunzionalita = 1 },
                new BancheFunzionalitaEntity { Id = 2, IdBanca = 2, IdFunzionalita = 2 },
                new BancheFunzionalitaEntity { Id = 3, IdBanca = 2, IdFunzionalita = 1 },
                new BancheFunzionalitaEntity { Id = 4, IdBanca = 1, IdFunzionalita = 3 },
                new BancheFunzionalitaEntity { Id = 5, IdBanca = 3, IdFunzionalita = 2 },
                new BancheFunzionalitaEntity { Id = 6, IdBanca = 3, IdFunzionalita = 4 },
                new BancheFunzionalitaEntity { Id = 7, IdBanca = 1, IdFunzionalita = 2 }

            );

            modelBuilder.Entity<AdminEntity>().HasData(
                new AdminEntity { Id = 1, IdBanca = 1, Username = "admin", Password = PasswordHasher.HashPassword("admin"), Token = "", Role = "admin" },
                new AdminEntity { Id = 2, IdBanca = 2, Username = "admin1", Password = PasswordHasher.HashPassword("admin1"), Token = "", Role = "admin" },
                new AdminEntity { Id = 3, IdBanca = 3, Username = "admin2", Password = PasswordHasher.HashPassword("admin2"), Token = "", Role = "admin" },
                new AdminEntity { Id = 4, IdBanca = 4, Username = "admin3", Password = PasswordHasher.HashPassword("admin3"), Token = "", Role = "admin" }

            );

        }
    }
}
