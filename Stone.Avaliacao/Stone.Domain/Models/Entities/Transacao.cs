using System;
using System.Security.AccessControl;
using Stone.Domain.Model.Enumerables;

namespace Stone.Domain.Model.Entities
{
    public class Transacao
    {
        public int Sequencial { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TranscactionType Tipo { get; set; }
        public int NumeroParcelas { get; set; }

        public int SequencialCartao { get; set; }
        public Cartao Cartao { get; set; }

        public int SequencialCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
