namespace Stone.Domain.Models.Adapters
{
    public class ClienteCadastroModel
    {
        public string Nome { get; set; }
        public virtual string Password { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}
