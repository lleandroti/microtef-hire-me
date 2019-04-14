using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Model.Entities;

namespace Stone.Persistence.Configurations
{
    public class BandeiraConfiguration : EntityTypeConfiguration<Bandeira>
    {
        public BandeiraConfiguration()
        {
            ToTable("BANDEIRA");

            HasKey(e => e.Sequencial);

            Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();
            Property(e => e.AceitaCredito).HasColumnName("ACEITACREDITO");
            Property(e => e.AceitaDebito).HasColumnName("ACEITADEBITO");
        }
    }
}
