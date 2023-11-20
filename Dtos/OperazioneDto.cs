using BancaApi.Models;

namespace BancaApi.Dtos
{
    public class OperazioneDto
    {
        public int Id { get; set; }
        public int IdBanca { get; set; }
        public int IdUtente { get; set; }
        public string Funzionalita { get; set; }
        public decimal Quantita { get; set; }
        public DateTime DataOperazione { get; set; }
    }
}
