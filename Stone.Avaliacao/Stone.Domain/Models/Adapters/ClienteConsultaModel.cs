namespace Stone.Domain.Models.Adapters
{
    public class ClienteConsultaModel
    {
        public int Sequencial { get; set; }
        public string Nome { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool Ativo { get; set; }
    }
}
