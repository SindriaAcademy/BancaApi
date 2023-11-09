using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaApi.Entities
{
    public class BancheFunzionalitaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Banca")]
        public int IdBanca { get; set; }

        public BancaEntity? Banca { get; set; }

        [ForeignKey("Funzionalita")]
        public int IdFunzionalita { get; set; }

        public FunzionalitaEntity? Funzionalita { get; set; }


    }
}
