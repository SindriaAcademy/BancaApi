using BancaApi.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancaEntity>().HasData(
                new BancaEntity { Id = 1, Nome = "Banca Uno" },
                new BancaEntity { Id = 2, Nome = "Banca Due" }
            );

            modelBuilder.Entity<UtenteEntity>().HasData(
                new UtenteEntity { Id = 1, IdBanca = 1, NomeUtente = "dario", Password = "dario", Bloccato = false },
                new UtenteEntity { Id = 2, IdBanca = 2, NomeUtente = "sidy", Password = "sidy", Bloccato = false },
                new UtenteEntity { Id = 3, IdBanca = 2, NomeUtente = "sandro", Password = "sandro", Bloccato = true }
            );



            modelBuilder.Entity<ContoEntity>().HasData(
                new ContoEntity { Id = 1, IdUtente = 1, Saldo = 1000, DataUltimaOperazione = DateTime.Now },
                new ContoEntity { Id = 2, IdUtente = 2, Saldo = 2000, DataUltimaOperazione = DateTime.Now }
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

            // Popola la tabella BancheFunzionalita con dati di esempio
            modelBuilder.Entity<BancheFunzionalitaEntity>().HasData(
                new BancheFunzionalitaEntity { Id = 1, IdBanca = 1, IdFunzionalita = 1 },
                new BancheFunzionalitaEntity { Id = 2, IdBanca = 1, IdFunzionalita = 2 }
    
);

        }
    }
}
