using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Model.Entities;

namespace Stone.Persistence.Configurations
{
    public class TransacaoConfiguration : EntityTypeConfiguration<Transacao>
    {
        public TransacaoConfiguration()
        {
            ToTable("TRANSACAO");

            HasKey(e => e.Sequencial);

            Property(e => e.Data).HasColumnName("DATA").IsRequired();
            Property(e => e.Valor).HasColumnName("VALOR").IsRequired();
            Property(e => e.Tipo).HasColumnName("TIPO").IsRequired();
            Property(e => e.NumeroParcelas).HasColumnName("NUMEROPARCELAS");

            Property(p => p.SequencialCartao).HasColumnName("SEQUENCIALCARTAO").IsRequired();
            HasRequired(p => p.Cartao).WithMany(e => e.Transacoes).HasForeignKey(p => p.SequencialCartao);
        }
    }
}
