using System.Collections.Generic;

namespace Stone.Domain.Model.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Ativo = true;
        }

        public virtual int Sequencial { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Password { get; set; }
        public virtual decimal LimiteCredito { get; set; }
        public virtual bool Ativo { get; set; }
               
        //public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
