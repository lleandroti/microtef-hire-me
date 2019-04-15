using System;
using System.Collections.Generic;
using Stone.Domain.Model.Enumerables;

namespace Stone.Domain.Model.Entities
{
    public class Cartao
    {
        public virtual int Sequencial { get; set; }
        public virtual string NomeTitular { get; set; }
        public virtual string Numero { get; set; }
        public virtual DateTime DataExpiracao { get; set; }
        public virtual string Password { get; set; }
        public virtual CardType Tipo { get; set; }
        public virtual bool TemSenha { get { return Tipo == CardType.TarjaMagnetica; } }

        public virtual int SequencialBandeira { get; set; }
        public virtual Bandeira Bandeira { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
