﻿namespace Stone.Domain.Models.Adapters
{
    public class ClienteAlteraModel
    {
        public string Nome { get; set; }
        public virtual string Password { get; set; }
        public decimal LimiteCredito { get; set; }
        public bool Ativo { get; set; }
    }
}
