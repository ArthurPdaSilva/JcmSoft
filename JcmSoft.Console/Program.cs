using JcmSoft.Domain.Entities;
using JcmSoft.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

//using (AppDbContext context = new())
//{
//    context.Database.EnsureDeleted();
//    Console.WriteLine("Criando o banco de dados...");
//    context.Database.EnsureCreated();

//    Console.WriteLine("Criando um departamento...");
//    void CriarDepartamento(AppDbContext context)
//    {
//        var ds = new List<Departamento> {
//        new (){
//            Nome = "Departamento de Vendas",
//            Descricao = "Responsável pelo setor de vendas"
//        },
//        new ()
//        {
//            Nome = "Departamento de Recursos Humanos",
//            Descricao = "Responsável pelo setor de recursos humanos"
//        },
//        new ()
//        {
//            Nome = "Departamento Jurídico",
//            Descricao = "Responsável pelo setor jurídico"
//        }
//    };

//        //context.Departamentos.Add(new()
//        //{
//        //    Nome = "Departamento de Tecnologia",
//        //    Descricao = "Responsável pelo setor de tecnologia"
//        //});

//        context.Departamentos.AddRange(ds);
//        context.SaveChanges();
//    }

//    CriarDepartamento(context);
//    Console.WriteLine("Departamento criado!");

//    Console.WriteLine("Listando os departamentos...");
//    var departamentos = context.Departamentos.ToList();
//    foreach (var d in departamentos)
//    {
//        Console.WriteLine($"Id: {d.Id} | Nome: {d.Nome} | Descrição: {d.Descricao} | Data Criação: {d.DataCriacao}");
//    }

//    Console.WriteLine("Buscando primeiro departamento...");
//    var primeiro = departamentos.OrderBy(d => d.DataCriacao).FirstOrDefault(d => d.Nome != null);
//    if (primeiro != null)
//    {
//        Console.WriteLine($"Id: {primeiro.Id} | Nome: {primeiro.Nome} | Descrição: {primeiro.Descricao} | Data Criação: {primeiro.DataCriacao}");
//    }

//    Console.WriteLine("Pressione ENTER para finalizar...");
//}


//var departamentos = context.Departamentos.ToList();

//var funcionarios = new List<Funcionario>
//{
//    new() {
//        Nome = "João Silva",
//        Cargo = "Analista de Sistemas",
//        Salario = 4500.00m,
//        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
//        DepartamentoId = departamentos[0].Id,
//        Departamento = departamentos[0]
//    },
//    new Funcionario
//    {
//        Nome = "Maria Oliveira",
//        Cargo = "Gerente de Projetos",
//        Salario = 7500.00m,
//        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
//        DepartamentoId = departamentos[1].Id,
//        Departamento = departamentos[1]
//    },
//    new Funcionario
//    {
//        Nome = "Carlos Pereira",
//        Cargo = "Desenvolvedor Full Stack",
//        Salario = 6000.00m,
//        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-1)),
//        DepartamentoId = departamentos[2].Id,
//        Departamento = departamentos[2]
//    }
//};

//context.Funcionarios.AddRange(funcionarios);
//context.SaveChanges();

//context.Database.EnsureDeleted();
//Console.WriteLine("Criando o banco de dados...");
//context.Database.EnsureCreated();
//Console.WriteLine("Banco de dados criado com sucesso!");


//var dp = context.Departamentos.ToList();
//var count = dp.Count();
////var dp = context.Departamentos; Só vai gerar o sql, mas não executa, A menos que eu itere sobre ele (execução diferida)

//foreach (var d in dp)
//{
//    Console.WriteLine($"Id: {d.Id} | Nome: {d.Nome} | Descrição: {d.Descricao} | Data Criação: {d.DataCriacao}");
//}

//var funcs = context.Funcionarios.Where(f => f.Nome != null && f.Salario > 5000).ToList();
//funcs.ForEach(f => Console.WriteLine($"Id: {f.Id} | Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: {f.Salario} | Data Contratação: {f.DataContratacao} | DepartamentoId: {f.DepartamentoId}"));

//Console.WriteLine("Qual é o seu nome? ");
//var n = Console.ReadLine();
//var f1 = context.Funcionarios.FirstOrDefault(f => f.Nome != null && f.Nome.Contains(n!));
//if (f1 != null)
//{
//    Console.WriteLine($"Bem vindo, {f1.Nome} do cargo {f1.Cargo}");
//}

//Console.WriteLine("Qual é o seu nome? ");
//var n = Console.ReadLine();
//var consulta = $"select * from Funcionarios where Nome = '{n}'";
//var f1 = context.Funcionarios.FromSqlInterpolated($"{consulta}").AsNoTracking().FirstOrDefault(); Evite concatenar strings ou com interpolação, use parâmetros, exemplo: se n for "x' OR '1'='1" ele traz todos os registros
//if (f1 != null)
//{
//    Console.WriteLine($"Bem vindo, {f1.Nome} do cargo {f1.Cargo}");
//}

//var func = context.Funcionarios.OrderBy(f => f.Nome).ThenBy(f => f.Salario).FirstOrDefault(f => f.Nome != null);
//if (func != null)
//{
//    Console.WriteLine($"Id: {func.Id} | Nome: {func.Nome} | Cargo: {func.Cargo} | Salário: {func.Salario} | Data Contratação: {func.DataContratacao} | DepartamentoId: {func.DepartamentoId}");
//}

//Usando take e skip para paginação
//var numeroPagina = 2;
//var tamanhoPagina = 5;
//var funcionarios = context.Funcionarios
//    .AsNoTracking() //Desabilita o rastreamento de mudanças, melhorando a performance em consultas onde não há necessidade de atualizar os dados
//    .OrderBy(f => f.Nome)
//    .Skip((numeroPagina - 1) * tamanhoPagina) //Pula os 2 primeiros
//    .Take(tamanhoPagina) //Pega os próximos 5
//    .ToList();
//funcionarios.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo}"));

//var funcs = Paginar(context.Funcionarios.AsNoTracking().OrderBy(f => f.Nome), 2, 5).ToList();
//funcs.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo}"));

//static IQueryable<T> Paginar<T>(IQueryable<T> query, int numeroPagina, int tamanhoPagina)
//{
//    if (numeroPagina < 1) numeroPagina = 1;
//    if (tamanhoPagina < 1) tamanhoPagina = 10;
//    return query.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina);
//}

//Sempre usar o AsNoTracking em consultas que não irão atualizar os dados, apenas no GET.


//O select transforma o resultado da consulta, trazendo apenas o que é necessário
//Select motivações: reduzir dados desnecessários, melhorar o desempenho e transformar dados.
//var n = new List<int> { 1, 2, 3, 4, 5 };
//var numeros = n.Select(x => x * 10);
//foreach (var numero in numeros)
//{
//    Console.WriteLine(numero);
//}


//var select = context.Funcionarios
//    .AsNoTracking()
//    //.Select(f => new
//    //{
//    //    f.Id,
//    //    f.Nome,
//    //    f.Cargo
//    //})
//    //.Select(f => new FuncionarioDTO { 
//    //    Nome = f.Nome,
//    //    Cargo = f.Cargo
//    //} )
//    .Select(f => new { NomeDoFuncionario = f.Nome, TempoDeServico = DateTime.Now.Year - f.DataContratacao.Year - (DateTime.Now.DayOfYear < f.DataContratacao.DayOfYear ? 1 : 0) }) 
//    .ToList();

//select.ForEach(f => Console.WriteLine($"Nome: {f.NomeDoFuncionario} | Tempo: {f.TempoDeServico} anos"));

//class FuncionarioDTO
//{
//    public string? Nome { get; set; }
//    public string? Cargo { get; set; }
//}

//var groupos = context.Funcionarios
//    .AsNoTracking()
//    .GroupBy(f => f.Departamento)
//    .Select(g => new
//    {
//        Cargo = g.Key,
//        Quantidade = g.Count(),
//        SalarioTotal = g.Sum(f => f.Salario),
//        SalarioMedio = g.Average(f => f.Salario),
//        SalarioMinimo = g.Min(f => f.Salario),
//        SalarioMaximo = g.Max(f => f.Salario)
//    })
//    .ToList();

//groupos.ForEach(g => Console.WriteLine($"Cargo: {g.Cargo} | Quantidade: {g.Quantidade} | Salário Total: {g.SalarioTotal} | Salário Médio: {g.SalarioMedio} | Salário Mínimo: {g.SalarioMinimo} | Salário Máximo: {g.SalarioMaximo}"));


//Agrupamento no lado da memória x Agrupamento no lado do banco de dados
//No lado da memória (IEnumerable) - Trai todos os dados do banco para a memória e depois agrupa com a clausula orderby no sql
//No lado do banco de dados (IQueryable) - Gera o agrupamento no banco de dados, trazendo apenas o resultado final para a memória, melhorando a performance e fazendo grupo com a clausula groupby no sql

//O Eager Loading traz os dados relacionados na mesma consulta, usando o Include e ThenInclude (Famoso join na consulta SQL),
//Quando não usar: se for muito relacionamento pode gerar consultas muito grandes e lentas e se os dados relacionados não forem necessários

//Comparar tempo de execução entre Eager Loading e Lazy Loading
//var startEager = DateTime.Now;
//var funcionariosEager = context.Funcionarios
//    .AsNoTracking()
//    .Include(f => f.Departamento)
//    .Include(f => f.FuncionarioProjetos)
//        .ThenInclude(fp => fp.Projeto)
//    .ToList();
//var endEager = DateTime.Now;
//var durationEager = endEager - startEager;
//Console.WriteLine($"Eager Loading Duration: {durationEager.TotalMilliseconds} ms");

//var startLazy = DateTime.Now;
//var funcionariosLazy = context.Funcionarios
//    .AsNoTracking();
//foreach (var f in funcionariosLazy)
//{
//    Console.WriteLine($"Funcionário: {f.Nome}");
//    Console.WriteLine($"Departamento: {f.Departamento?.Nome}");
//    foreach (var fp in f.FuncionarioProjetos)
//    {
//        Console.WriteLine($"Projeto: {fp.Projeto?.Nome}");
//    }
//}
//var endLazy = DateTime.Now;
//var durationLazy = endLazy - startLazy;
//Console.WriteLine($"Lazy Loading Duration: {durationLazy.TotalMilliseconds} ms");

//O problema de N+1 consultas é um problema de desempenho que ocorre quando uma aplicação faz uma consulta inicial para buscar uma coleção de entidades (1 consulta) e, em seguida, faz consultas adicionais para buscar dados relacionados para cada entidade na coleção (N consultas). Isso resulta em um total de N+1 consultas ao banco de dados, o que pode ser ineficiente e levar a tempos de resposta mais lentos.
//Se resolve com Eager Loading, Select ou Explicit Loading que é quando você carrega explicitamente os dados relacionados usando o método Load() em uma entidade específica, após a consulta inicial. Isso permite que você controle quando os dados relacionados são carregados, evitando o problema de N+1 consultas ao buscar apenas os dados necessários quando necessário.


//Diferenças entre Include e ThenInclude: Include é usado para carregar entidades relacionadas diretamente associadas à entidade principal, enquanto ThenInclude é usado para carregar entidades relacionadas de uma entidade que já foi incluída com Include. ThenInclude permite navegar por múltiplos níveis de relacionamentos, facilitando o carregamento de dados complexos em uma única consulta.

//Para usar Lazy Loading, é necessário instalar o pacote Microsoft.EntityFrameworkCore.Proxies e configurar o contexto para usar proxies. Add o virtual nas entidades e o UseLazyLoadingProxies no OnConfiguring ou no AddDbContext do serviço

//Exibindo os departamentos e seus funcionarios com Lazy Loading (N+1 consultas)
//var departamentoos = context.Departamentos.AsNoTracking().ToList();
//foreach (var d in departamentoos)
//{
//    Console.WriteLine($"Departamento: {d.Nome}");
//    foreach (var f in d.Funcionarios)
//    {
//        Console.WriteLine($"\tFuncionário: {f.Nome}");
//    }
//}

//Exibindo os funcionarios e seus departamentos com Explicit Loading 
//Usar quando não for necessário carregar os dados relacionados em todas as consultas, apenas em algumas situações específicas
//var funcionarios = context.Funcionarios.AsNoTracking().ToList();
//foreach (var f in funcionarios)
//{
//    Console.WriteLine($"Funcionário: {f.Nome}");
//    //Eu quero carregar o departamento do funcionário f
//    context.Entry(f).Reference(f => f.Departamento).Load();
//    //context.Entry(f).Collection(f => f.FuncionarioProjetos).Load(); Carrega a coleção
//    Console.WriteLine($"\tDepartamento: {f.Departamento?.Nome}");
//}

//Os índices são estruturas de dados que melhoram a velocidade das operações de consulta em uma tabela, permitindo acesso rápido aos dados sem precisar escanear toda a tabela.
//Os índices melhoram a performance das consultas, mas podem impactar a performance das operações de escrita (insert, update, delete) e ocupam espaço em disco. Use índices em colunas que são frequentemente usadas em cláusulas WHERE, JOIN ou ORDER BY.
//Os índices garantem a unicidade dos dados em uma coluna ou conjunto de colunas, evitando registros duplicados.
//Desvantagens: consumo de disco, desempenho de escrita e manutenção.

//_context.Database.EnsureDeleted();
//_context.Database.EnsureCreated();

//Console.WriteLine("Pressione algo para iniciar...");
//Console.ReadKey();

//Console.WriteLine("Inserindo 100.000 clientes... Aguarde...");
//var clientes = new List<Cliente>();
//for (int i = 1; i <= 100000; i++)
//{
//    clientes.Add(new Cliente
//    {
//        Nome = $"Cliente {i}",
//        Email = $"cliente{i}@exemplo.com",
//        Telefone = $"(11) 99999-999{i % 10}"
//    });
//}

//_context.Clientes.AddRange(clientes);
//_context.SaveChanges();

//Console.WriteLine("Consulta usando índice (Nome)");
//Console.WriteLine("Buscando cliente com nome = Cliente 50000");
//var nomeBuscado = "Cliente 50000";

//var stopWatch = Stopwatch.StartNew();
//var nomeEncontrado = _context.Clientes.Where(c => c.Nome == nomeBuscado).Select(c => c.Nome).FirstOrDefault();
//stopWatch.Stop();

//if (nomeEncontrado != null)
//{
//    Console.WriteLine($"Cliente encontrado: {nomeEncontrado}");
//    Console.WriteLine($"Tempo gasto: {stopWatch.ElapsedMilliseconds}");
//}
//else
//    Console.WriteLine("Cliente não encontrado");


//Console.WriteLine("Incluindo cliente duplicado por email");
//try
//{
//    _context.Clientes.Add(new Cliente
//    {
//        Nome = "Cliente Duplicado",
//        Email = "cliente1@exemplo.com",
//        Telefone = "(11) 98888-8888"
//    });
//    _context.SaveChanges();
//} catch (Exception ex)
//{
//    Console.WriteLine($"Erro ao inserir cliente duplicado: {ex.Message}");
//}   


//_context.Database.EnsureDeleted();
//_context.Database.EnsureCreated();

//var clientesAtivos = _context.Clientes.ToList();
//clientesAtivos.ForEach(c => Console.WriteLine($"Id: {c.Id} | Nome: {c.Nome} | Email: {c.Email}"));

////Ignorando o filtro global
//var todosClientes = _context.Clientes.IgnoreQueryFilters().ToList();
//todosClientes.ForEach(c => Console.WriteLine($"Id: {c.Id} | Nome: {c.Nome} | Email: {c.Email}"));

using var _context = new AppDbContext();
// Split Queries - Divide uma consulta complexa em várias consultas menores para melhorar a performance e evitar problemas de memória. Diminui as redundâncias e melhora a eficiência.
var result = _context.Funcionarios
    .AsNoTracking()
    .Include(f => f.Departamento)
    .Include(f => f.FuncionarioProjetos)
        .ThenInclude(fp => fp.Projeto)
    //.AsSplitQuery() //Habilita o Split Query e diminui as repetições
    .ToList();
result.ForEach(f =>
{
    Console.WriteLine($"Funcionário: {f.Nome} | Departamento: {f.Departamento?.Nome}");
    foreach (var fp in f.FuncionarioProjetos)
    {
        Console.WriteLine($"\tProjeto: {fp.Projeto?.Nome}");
    }
});


//FromSqlInterpolated: Esse método utiliza interpolação de strings e automaticamente
//parametriza as consultas, protegendo contra injeções de SQL. Ele é a abordagem
//recomendada para construir consultas dinâmicas no EF Core quando há
//necessidade de usar SQL diretamente.