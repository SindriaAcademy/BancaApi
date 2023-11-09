using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaApi.Entities
{
    public class UtenteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Banca")]
        public int IdBanca { get; set; }
        public BancaEntity? Banca { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeUtente { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        public bool Bloccato { get; set; }

    }
}
