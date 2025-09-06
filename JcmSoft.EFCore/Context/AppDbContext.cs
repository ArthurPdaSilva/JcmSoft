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
        public DbSet<FuncionarioDepartamentoView> FuncionarioDepartamentoViews { get; set; } //Para mapear a view criada no banco de dados
        //public DbSet<Produto> Produtos { get; set; }

        //Função tabular definida pelo usuário (TVF - Table Valued Function)
        public IQueryable<Projeto> ProjetosAtivosApos(DateTime dataInicio) => FromExpression(() => ProjetosAtivosApos(dataInicio));

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

            //Mapeando uma função do C# para uma função do SQL Server
            modelBuilder.HasDbFunction(() => FuncoesSQL.FuncoesSQL.CalcularAnosDeServico(default))
                .HasName("CalcularAnosDeServico");
            //.HasSchema("dbo"); //Mapeando a função do C# para a função do SQL Server

            //Mapeando a TVF (Table Valued Function)
            modelBuilder
                .HasDbFunction(typeof(AppDbContext).GetMethod(nameof(ProjetosAtivosApos), new[] { typeof(DateTime) })!)
                .HasName("ProjetosAtivosApos")
                .HasSchema("dbo");


            //Número para Sequencia
            modelBuilder.HasSequence<int>("NumeroOSSequence", "dbo") //Cria uma sequência no banco de dados
                .StartsAt(2001) //Inicia em 2001
                .IncrementsBy(10) //Incrementa de 10 em 10
                //Opcionais:
                .HasMin(2001)
                .HasMax(999999);
                //.IsCyclic(); //Quando chegar no máximo, volta para o mínimo (O padrão é não usar)

            modelBuilder.Entity<Projeto>()
                .Property(p => p.NumeroOrdemServico)
                .HasDefaultValueSql("NEXT VALUE FOR NumeroOSSequence"); //Usa a sequência criada para o valor padrão da propriedade NumeroOS

            //Conferir na tabela: select * from sys.sequences s 
            //Atualizar os projetos antigos: update Projetos set NumeroOrdemServico = NEXT VALUE FOR dbo.NumeroOSSequence where NumeroOrdemServico = 0

            //modelBuilder.HasDefaultSchema("jcmsoft"); // Troca o schema padrão do banco de dados (default é dbo)

            //Fluent API: Ele sobrescreve as configurações feitas por Data Annotations
            //É indicado quando você não quer poluir suas classes de domínio com atributos do data annotations
            //modelBuilder.Entity<Departamento>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Nome).HasMaxLength(100);
            //    //Varchar caracteres não especiais e Nvarchar para caracteres especiais
            //    //Forçando um tipo: .HasColumnType("varchar(200)");
            //    //entity.Property(e => e.DataCriacao).HasDefaultValueSql("GETDATE()"); Se nenhum valor for passado, o SQL Server atribui a data atual

            //    //Adicionando dados iniciais (Seed Data)
            //    entity.HasData(
            //      new Departamento { Id = departamentoIds[0], Nome = "Financeiro", Descricao = "Gestão das finanças" },.....
            //  );
            //});


            //Não possui nativamente o recurso para adicionar mensagens de erro customizadas, para isso use o Data Annotations
            //    entity.Property(e => e.Telefone).HasMaxLength(15);

            //Global Query Filters - Filtros aplicados automaticamente a todas as consultas de uma entidade específica, permitindo filtrar dados com base em condições predefinidas, como status ativo/inativo, data de exclusão lógica, etc.
            //Só da para add um hasQueryFilter por entidade
            //entity.HasQueryFilter(f => f.Ativo && f.Projetos.Any()); //Só suporta uma prop HasQueryFilter por entidade
            //entity.HasQueryFilter(f => f.Ativo);

        }
    }
}
