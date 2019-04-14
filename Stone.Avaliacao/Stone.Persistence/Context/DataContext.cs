using System.Configuration;
using System.Data.Entity;
using Stone.Domain.Model.Entities;
using Stone.Persistence.Configurations;

namespace Stone.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.ConnectionStrings["stoneAvaliacao"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BandeiraConfiguration());
            modelBuilder.Configurations.Add(new CartaoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new TransacaoConfiguration());
        }

        public DbSet<Bandeira> Bandeiras { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
