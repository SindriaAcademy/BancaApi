using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaApi.Entities
{
    public class ContoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdUtente { get; set; }

        [Required]
        public decimal Saldo { get; set; }

        [Required]
        public DateTime DataUltimaOperazione { get; set; }

    }
}
