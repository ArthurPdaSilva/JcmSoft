using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> entity)
        {
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Descricao).HasMaxLength(200);

            entity.Property(e => e.Orcamento).HasColumnType("decimal(20,2)");
            //Coluna Computada e DateDiff calcula a diferença entre duas datas, sendo o primeiro parâmetro a unidade de tempo (DAY, MONTH, YEAR, etc.), o segundo a data inicial e o terceiro a data final.
            //O Stored: true indica que o valor é armazenado fisicamente no banco de dados, em vez de ser calculado dinamicamente a cada vez que é acessado.
            entity.Property(e => e.DuracaoEmDias).HasComputedColumnSql("DATEDIFF(DAY, DataInicio, DataFim)", stored: true);

            entity.HasData(
               new Projeto
               {
                   Id = 1,
                   Nome = "Projeto A",
                   Descricao = "Descrição do Projeto A",
                   Orcamento = 1000000,
                   DataInicio = new DateTime(2023, 1, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 6, 30),
                   ClienteId = 2,
                   Status = StatusProjeto.EmAprovacao
               },
               new Projeto
               {
                   Id = 2,
                   Nome = "Projeto B",
                   Descricao = "Descrição do Projeto B",
                   Orcamento = 2000000,
                   DataInicio = new DateTime(2023, 2, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 7, 31),
                   ClienteId = 1,
                   Status = StatusProjeto.EmRevisao
               },
               new Projeto
               {
                   Id = 3,
                   Nome = "Projeto C",
                   Descricao = "Descrição do Projeto C",
                   Orcamento = 3000000,
                   DataInicio = new DateTime(2023, 3, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 8, 31),
                   ClienteId = 5,
                   Status = StatusProjeto.Iniciado
               },
               new Projeto
               {
                   Id = 4,
                   Nome = "Projeto D",
                   Descricao = "Descrição do Projeto D",
                   Orcamento = 4000000,
                   DataInicio = new DateTime(2023, 4, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 9, 30),
                   ClienteId = 3,
                   Status = StatusProjeto.Iniciado
               },
               new Projeto
               {
                   Id = 5,
                   Nome = "Projeto E",
                   Descricao = "Descrição do Projeto E",
                   Orcamento = 5000000,
                   DataInicio = new DateTime(2023, 5, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 10, 31),
                   ClienteId = 4,
                   Status = StatusProjeto.EmAndamento
               },
               new Projeto
               {
                   Id = 6,
                   Nome = "Projeto F",
                   Descricao = "Descrição do Projeto F",
                   Orcamento = 6000000,
                   DataInicio = new DateTime(2023, 6, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2023, 11, 30),
                   ClienteId = 1,
                   Status = StatusProjeto.Cancelado
               },
               new Projeto
               {
                   Id = 7,
                   Nome = "Projeto G",
                   Descricao = "Descrição do Projeto G",
                   Orcamento = 9000000,
                   DataInicio = new DateTime(2023, 10, 1),
                   DataAtualizacao = new DateTime(2025, 3, 11),
                   DataFim = new DateTime(2024, 3, 31),
                   ClienteId = 3,
                   Status = StatusProjeto.EmAndamento
               }
            );

        }
    }
}
