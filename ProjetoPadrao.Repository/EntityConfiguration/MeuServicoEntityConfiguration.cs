using ProjetoPadrao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoPadrao.Repository.EntityConfiguration
{
    public class MeuServicoEntityConfiguration : EntityTypeConfiguration<MeuServico>
    {
        public MeuServicoEntityConfiguration()
        {
            this.ToTable("MeuServico");

            this.HasKey<int>(s => s.MeuServicoId);

            this.Property(p => p.Description).IsRequired().HasMaxLength(100);
        }
    }
}
