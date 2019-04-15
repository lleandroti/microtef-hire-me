using System;
using System.Security.AccessControl;
using Stone.Domain.Model.Enumerables;

namespace Stone.Domain.Model.Entities
{
    public class Transacao
    {
        public virtual int Sequencial { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual TranscactionType Tipo { get; set; }
        public virtual int NumeroParcelas { get; set; }
               
        public virtual int SequencialCartao { get; set; }
        public virtual Cartao Cartao { get; set; }
               
        //public virtual int SequencialCliente { get; set; }
        //public virtual Cliente Cliente { get; set; }
    }
}
