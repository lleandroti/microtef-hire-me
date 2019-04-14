namespace Stone.Domain.Model.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Ativo = true;
        }

        public int Sequencial { get; set; }
        public string Nome { get; set; }
        public virtual string Password { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool Ativo { get; set; }
    }
}
