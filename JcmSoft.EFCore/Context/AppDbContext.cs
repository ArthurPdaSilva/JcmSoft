using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JcmSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioDetalhe> FuncionariosDetalhes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<FuncionarioProjeto> FuncionarioProjetos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(AppConfig.GetConnectionString())
                //Para não precisar setar AsSplitQuery toda vez que for fazer uma consulta com várias entidades relacionadas (Include)
                .UseSqlServer(o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)) //Evita o problema do cartesian explosion quando se faz consultas com várias entidades relacionadas (Include)
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Para usar os arquivos de configuração separados:
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Aplica todas as configurações de entidades que implementam IEntityTypeConfiguration<T> na assembly atual

            //modelBuilder.HasDefaultSchema("jcmsoft"); // Troca o schema padrão do banco de dados (default é dbo)

            //var departamentoIds = new List<Guid>()
            //{
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //    Guid.NewGuid()
            //};
            //var funcionariosId = new List<Guid>() {
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //};
            //var projetosId = new List<Guid>()
            //{
            //    Guid.NewGuid(),
            //    Guid.NewGuid(),
            //};
            //var clienteId = Guid.NewGuid();

            //Fluent API: Ele sobrescreve as configurações feitas por Data Annotations
            //É indicado quando você não quer poluir suas classes de domínio com atributos do data annotations
            //modelBuilder.Entity<Departamento>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Nome).HasMaxLength(100);
            //    //Varchar caracteres não especiais e Nvarchar para caracteres especiais
            //    //Forçando um tipo: .HasColumnType("varchar(200)");
            //    entity.Property(e => e.Descricao).HasMaxLength(200);
            //    //entity.Property(e => e.DataCriacao).HasDefaultValueSql("GETDATE()"); Se nenhum valor for passado, o SQL Server atribui a data atual

            //    //Adicionando dados iniciais (Seed Data)
            //    entity.HasData(
            //      new Departamento { Id = departamentoIds[0], Nome = "Financeiro", Descricao = "Gestão das finanças" },
            //      new Departamento { Id = departamentoIds[1], Nome = "Marketing", Descricao = "Promoção de produtos" },
            //      new Departamento { Id = departamentoIds[2], Nome = "RH", Descricao = "Recursos Humanos" },
            //      new Departamento { Id = departamentoIds[3], Nome = "Suporte", Descricao = "Atendimento ao cliente" },
            //      new Departamento { Id = departamentoIds[4], Nome = "TI", Descricao = "Tecnologia da Informação" },
            //      new Departamento { Id = departamentoIds[5], Nome = "Vendas", Descricao = "Gestão de Vendas" }
            //  );
            //});

            //modelBuilder.Entity<Funcionario>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Nome).HasMaxLength(100);
            //    entity.Property(e => e.Cargo).HasMaxLength(100);
            //    entity.Property(e => e.Salario).HasColumnType("decimal(12,2)");

            //    entity.HasData(
            //        new Funcionario { Id = funcionariosId[0], Nome = "João Silva", Cargo = "Gerente de Finanças", Salario = 5250.00m, DataContratacao = new DateOnly(2023, 1, 15), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = funcionariosId[1], Nome = "Carlos Pereira", Cargo = "Analista Financeiro", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Ana Souza", Cargo = "Analista Contábil", Salario = 4300.00m, DataContratacao = new DateOnly(2022, 2, 15), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Marcos Lima", Cargo = "Assistente Financeiro", Salario = 3200.00m, DataContratacao = new DateOnly(2022, 5, 20), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Fernanda Oliveira", Cargo = "Coordenadora Financeira", Salario = 4800.00m, DataContratacao = new DateOnly(2023, 4, 5), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "José Santos", Cargo = "Técnico em Contabilidade", Salario = 3400.00m, DataContratacao = new DateOnly(2023, 7, 18), DepartamentoId = departamentoIds[0] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Lucia Benitez", Cargo = "Coordenador de Marketing", Salario = 4500.00m, DataContratacao = new DateOnly(2021, 11, 10), DepartamentoId = departamentoIds[1] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Pedro Cardoso", Cargo = "Analista de Marketing", Salario = 4100.00m, DataContratacao = new DateOnly(2022, 8, 22), DepartamentoId = departamentoIds[1] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Carla Teixeira", Cargo = "Especialista em SEO", Salario = 3900.00m, DataContratacao = new DateOnly(2022, 10, 15), DepartamentoId = departamentoIds[1] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Fabiana Costa", Cargo = "Gerente de Marketing", Salario = 5100.00m, DataContratacao = new DateOnly(2023, 3, 1), DepartamentoId = departamentoIds[1] },
            //        new Funcionario { Id = Guid.NewGuid(), Nome = "Rafael Mendes", Cargo = "Assistente de Marketing", Salario = 3000.00m, DataContratacao = new DateOnly(2023, 6, 12), DepartamentoId = departamentoIds[2] }
            //    );
            //});

            //modelBuilder.Entity<FuncionarioDetalhe>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Endereco).HasMaxLength(200);
            //    //Não possui nativamente o recurso para adicionar mensagens de erro customizadas
            //    entity.Property(e => e.Telefone).HasMaxLength(15);
            //    entity.Property(e => e.Foto).HasMaxLength(200);
            //    entity.Property(e => e.Nacionalidade).HasMaxLength(50);
            //    entity.Property(e => e.CPF).HasMaxLength(11);

            //    entity.HasData(
            //        new FuncionarioDetalhe
            //        {
            //            Id = Guid.NewGuid(),
            //            Endereco = "Rua A, 123",
            //            Telefone = "1133333333",
            //            CPF = "12345678901",
            //            DataNascimento = new DateTime(1990, 5, 20),
            //            FuncionarioId = funcionariosId[0],
            //            EstadoCivil = EstadoCivil.CASADO,
            //            Escolaridade = Escolaridade.MEDIO_INCOMPLETO,
            //            Genero = Genero.MASCULINO
            //        },
            //        new FuncionarioDetalhe
            //        {
            //            Id = Guid.NewGuid(),
            //            Endereco = "Rua B, 456",
            //            Telefone = "2133333333",
            //            CPF = "10987654321",
            //            DataNascimento = new DateTime(1985, 8, 15),
            //            FuncionarioId = funcionariosId[1],
            //            EstadoCivil = EstadoCivil.UNIAO_ESTAVEL,
            //            Escolaridade = Escolaridade.FUNDAMENTAL_COMPLETO,
            //            Genero = Genero.OUTRO
            //        }
            //    );
            //});

            //modelBuilder.Entity<Cliente>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //entity.HasIndex(e => e.Nome);
            //entity.HasIndex(e => e.Email).IsUnique();

            //Global Query Filters - Filtros aplicados automaticamente a todas as consultas de uma entidade específica, permitindo filtrar dados com base em condições predefinidas, como status ativo/inativo, data de exclusão lógica, etc.
            //Só da para add um hasQueryFilter por entidade
            //entity.HasQueryFilter(f => f.Ativo && f.Projetos.Any());
            //    entity.HasQueryFilter(f => f.Ativo);
            //    entity.Property(e => e.Nome).HasMaxLength(100);
            //    entity.Property(e => e.Email).HasMaxLength(100);
            //    entity.Property(e => e.Telefone).HasMaxLength(15);
            //    entity.HasData(
            //        new Cliente
            //        {
            //            Id = clienteId,
            //            Nome = "Empresa XYZ",
            //            Email = "",
            //            Telefone = "11999999999",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Tech Solutions",
            //            Email = "contato@techsolutions.com",
            //            Telefone = "11988888888",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Construtora Alpha",
            //            Email = "alpha@construtora.com",
            //            Telefone = "11977777777",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Supermercado Bom Preço",
            //            Email = "suporte@bompreco.com",
            //            Telefone = "11966666666",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "AgroVale",
            //            Email = "vendas@agrovale.com",
            //            Telefone = "11955555555",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Clínica Vida",
            //            Email = "info@clinicavida.com",
            //            Telefone = "11944444444",
            //            Ativo = true
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Transportadora Rápida",
            //            Email = "contato@transportadorarapida.com",
            //            Telefone = "11933333333",
            //            Ativo = false
            //        },
            //        new Cliente
            //        {
            //            Id = Guid.NewGuid(),
            //            Nome = "Editora Saber",
            //            Email = "editor@saber.com",
            //            Telefone = "11922222222",
            //            Ativo = false
            //        }
            //    );

            //    modelBuilder.Entity<Projeto>(entity =>
            //    {
            //        entity.HasKey(e => e.Id);
            //        entity.Property(e => e.Nome).HasMaxLength(100);
            //        entity.Property(e => e.Descricao).HasMaxLength(100);
            //        entity.Property(e => e.Orcamento).HasColumnType("decimal(20,2)");
            //        entity.HasData(
            //            new Projeto
            //            {
            //                Id = projetosId[0],
            //                Nome = "Projeto Alpha",
            //                Descricao = "Desenvolvimento do Projeto Alpha",
            //                DataInicio = new DateTime(2023, 1, 10),
            //                DataFim = new DateTime(2023, 6, 30),
            //                ClienteId = clienteId
            //            },
            //            new Projeto
            //            {
            //                Id = projetosId[1],
            //                Nome = "Projeto Beta",
            //                Descricao = "Implementação do Sistema Beta",
            //                DataInicio = new DateTime(2023, 2, 15),
            //                ClienteId = clienteId
            //            }
            //        );
            //    });

            //    modelBuilder.Entity<FuncionarioProjeto>(entity =>
            //    {
            //        entity.HasKey(e => new { e.FuncionarioId, e.ProjetoId });
            //        entity.HasData(
            //            new FuncionarioProjeto
            //            {
            //                FuncionarioId = funcionariosId[0],
            //                ProjetoId = projetosId[1],
            //                HorasTrabalhadas = 150
            //            },
            //            new FuncionarioProjeto
            //            {
            //                FuncionarioId = funcionariosId[1],
            //                ProjetoId = projetosId[0],
            //                HorasTrabalhadas = 200
            //            }
            //        );
            //    });
            //});
        }
    }
}
