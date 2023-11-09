namespace BancaApi.Models
{
    public class Utente
    {
        
        public int Id { get; set; }
        public int IdBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
        public bool Bloccato { get; set; }
    }
}
