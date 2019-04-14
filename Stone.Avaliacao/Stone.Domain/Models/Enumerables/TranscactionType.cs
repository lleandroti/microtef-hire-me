using System.ComponentModel;

namespace Stone.Domain.Model.Enumerables
{
    public enum TranscactionType
    {
        [Description("Débito")]
        Debito,
        [Description("Crédito")]
        Credito,
        [Description("Crédito Parcelado")]
        CreditoParcelado
    }
}
