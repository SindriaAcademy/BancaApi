namespace BancaApi.Dtos
{
    public class UtenteDto
    {
        public int Id { get; set; }
        public int IdBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
        public bool Bloccato { get; set; } = false;
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
