using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(200);

                entity.HasData(
                    new Departamento { Id = 1, Nome = "Financeiro", Descricao = "Gestão das finanças", DataCriacao = new DateTime(2023, 01, 01) },
                    new Departamento { Id = 2, Nome = "Marketing", Descricao = "Promoção de produtos", DataCriacao = new DateTime(2023, 01, 01) },
                    new Departamento { Id = 3, Nome = "RH", Descricao = "Recursos Humanos", DataCriacao = new DateTime(2023, 01, 01) },
                    new Departamento { Id = 4, Nome = "Suporte", Descricao = "Atendimento ao cliente", DataCriacao = new DateTime(2023, 01, 01) },
                    new Departamento { Id = 5, Nome = "TI", Descricao = "Tecnologia da Informação", DataCriacao = new DateTime(2023, 01, 01) },
                    new Departamento { Id = 6, Nome = "Vendas", Descricao = "Gestão de Vendas", DataCriacao = new DateTime(2023, 01, 01) }
                );
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Cargo).HasMaxLength(100);
                entity.Property(e => e.Salario).HasColumnType("decimal(14,2)");

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
            });

            modelBuilder.Entity<FuncionarioDetalhe>(entity =>
            {
                entity.Property(e => e.EnderecoResidencial).HasMaxLength(200);
                entity.Property(e => e.Celular).HasMaxLength(15);
                entity.Property(e => e.Foto).HasMaxLength(200);
                entity.Property(e => e.Nacionalidade).HasMaxLength(50);
                entity.Property(e => e.CPF).HasMaxLength(11);

                entity.HasData(
                   new FuncionarioDetalhe { Id = 1, FuncionarioId = 1, EnderecoResidencial = "Rua A, 123", DataNascimento = new DateTime(1990, 5, 10), Celular = "999999999", Genero = Genero.Masculino, Foto = "foto1.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "12345678901", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 2, FuncionarioId = 2, EnderecoResidencial = "Rua B, 234", DataNascimento = new DateTime(1988, 11, 20), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto2.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "23456789012", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 3, FuncionarioId = 3, EnderecoResidencial = "Rua C, 345", DataNascimento = new DateTime(1992, 8, 15), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto3.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "34567890123", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 4, FuncionarioId = 4, EnderecoResidencial = "Rua D, 456", DataNascimento = new DateTime(1985, 2, 25), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto4.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "45678901234", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 5, FuncionarioId = 5, EnderecoResidencial = "Rua E, 567", DataNascimento = new DateTime(1994, 3, 5), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto5.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "56789012345", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 6, FuncionarioId = 6, EnderecoResidencial = "Rua F, 678", DataNascimento = new DateTime(1989, 12, 15), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto6.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "67890123456", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },

                   new FuncionarioDetalhe { Id = 7, FuncionarioId = 7, EnderecoResidencial = "Rua G, 789", DataNascimento = new DateTime(1991, 7, 21), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto7.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "78901234567", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 8, FuncionarioId = 8, EnderecoResidencial = "Rua H, 890", DataNascimento = new DateTime(1986, 4, 14), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto8.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "89012345678", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 9, FuncionarioId = 9, EnderecoResidencial = "Rua I, 901", DataNascimento = new DateTime(1993, 9, 12), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto9.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "90123456789", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 10, FuncionarioId = 10, EnderecoResidencial = "Rua J, 101", DataNascimento = new DateTime(1995, 11, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto10.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "01234567890", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                   new FuncionarioDetalhe { Id = 11, FuncionarioId = 11, EnderecoResidencial = "Rua K, 111", DataNascimento = new DateTime(1987, 1, 22), Celular = "988888888", Genero = Genero.Feminino, Foto = "foto11.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11111100111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 12, FuncionarioId = 12, EnderecoResidencial = "Rua L, 121", DataNascimento = new DateTime(1990, 2, 2), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto12.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22222112222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 13, FuncionarioId = 13, EnderecoResidencial = "Rua M, 131", DataNascimento = new DateTime(1991, 3, 3), Celular = "966666666", Genero = Genero.Feminino, Foto = "foto13.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33333322333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 14, FuncionarioId = 14, EnderecoResidencial = "Rua N, 141", DataNascimento = new DateTime(1992, 4, 4), Celular = "955555555", Genero = Genero.Masculino, Foto = "foto14.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44444114444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 15, FuncionarioId = 15, EnderecoResidencial = "Rua O, 151", DataNascimento = new DateTime(1993, 5, 5), Celular = "944444444", Genero = Genero.Feminino, Foto = "foto15.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55555533555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 16, FuncionarioId = 16, EnderecoResidencial = "Rua P, 161", DataNascimento = new DateTime(1994, 6, 6), Celular = "933333333", Genero = Genero.Masculino, Foto = "foto16.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66666446666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 17, FuncionarioId = 17, EnderecoResidencial = "Rua Q, 171", DataNascimento = new DateTime(1995, 7, 7), Celular = "922222222", Genero = Genero.Feminino, Foto = "foto17.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77777777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 18, FuncionarioId = 18, EnderecoResidencial = "Rua R, 181", DataNascimento = new DateTime(1996, 8, 8), Celular = "911111111", Genero = Genero.Masculino, Foto = "foto18.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "87788888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 19, FuncionarioId = 19, EnderecoResidencial = "Rua S, 191", DataNascimento = new DateTime(1997, 9, 9), Celular = "900000000", Genero = Genero.Feminino, Foto = "foto19.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99999799999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 20, FuncionarioId = 20, EnderecoResidencial = "Rua T, 201", DataNascimento = new DateTime(1988, 10, 10), Celular = "988888888", Genero = Genero.Masculino, Foto = "foto20.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00100000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },

                   new FuncionarioDetalhe { Id = 21, FuncionarioId = 21, EnderecoResidencial = "Rua U, 211", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Feminino, Foto = "foto21.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11112222202", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 22, FuncionarioId = 22, EnderecoResidencial = "Rua V, 521", DataNascimento = new DateTime(1990, 12, 12), Celular = "966666666", Genero = Genero.Masculino, Foto = "foto22.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22223033333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 23, FuncionarioId = 23, EnderecoResidencial = "Rua W, 231", DataNascimento = new DateTime(1991, 1, 13), Celular = "955555555", Genero = Genero.Feminino, Foto = "foto23.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33334444044", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 24, FuncionarioId = 24, EnderecoResidencial = "Rua X, 141", DataNascimento = new DateTime(1992, 2, 14), Celular = "944444444", Genero = Genero.Masculino, Foto = "foto24.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "44045555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 25, FuncionarioId = 25, EnderecoResidencial = "Rua Y, 251", DataNascimento = new DateTime(1993, 3, 15), Celular = "933333333", Genero = Genero.Feminino, Foto = "foto25.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556606666", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 26, FuncionarioId = 26, EnderecoResidencial = "Rua Z, 461", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222222", Genero = Genero.Masculino, Foto = "foto26.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "66667777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 27, FuncionarioId = 27, EnderecoResidencial = "Rua AA, 271", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111111", Genero = Genero.Feminino, Foto = "foto27.jpg", EstadoCivil = EstadoCivil.Viuvo, CPF = "77778888888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 28, FuncionarioId = 28, EnderecoResidencial = "Rua AB, 181", DataNascimento = new DateTime(1996, 6, 18), Celular = "900000000", Genero = Genero.Masculino, Foto = "foto28.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

                   new FuncionarioDetalhe { Id = 29, FuncionarioId = 29, EnderecoResidencial = "Rua UU, 271", DataNascimento = new DateTime(1989, 11, 11), Celular = "977777777", Genero = Genero.Masculino, Foto = "foto29.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "11182222222", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 30, FuncionarioId = 30, EnderecoResidencial = "Rua VV, 241", DataNascimento = new DateTime(1990, 12, 12), Celular = "966646666", Genero = Genero.Masculino, Foto = "foto30.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "22229333333", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 31, FuncionarioId = 31, EnderecoResidencial = "Rua WW, 261", DataNascimento = new DateTime(1991, 1, 13), Celular = "955557555", Genero = Genero.Feminino, Foto = "foto31.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "33335444444", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 32, FuncionarioId = 32, EnderecoResidencial = "Rua XX, 801", DataNascimento = new DateTime(1992, 2, 14), Celular = "944448444", Genero = Genero.Masculino, Foto = "foto32.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "44447555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 33, FuncionarioId = 33, EnderecoResidencial = "Rua YY, 21", DataNascimento = new DateTime(1993, 3, 15), Celular = "93333383", Genero = Genero.Feminino, Foto = "foto33.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666966", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 34, FuncionarioId = 34, EnderecoResidencial = "Rua ZZ, 121", DataNascimento = new DateTime(1994, 4, 16), Celular = "922222322", Genero = Genero.Masculino, Foto = "foto34.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "66667477777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 35, FuncionarioId = 35, EnderecoResidencial = "Rua AAA, 21", DataNascimento = new DateTime(1995, 5, 17), Celular = "911111011", Genero = Genero.Masculino, Foto = "foto35.jpg", EstadoCivil = EstadoCivil.Viuvo, CPF = "77778881888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 36, FuncionarioId = 36, EnderecoResidencial = "Rua ABC, 28", DataNascimento = new DateTime(1996, 6, 18), Celular = "900001100", Genero = Genero.Masculino, Foto = "foto36.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88882999999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },

                   new FuncionarioDetalhe { Id = 37, FuncionarioId = 37, EnderecoResidencial = "Rua XYC, 24", DataNascimento = new DateTime(1992, 2, 14), Celular = "944440044", Genero = Genero.Masculino, Foto = "foto37.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "44445555555", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.PosGraduacao },
                   new FuncionarioDetalhe { Id = 38, FuncionarioId = 38, EnderecoResidencial = "Rua YED, 21", DataNascimento = new DateTime(1993, 3, 15), Celular = "933300333", Genero = Genero.Masculino, Foto = "foto38.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "55556666766", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 39, FuncionarioId = 39, EnderecoResidencial = "Rua ZAB, 191", DataNascimento = new DateTime(1994, 4, 16), Celular = "922112222", Genero = Genero.Masculino, Foto = "foto39.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "66367777777", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 40, FuncionarioId = 40, EnderecoResidencial = "Rua AAT, 601", DataNascimento = new DateTime(1995, 5, 17), Celular = "911001111", Genero = Genero.Feminino, Foto = "foto40.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "77778880888", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 41, FuncionarioId = 41, EnderecoResidencial = "Rua ABR, 721", DataNascimento = new DateTime(1996, 6, 18), Celular = "900110000", Genero = Genero.Masculino, Foto = "foto41.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "88889199999", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },

                   new FuncionarioDetalhe { Id = 42, FuncionarioId = 42, EnderecoResidencial = "Rua ACY, 210", DataNascimento = new DateTime(1997, 7, 19), Celular = "988778888", Genero = Genero.Feminino, Foto = "foto42.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000000", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Mestrado },
                   new FuncionarioDetalhe { Id = 43, FuncionarioId = 43, EnderecoResidencial = "Rua ADX, 39", DataNascimento = new DateTime(1998, 7, 19), Celular = "988779888", Genero = Genero.Feminino, Foto = "foto43.jpg", EstadoCivil = EstadoCivil.Casado, CPF = "99990000002", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico },
                   new FuncionarioDetalhe { Id = 44, FuncionarioId = 44, EnderecoResidencial = "Rua AJW, 491", DataNascimento = new DateTime(1998, 11, 9), Celular = "988770866", Genero = Genero.Masculino, Foto = "foto44.jpg", EstadoCivil = EstadoCivil.Divorciado, CPF = "99990700001", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Medio },
                   new FuncionarioDetalhe { Id = 45, FuncionarioId = 45, EnderecoResidencial = "Rua ADT, 501", DataNascimento = new DateTime(1988, 8, 20), Celular = "977776777", Genero = Genero.Masculino, Foto = "foto45.jpg", EstadoCivil = EstadoCivil.Solteiro, CPF = "00001111111", Nacionalidade = "Brasileiro", Escolaridade = Escolaridade.Tecnico }
                   );
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(200);
                entity.Property(e => e.Orcamento).HasColumnType("decimal(20,2)");

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
                       Status = StatusProjeto.Andamento
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
                       Status = StatusProjeto.Andamento
                   }
                );
            });

            modelBuilder.Entity<FuncionarioProjeto>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioId, e.ProjetoId });

                entity.HasData(
                    // Projeto A  em aprovacao
                    new FuncionarioProjeto { FuncionarioId = 16, ProjetoId = 1, HorasTrabalhadas = 15 },
                    new FuncionarioProjeto { FuncionarioId = 24, ProjetoId = 1, HorasTrabalhadas = 15 },

                    // Projeto B  em revisao
                    new FuncionarioProjeto { FuncionarioId = 18, ProjetoId = 2, HorasTrabalhadas = 20 },
                    new FuncionarioProjeto { FuncionarioId = 22, ProjetoId = 2, HorasTrabalhadas = 25 },

                    // Projeto C  iniciado
                    new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 3, HorasTrabalhadas = 30 },
                    new FuncionarioProjeto { FuncionarioId = 29, ProjetoId = 3, HorasTrabalhadas = 40 },
                    new FuncionarioProjeto { FuncionarioId = 28, ProjetoId = 3, HorasTrabalhadas = 28 },

                    // Projeto D  iniciado
                    new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 4, HorasTrabalhadas = 18 },
                    new FuncionarioProjeto { FuncionarioId = 25, ProjetoId = 4, HorasTrabalhadas = 22 },
                    new FuncionarioProjeto { FuncionarioId = 32, ProjetoId = 4, HorasTrabalhadas = 15 },

                    // Projeto E em andamento
                    new FuncionarioProjeto { FuncionarioId = 21, ProjetoId = 5, HorasTrabalhadas = 30 },
                    new FuncionarioProjeto { FuncionarioId = 20, ProjetoId = 5, HorasTrabalhadas = 27 },
                    new FuncionarioProjeto { FuncionarioId = 33, ProjetoId = 5, HorasTrabalhadas = 42 },
                    new FuncionarioProjeto { FuncionarioId = 34, ProjetoId = 5, HorasTrabalhadas = 40 },
                    new FuncionarioProjeto { FuncionarioId = 35, ProjetoId = 5, HorasTrabalhadas = 38 },
                    new FuncionarioProjeto { FuncionarioId = 36, ProjetoId = 5, HorasTrabalhadas = 42 },
                    new FuncionarioProjeto { FuncionarioId = 38, ProjetoId = 5, HorasTrabalhadas = 20 },

                    // Projeto F  cancelado
                    new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 6, HorasTrabalhadas = 5 },
                    new FuncionarioProjeto { FuncionarioId = 22, ProjetoId = 6, HorasTrabalhadas = 10 },

                    // Projeto G em andamento
                    new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 7, HorasTrabalhadas = 48 },
                    new FuncionarioProjeto { FuncionarioId = 24, ProjetoId = 7, HorasTrabalhadas = 44 },
                    new FuncionarioProjeto { FuncionarioId = 17, ProjetoId = 7, HorasTrabalhadas = 52 },
                    new FuncionarioProjeto { FuncionarioId = 35, ProjetoId = 7, HorasTrabalhadas = 40 },
                    new FuncionarioProjeto { FuncionarioId = 36, ProjetoId = 7, HorasTrabalhadas = 38 },
                    new FuncionarioProjeto { FuncionarioId = 37, ProjetoId = 7, HorasTrabalhadas = 30 },
                    new FuncionarioProjeto { FuncionarioId = 27, ProjetoId = 7, HorasTrabalhadas = 44 },
                    new FuncionarioProjeto { FuncionarioId = 40, ProjetoId = 7, HorasTrabalhadas = 42 }
                );
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => e.Nome);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Nome).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Telefone).HasMaxLength(15);
                //entity.HasQueryFilter(f => f.Ativo);

                entity.HasData(
                   new Cliente { Id = 1, Nome = "Grupo ABroad SA", Email = "abroad@email.com", Telefone = "55-11 9980-0099" },
                   new Cliente { Id = 2, Nome = "Construtora ABC", Email = "abcconstru@email.com", Telefone = "55-31 8957-1022" },
                   new Cliente { Id = 3, Nome = "EduFuture Corp.", Email = "edufuture@email.com", Telefone = "55-11 8750-4422" },
                   new Cliente { Id = 4, Nome = "Tech Innovators Ltda", Email = "innovators@email.com", Telefone = "55-11 9950-9622" },
                   new Cliente { Id = 5, Nome = "Health Solutions Inc.", Email = "healtsolutions@email.com", Telefone = "55-21 9852-9655" }
                );
            });

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
