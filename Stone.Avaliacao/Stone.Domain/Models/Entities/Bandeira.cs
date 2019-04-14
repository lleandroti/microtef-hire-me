using System.Collections.Generic;

namespace Stone.Domain.Model.Entities
{
    public class Bandeira
    {
        public int Sequencial { get; set; }
        public string Nome { get; set; }
        public bool AceitaCredito { get; set; }
        public bool AceitaDebito { get; set; }

        public ICollection<Cartao> Cartoes { get; set; }
    }
}
