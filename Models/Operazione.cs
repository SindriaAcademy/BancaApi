namespace BancaApi.Models
{
    public class Operazione
    {
        public int Id { get; set; }
        public int IdBanca { get; set; }
        public int IdUtente { get; set; }
        public string Funzionalita { get; set; }
        public decimal Quantita { get; set; }
        public DateTime DataOperazione { get; set; }
    }

    public enum TipoOperazione
    {
        Prelievo,
        Versamento
    }
}
