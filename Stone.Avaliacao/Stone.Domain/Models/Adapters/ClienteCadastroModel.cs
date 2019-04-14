namespace Stone.Domain.Model.Entities
{
    public class ClienteCadastroModel
    {
        public string Nome { get; set; }
        public virtual string Password { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}
