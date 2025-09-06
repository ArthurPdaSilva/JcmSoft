using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> entity)
        {
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Cargo).HasMaxLength(100);
            entity.Property(e => e.Salario)
                .HasPrecision(14, 2)
                .IsConcurrencyToken();

            entity.HasData(
                 // Funcionários do Financeiro
                 new Funcionario { Id = 1, Nome = "João da Silva", Cargo = "Gerente de Finanças", Salario = 5250.00m, DataContratacao = new DateOnly(2023, 1, 15), DepartamentoId = 1 },
                 new Funcionario { Id = 2, Nome = "Carlos Pereira", Cargo = "Analista Financeiro", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 1 },
                 new Funcionario { Id = 3, Nome = "Ana Souza", Cargo = "Analista Financeiro", Salario = 4300.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = 1 },
                 new Funcionario { Id = 4, Nome = "Fernanda Oliveira", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoId = 1 },
                 new Funcionario { Id = 5, Nome = "José Santos", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoId = 1 },

                 // Funcionários do Marketing
                 new Funcionario { Id = 6, Nome = "Lucia Benitez", Cargo = "Analista de Marketing", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 2 },
                 new Funcionario { Id = 7, Nome = "Pedro Cardoso", Cargo = "Analista de Marketing", Salario = 4100.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoId = 2 },
                 new Funcionario { Id = 8, Nome = "Fabiana Costa", Cargo = "Gerente de Marketing", Salario = 5100.00m, DataContratacao = new DateOnly(2023, 3, 1), DepartamentoId = 2 },

                 // Funcionários do RH
                 new Funcionario { Id = 9, Nome = "Roberto Ferreira", Cargo = "Analista de Recursos Humanos", Salario = 3400.00m, DataContratacao = new DateOnly(2021, 9, 20), DepartamentoId = 3 },
                 new Funcionario { Id = 10, Nome = "Beatriz Almeida", Cargo = "Gerente de Recursos Humanos", Salario = 5000.00m, DataContratacao = new DateOnly(2022, 3, 10), DepartamentoId = 3 },
                 new Funcionario { Id = 11, Nome = "Mariana Dias", Cargo = "Analista de Recursos Humanos", Salario = 3000.00m, DataContratacao = new DateOnly(2023, 5, 5), DepartamentoId = 3 },

                 // Funcionários do Suporte
                 new Funcionario { Id = 12, Nome = "Juliana Mendes", Cargo = "Analista de Suporte", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 6, 15), DepartamentoId = 4 },
                 new Funcionario { Id = 13, Nome = "Rafael Souza", Cargo = "Gerente de Suporte", Salario = 5800.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoId = 4 },
                 new Funcionario { Id = 14, Nome = "Bruno Costa", Cargo = "Analista de Suporte", Salario = 4000.00m, DataContratacao = new DateOnly(2023, 1, 1), DepartamentoId = 4 },
                 new Funcionario { Id = 15, Nome = "Aline Dias", Cargo = "Analista de Suporte", Salario = 3900.00m, DataContratacao = new DateOnly(2023, 3, 10), DepartamentoId = 4 },

                 // Funcionários de TI
                 new Funcionario { Id = 16, Nome = "Felix Carvalho", Cargo = "Analista de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 17, Nome = "Gustavo Almeida", Cargo = "Programador Senior", Salario = 4500.00m, DataContratacao = new DateOnly(2022, 6, 5), DepartamentoId = 5 },
                 new Funcionario { Id = 18, Nome = "Renata Silva", Cargo = "Analista de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2021, 5, 18), DepartamentoId = 5 },
                 new Funcionario { Id = 19, Nome = "Thiago Souza", Cargo = "Gerente de TI", Salario = 6600.00m, DataContratacao = new DateOnly(2023, 4, 15), DepartamentoId = 5 },
                 new Funcionario { Id = 20, Nome = "Vanessa Oliveira", Cargo = "Engenheiro de Software", Salario = 5250.00m, DataContratacao = new DateOnly(2023, 5, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 21, Nome = "Leandro Pereira", Cargo = "Analista de TI", Salario = 4800.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },
                 new Funcionario { Id = 22, Nome = "Fernando Carvalho", Cargo = "Programador Junior", Salario = 2500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 23, Nome = "Gilberto Almeida", Cargo = "Programador Junior", Salario = 2300.00m, DataContratacao = new DateOnly(2023, 3, 13), DepartamentoId = 5 },
                 new Funcionario { Id = 24, Nome = "Renata Silva", Cargo = "Programador Junior", Salario = 2800.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 5 },
                 new Funcionario { Id = 25, Nome = "Tamirez Souza", Cargo = "Programador Pleno", Salario = 3600.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoId = 5 },
                 new Funcionario { Id = 26, Nome = "Vanessa Oliveira", Cargo = "Arquiteta de Software", Salario = 5000.00m, DataContratacao = new DateOnly(2023, 5, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 27, Nome = "Leonardo Pereira", Cargo = "Programador Senior", Salario = 5500.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },
                 new Funcionario { Id = 28, Nome = "Maria Benitez", Cargo = "Programador Senior", Salario = 5100.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 29, Nome = "Ricardo Pereira", Cargo = "Programador Pleno", Salario = 3500.00m, DataContratacao = new DateOnly(2022, 2, 11), DepartamentoId = 5 },
                 new Funcionario { Id = 30, Nome = "Paula Santos", Cargo = "Programador Senior", Salario = 4200.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },
                 new Funcionario { Id = 31, Nome = "Leonardo Pereira", Cargo = "Programador Senior", Salario = 4650.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },
                 new Funcionario { Id = 32, Nome = "Maria Benitez", Cargo = "Arquiteto de Software", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 33, Nome = "Reinaldo Pedreira", Cargo = "Programador Pleno", Salario = 3500.00m, DataContratacao = new DateOnly(2022, 2, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 34, Nome = "Helena Cintra", Cargo = "Programador Senior", Salario = 4600.00m, DataContratacao = new DateOnly(2022, 4, 20), DepartamentoId = 5 },
                 new Funcionario { Id = 35, Nome = "Carlos Santos", Cargo = "Programador Pleno", Salario = 3500.00m, DataContratacao = new DateOnly(2021, 9, 20), DepartamentoId = 5 },
                 new Funcionario { Id = 36, Nome = "Leonardo Ramirez", Cargo = "Programador Senior", Salario = 4500.00m, DataContratacao = new DateOnly(2023, 8, 1), DepartamentoId = 5 },
                 new Funcionario { Id = 37, Nome = "Amanda Sanches", Cargo = "Engenheiro de Testes", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 5 },
                 new Funcionario { Id = 38, Nome = "Rodrigo Pereira", Cargo = "Engenheiro de Testes", Salario = 4800.00m, DataContratacao = new DateOnly(2023, 2, 5), DepartamentoId = 5 },
                 new Funcionario { Id = 39, Nome = "Alicia Santos", Cargo = "Engenheiro de Testes", Salario = 5300.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 5 },
                 new Funcionario { Id = 40, Nome = "Paulo Mellado", Cargo = "Arquiteto de Software", Salario = 5800.00m, DataContratacao = new DateOnly(2022, 6, 20), DepartamentoId = 5 },

                 // Funcionários de Vendas
                 new Funcionario { Id = 41, Nome = "Marta Carvalho", Cargo = "Gerente de Vendas", Salario = 5200.00m, DataContratacao = new DateOnly(2021, 10, 10), DepartamentoId = 6 },
                 new Funcionario { Id = 42, Nome = "Ricardo Sanches", Cargo = "Representante de Vendas", Salario = 4500.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = 6 },
                 new Funcionario { Id = 43, Nome = "Patrícia Santos", Cargo = "Assistente de Vendas", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = 6 },
                 new Funcionario { Id = 44, Nome = "Alberto Lima", Cargo = "Representante de Vendas", Salario = 4800.00m, DataContratacao = new DateOnly(2022, 7, 18), DepartamentoId = 6 },
                 new Funcionario { Id = 45, Nome = "Rogério Oliveira", Cargo = "Assistente de Vendas", Salario = 3700.00m, DataContratacao = new DateOnly(2023, 6, 10), DepartamentoId = 6 }
            );


            //Configuração explícita de relacionamento 1:N
            //entity.HasOne(d => d.Departamento)
            //      .WithMany(p => p.Funcionarios)
            //      .HasForeignKey(d => d.DepartamentoId)
            //      .IsRequired() // Garante que a FK não seja nula
            //      .OnDelete(DeleteBehavior.Restrict); // Não permite excluir um Departamento se houver Funcionários associados


            //Relacionamento N:N entre Funcionario e Projeto via FuncionarioProjeto e implicito
            //entity.HasMany(f => f.Projetos)
            //      .WithMany(p => p.Funcionarios)
            //      .UsingEntity<Dictionary<string, object>>(
            //          "FuncionarioProjeto", // Nome da tabela de junção
            //          j => j.HasOne<Projeto>().WithMany().HasForeignKey("ProjetoId").HasConstraintName("FK_FuncionarioProjeto_Projeto").OnDelete(DeleteBehavior.Cascade),
            //          j => j.HasOne<Funcionario>().WithMany().HasForeignKey("FuncionarioId").HasConstraintName("FK_FuncionarioProjeto_Funcionario").OnDelete(DeleteBehavior.ClientCascade),
            //          j => j.ToTable("FuncionarioProjeto"));

        }
    }
}
