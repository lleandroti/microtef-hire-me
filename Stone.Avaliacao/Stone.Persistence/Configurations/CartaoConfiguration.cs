using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Model.Entities;

namespace Stone.Persistence.Configurations
{
    public class CartaoConfiguration : EntityTypeConfiguration<Cartao>
    {
        public CartaoConfiguration()
        {
            ToTable("CARTAO");

            HasKey(e => e.Sequencial);

            Property(e => e.NomeTitular).HasColumnName("NOMETITULAR").HasMaxLength(100).IsRequired();
            Property(e => e.Numero).HasColumnName("NUMERO").HasMaxLength(19).IsRequired();
            Property(e => e.DataExpiracao).HasColumnName("DATAEXPIRACAO").IsRequired();
            Property(e => e.Password).HasColumnName("PASSWORD").IsRequired();
            Property(e => e.Tipo).HasColumnName("TIPO").IsRequired();

            Property(p => p.SequencialBandeira).HasColumnName("SEQUENCIALBANDEIRA").IsRequired();
            HasRequired(p => p.Bandeira).WithMany(e => e.Cartoes).HasForeignKey(p => p.SequencialBandeira);
        }
    }
}
