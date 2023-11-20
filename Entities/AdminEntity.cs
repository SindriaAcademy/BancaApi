using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace BancaApi.Entities
{
    public class AdminEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Banca")]
        public int IdBanca { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public BancaEntity? Banca { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
