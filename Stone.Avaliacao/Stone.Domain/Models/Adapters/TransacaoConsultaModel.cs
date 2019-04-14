using System;

namespace Stone.Domain.Models.Adapters
{
    public class TransacaoConsultaModel
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public string Tipo { get; set; }
        public int NumeroParcelas { get; set; }

        public virtual string NomeTitular { get; set; }
        public string Bandeira { get; set; }
    }
}
