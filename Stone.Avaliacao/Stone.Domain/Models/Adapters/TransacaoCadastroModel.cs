using System;

namespace Stone.Domain.Models.Adapters
{
    public class TransacaoCadastroModel
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public int Tipo { get; set; }
        public bool Parcelado { get; set; }
        public int NumeroParcelas { get; set; }

        public string NomeTitular { get; set; }
        public string NumeroCartao{ get; set; }
        public bool Chip { get; set; }
        public int ValidadeMes { get; set; }
        public int ValidadeAno { get; set; }
        public string Password { get; set; }
        public int Bandeira { get; set; }
    }
}
