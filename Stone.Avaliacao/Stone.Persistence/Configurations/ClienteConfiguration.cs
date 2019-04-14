using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Domain.Model.Entities;

namespace Stone.Persistence.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("CLIENTE");

            HasKey(e => e.Sequencial);

            Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            Property(e => e.Password).HasColumnName("PASSWORD");
            Property(e => e.LimiteCredito).HasColumnName("LIMITECREDITO").IsRequired();
            Property(e => e.Ativo).HasColumnName("ATIVO").IsRequired();
        }
    }
}
