using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaApi.Entities
{
    public class OperazioneEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Banca")]
        public int IdBanca { get; set; }
        public BancaEntity? Banca { get; set; }

        [ForeignKey("Utente")]
        public int IdUtente { get; set; }
        public UtenteEntity? Utente { get; set; }

        [Required]
        [MaxLength(50)]
        public string Funzionalita { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        public decimal Quantita { get; set; }

        [Required]
        public DateTime DataOperazione { get; set; }

    }
}
