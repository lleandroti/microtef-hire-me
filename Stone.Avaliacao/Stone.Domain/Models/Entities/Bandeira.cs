using System.Collections.Generic;

namespace Stone.Domain.Model.Entities
{
    public class Bandeira
    {
        public virtual int Sequencial { get; set; }
        public virtual string Nome { get; set; }
        public virtual bool AceitaCredito { get; set; }
        public virtual bool AceitaDebito { get; set; }
               
        public virtual ICollection<Cartao> Cartoes { get; set; }
    }
}
