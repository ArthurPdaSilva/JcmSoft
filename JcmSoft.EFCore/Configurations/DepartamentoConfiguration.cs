using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> entity)
        {
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Descricao).HasMaxLength(200);
            //O mesmo de Timestamp só q feito com Fluent API
            entity.Property(e => e.RowVersion).IsRowVersion();

            entity.HasData(
                new Departamento { Id = 1, Nome = "Financeiro", Descricao = "Gestão das finanças", DataCriacao = new DateTime(2023, 01, 01) },
                new Departamento { Id = 2, Nome = "Marketing", Descricao = "Promoção de produtos", DataCriacao = new DateTime(2023, 01, 01) },
                new Departamento { Id = 3, Nome = "RH", Descricao = "Recursos Humanos", DataCriacao = new DateTime(2023, 01, 01) },
                new Departamento { Id = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente", DataCriacao = new DateTime(2023, 01, 01) },
                new Departamento { Id = 5, Nome = "TI", Descricao = "Tecnologia da Informação", DataCriacao = new DateTime(2023, 01, 01) },
                new Departamento { Id = 6, Nome = "Vendas", Descricao = "Gestão de Vendas", DataCriacao = new DateTime(2023, 01, 01) },
                 new Departamento { Id = 7, Nome = "Farmacêutico", Descricao = "Gestão de Vendas", DataCriacao = new DateTime(2021, 01, 01) }
            );
            
            //entity.HasMany(d => d.Funcionarios)
            //      .WithOne(f => f.Departamento)
            //      .HasForeignKey(f => f.DepartamentoId)
            //      .OnDelete(DeleteBehavior.Cascade); // Se eu apagar um departamento, apaga todos os funcionários associados

        }
    }
}
