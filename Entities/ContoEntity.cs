using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BancaApi.Models;

namespace BancaApi.Entities
{
    public class ContoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Utente")]
        public int IdUtente { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        public decimal Saldo { get; set; }

        [Required]
        public DateTime DataUltimaOperazione { get; set; }

        public UtenteEntity? Utente { get; set; }

    }
}
