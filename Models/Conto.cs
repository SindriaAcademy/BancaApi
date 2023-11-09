namespace BancaApi.Models
{
    public class Conto
    {
        public int Id { get; set; }
        public int IdUtente { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }
    }
}
