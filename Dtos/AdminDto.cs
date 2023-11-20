using System.Security.Cryptography;
using System.Text;

namespace BancaApi.Dtos
{
    public class AdminDto
    {
        public int Id { get; set; }
        public int IdBanca { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }

    }
}
