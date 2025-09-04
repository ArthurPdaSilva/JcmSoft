using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class FuncionarioDepartamentoViewConfiguration : IEntityTypeConfiguration<FuncionarioDepartamentoView>
    {
        public void Configure(EntityTypeBuilder<FuncionarioDepartamentoView> entity)
        {
            entity.HasNoKey();
            entity.ToView("view_funcinariosDepartamentos");
            entity.Property(v => v.NomeFuncionario).HasMaxLength(100);
            entity.Property(v => v.Cargo).HasMaxLength(100);
            entity.Property(v => v.NomeDepartamento).HasMaxLength(100);
            entity.Property(v => v.DescricaoDepartamento).HasMaxLength(200);
        }
    }
}
