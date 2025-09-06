//using JcmSoft.Domain.Entities;
//using JcmSoft.EFCore.Context;
//using JcmSoft.EFCore.FuncoesSQL;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.Diagnostics;
//using System.Runtime.Intrinsics.X86;

////using (AppDbContext context = new())
////{
////    context.Database.EnsureDeleted();
////    Console.WriteLine("Criando o banco de dados...");
////    context.Database.EnsureCreated();

////    Console.WriteLine("Criando um departamento...");
////    void CriarDepartamento(AppDbContext context)
////    {
////        var ds = new List<Departamento> {
////        new (){
////            Nome = "Departamento de Vendas",
////            Descricao = "Responsável pelo setor de vendas"
////        },
////        new ()
////        {
////            Nome = "Departamento de Recursos Humanos",
////            Descricao = "Responsável pelo setor de recursos humanos"
////        },
////        new ()
////        {
////            Nome = "Departamento Jurídico",
////            Descricao = "Responsável pelo setor jurídico"
////        }
////    };

////        //context.Departamentos.Add(new()
////        //{
////        //    Nome = "Departamento de Tecnologia",
////        //    Descricao = "Responsável pelo setor de tecnologia"
////        //});

////        context.Departamentos.AddRange(ds);
////        context.SaveChanges();
////    }

////    CriarDepartamento(context);
////    Console.WriteLine("Departamento criado!");

////    Console.WriteLine("Listando os departamentos...");
////    var departamentos = context.Departamentos.ToList();
////    foreach (var d in departamentos)
////    {
////        Console.WriteLine($"Id: {d.Id} | Nome: {d.Nome} | Descrição: {d.Descricao} | Data Criação: {d.DataCriacao}");
////    }

////    Console.WriteLine("Buscando primeiro departamento...");
////    var primeiro = departamentos.OrderBy(d => d.DataCriacao).FirstOrDefault(d => d.Nome != null);
////    if (primeiro != null)
////    {
////        Console.WriteLine($"Id: {primeiro.Id} | Nome: {primeiro.Nome} | Descrição: {primeiro.Descricao} | Data Criação: {primeiro.DataCriacao}");
////    }

////    Console.WriteLine("Pressione ENTER para finalizar...");
////}


////var departamentos = context.Departamentos.ToList();

////var funcionarios = new List<Funcionario>
////{
////    new() {
////        Nome = "João Silva",
////        Cargo = "Analista de Sistemas",
////        Salario = 4500.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
////        DepartamentoId = departamentos[0].Id,
////        Departamento = departamentos[0]
////    },
////    new Funcionario
////    {
////        Nome = "Maria Oliveira",
////        Cargo = "Gerente de Projetos",
////        Salario = 7500.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
////        DepartamentoId = departamentos[1].Id,
////        Departamento = departamentos[1]
////    },
////    new Funcionario
////    {
////        Nome = "Carlos Pereira",
////        Cargo = "Desenvolvedor Full Stack",
////        Salario = 6000.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-1)),
////        DepartamentoId = departamentos[2].Id,
////        Departamento = departamentos[2]
////    }
////};

////context.Funcionarios.AddRange(funcionarios);
////context.SaveChanges();

////context.Database.EnsureDeleted();
////Console.WriteLine("Criando o banco de dados...");
////context.Database.EnsureCreated();
////Console.WriteLine("Banco de dados criado com sucesso!");


////var dp = context.Departamentos.ToList();
////var count = dp.Count();
//////var dp = context.Departamentos; Só vai gerar o sql, mas não executa, A menos que eu itere sobre ele (execução diferida)

////foreach (var d in dp)
////{
////    Console.WriteLine($"Id: {d.Id} | Nome: {d.Nome} | Descrição: {d.Descricao} | Data Criação: {d.DataCriacao}");
////}

////var funcs = context.Funcionarios.Where(f => f.Nome != null && f.Salario > 5000).ToList();
////funcs.ForEach(f => Console.WriteLine($"Id: {f.Id} | Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: {f.Salario} | Data Contratação: {f.DataContratacao} | DepartamentoId: {f.DepartamentoId}"));

////Console.WriteLine("Qual é o seu nome? ");
////var n = Console.ReadLine();
////var f1 = context.Funcionarios.FirstOrDefault(f => f.Nome != null && f.Nome.Contains(n!));
////if (f1 != null)
////{
////    Console.WriteLine($"Bem vindo, {f1.Nome} do cargo {f1.Cargo}");
////}

////Console.WriteLine("Qual é o seu nome? ");
////var n = Console.ReadLine();
////var consulta = $"select * from Funcionarios where Nome = '{n}'";
////var f1 = context.Funcionarios.FromSqlInterpolated($"{consulta}").AsNoTracking().FirstOrDefault(); Evite concatenar strings ou com interpolação, use parâmetros, exemplo: se n for "x' OR '1'='1" ele traz todos os registros
////if (f1 != null)
////{
////    Console.WriteLine($"Bem vindo, {f1.Nome} do cargo {f1.Cargo}");
////}

////var func = context.Funcionarios.OrderBy(f => f.Nome).ThenBy(f => f.Salario).FirstOrDefault(f => f.Nome != null);
////if (func != null)
////{
////    Console.WriteLine($"Id: {func.Id} | Nome: {func.Nome} | Cargo: {func.Cargo} | Salário: {func.Salario} | Data Contratação: {func.DataContratacao} | DepartamentoId: {func.DepartamentoId}");
////}

////Usando take e skip para paginação
////var numeroPagina = 2;
////var tamanhoPagina = 5;
////var funcionarios = context.Funcionarios
////    .AsNoTracking() //Desabilita o rastreamento de mudanças, melhorando a performance em consultas onde não há necessidade de atualizar os dados
////    .OrderBy(f => f.Nome)
////    .Skip((numeroPagina - 1) * tamanhoPagina) //Pula os 2 primeiros
////    .Take(tamanhoPagina) //Pega os próximos 5
////    .ToList();
////funcionarios.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo}"));

////var funcs = Paginar(context.Funcionarios.AsNoTracking().OrderBy(f => f.Nome), 2, 5).ToList();
////funcs.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo}"));

////static IQueryable<T> Paginar<T>(IQueryable<T> query, int numeroPagina, int tamanhoPagina)
////{
////    if (numeroPagina < 1) numeroPagina = 1;
////    if (tamanhoPagina < 1) tamanhoPagina = 10;
////    return query.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina);
////}

////Sempre usar o AsNoTracking em consultas que não irão atualizar os dados, apenas no GET.


////O select transforma o resultado da consulta, trazendo apenas o que é necessário
////Select motivações: reduzir dados desnecessários, melhorar o desempenho e transformar dados.
////var n = new List<int> { 1, 2, 3, 4, 5 };
////var numeros = n.Select(x => x * 10);
////foreach (var numero in numeros)
////{
////    Console.WriteLine(numero);
////}


////var select = context.Funcionarios
////    .AsNoTracking()
////    //.Select(f => new
////    //{
////    //    f.Id,
////    //    f.Nome,
////    //    f.Cargo
////    //})
////    //.Select(f => new FuncionarioDTO { 
////    //    Nome = f.Nome,
////    //    Cargo = f.Cargo
////    //} )
////    .Select(f => new { NomeDoFuncionario = f.Nome, TempoDeServico = DateTime.Now.Year - f.DataContratacao.Year - (DateTime.Now.DayOfYear < f.DataContratacao.DayOfYear ? 1 : 0) }) 
////    .ToList();

////select.ForEach(f => Console.WriteLine($"Nome: {f.NomeDoFuncionario} | Tempo: {f.TempoDeServico} anos"));

////class FuncionarioDTO
////{
////    public string? Nome { get; set; }
////    public string? Cargo { get; set; }
////}

////var groupos = context.Funcionarios
////    .AsNoTracking()
////    .GroupBy(f => f.Departamento)
////    .Select(g => new
////    {
////        Cargo = g.Key,
////        Quantidade = g.Count(),
////        SalarioTotal = g.Sum(f => f.Salario),
////        SalarioMedio = g.Average(f => f.Salario),
////        SalarioMinimo = g.Min(f => f.Salario),
////        SalarioMaximo = g.Max(f => f.Salario)
////    })
////    .ToList();

////groupos.ForEach(g => Console.WriteLine($"Cargo: {g.Cargo} | Quantidade: {g.Quantidade} | Salário Total: {g.SalarioTotal} | Salário Médio: {g.SalarioMedio} | Salário Mínimo: {g.SalarioMinimo} | Salário Máximo: {g.SalarioMaximo}"));


////Agrupamento no lado da memória x Agrupamento no lado do banco de dados
////No lado da memória (IEnumerable) - Trai todos os dados do banco para a memória e depois agrupa com a clausula orderby no sql
////No lado do banco de dados (IQueryable) - Gera o agrupamento no banco de dados, trazendo apenas o resultado final para a memória, melhorando a performance e fazendo grupo com a clausula groupby no sql

////O Eager Loading traz os dados relacionados na mesma consulta, usando o Include e ThenInclude (Famoso join na consulta SQL),
////Quando não usar: se for muito relacionamento pode gerar consultas muito grandes e lentas e se os dados relacionados não forem necessários

////Comparar tempo de execução entre Eager Loading e Lazy Loading
////var startEager = DateTime.Now;
////var funcionariosEager = context.Funcionarios
////    .AsNoTracking()
////    .Include(f => f.Departamento)
////    .Include(f => f.FuncionarioProjetos)
////        .ThenInclude(fp => fp.Projeto)
////    .ToList();
////var endEager = DateTime.Now;
////var durationEager = endEager - startEager;
////Console.WriteLine($"Eager Loading Duration: {durationEager.TotalMilliseconds} ms");

////var startLazy = DateTime.Now;
////var funcionariosLazy = context.Funcionarios
////    .AsNoTracking();
////foreach (var f in funcionariosLazy)
////{
////    Console.WriteLine($"Funcionário: {f.Nome}");
////    Console.WriteLine($"Departamento: {f.Departamento?.Nome}");
////    foreach (var fp in f.FuncionarioProjetos)
////    {
////        Console.WriteLine($"Projeto: {fp.Projeto?.Nome}");
////    }
////}
////var endLazy = DateTime.Now;
////var durationLazy = endLazy - startLazy;
////Console.WriteLine($"Lazy Loading Duration: {durationLazy.TotalMilliseconds} ms");

////O problema de N+1 consultas é um problema de desempenho que ocorre quando uma aplicação faz uma consulta inicial para buscar uma coleção de entidades (1 consulta) e, em seguida, faz consultas adicionais para buscar dados relacionados para cada entidade na coleção (N consultas). Isso resulta em um total de N+1 consultas ao banco de dados, o que pode ser ineficiente e levar a tempos de resposta mais lentos.
////Se resolve com Eager Loading, Select ou Explicit Loading que é quando você carrega explicitamente os dados relacionados usando o método Load() em uma entidade específica, após a consulta inicial. Isso permite que você controle quando os dados relacionados são carregados, evitando o problema de N+1 consultas ao buscar apenas os dados necessários quando necessário.


////Diferenças entre Include e ThenInclude: Include é usado para carregar entidades relacionadas diretamente associadas à entidade principal, enquanto ThenInclude é usado para carregar entidades relacionadas de uma entidade que já foi incluída com Include. ThenInclude permite navegar por múltiplos níveis de relacionamentos, facilitando o carregamento de dados complexos em uma única consulta.

////Para usar Lazy Loading, é necessário instalar o pacote Microsoft.EntityFrameworkCore.Proxies e configurar o contexto para usar proxies. Add o virtual nas entidades e o UseLazyLoadingProxies no OnConfiguring ou no AddDbContext do serviço

////Exibindo os departamentos e seus funcionarios com Lazy Loading (N+1 consultas)
////var departamentoos = context.Departamentos.AsNoTracking().ToList();
////foreach (var d in departamentoos)
////{
////    Console.WriteLine($"Departamento: {d.Nome}");
////    foreach (var f in d.Funcionarios)
////    {
////        Console.WriteLine($"\tFuncionário: {f.Nome}");
////    }
////}

////Exibindo os funcionarios e seus departamentos com Explicit Loading 
////Usar quando não for necessário carregar os dados relacionados em todas as consultas, apenas em algumas situações específicas
////var funcionarios = context.Funcionarios.AsNoTracking().ToList();
////foreach (var f in funcionarios)
////{
////    Console.WriteLine($"Funcionário: {f.Nome}");
////    //Eu quero carregar o departamento do funcionário f
////    context.Entry(f).Reference(f => f.Departamento).Load();
////    //context.Entry(f).Collection(f => f.FuncionarioProjetos).Load(); Carrega a coleção
////    Console.WriteLine($"\tDepartamento: {f.Departamento?.Nome}");
////}

////Os índices são estruturas de dados que melhoram a velocidade das operações de consulta em uma tabela, permitindo acesso rápido aos dados sem precisar escanear toda a tabela.
////Os índices melhoram a performance das consultas, mas podem impactar a performance das operações de escrita (insert, update, delete) e ocupam espaço em disco. Use índices em colunas que são frequentemente usadas em cláusulas WHERE, JOIN ou ORDER BY.
////Os índices garantem a unicidade dos dados em uma coluna ou conjunto de colunas, evitando registros duplicados.
////Desvantagens: consumo de disco, desempenho de escrita e manutenção.

////_context.Database.EnsureDeleted();
////_context.Database.EnsureCreated();

////Console.WriteLine("Pressione algo para iniciar...");
////Console.ReadKey();

////Console.WriteLine("Inserindo 100.000 clientes... Aguarde...");
////var clientes = new List<Cliente>();
////for (int i = 1; i <= 100000; i++)
////{
////    clientes.Add(new Cliente
////    {
////        Nome = $"Cliente {i}",
////        Email = $"cliente{i}@exemplo.com",
////        Telefone = $"(11) 99999-999{i % 10}"
////    });
////}

////_context.Clientes.AddRange(clientes);
////_context.SaveChanges();

////Console.WriteLine("Consulta usando índice (Nome)");
////Console.WriteLine("Buscando cliente com nome = Cliente 50000");
////var nomeBuscado = "Cliente 50000";

////var stopWatch = Stopwatch.StartNew();
////var nomeEncontrado = _context.Clientes.Where(c => c.Nome == nomeBuscado).Select(c => c.Nome).FirstOrDefault();
////stopWatch.Stop();

////if (nomeEncontrado != null)
////{
////    Console.WriteLine($"Cliente encontrado: {nomeEncontrado}");
////    Console.WriteLine($"Tempo gasto: {stopWatch.ElapsedMilliseconds}");
////}
////else
////    Console.WriteLine("Cliente não encontrado");


////Console.WriteLine("Incluindo cliente duplicado por email");
////try
////{
////    _context.Clientes.Add(new Cliente
////    {
////        Nome = "Cliente Duplicado",
////        Email = "cliente1@exemplo.com",
////        Telefone = "(11) 98888-8888"
////    });
////    _context.SaveChanges();
////} catch (Exception ex)
////{
////    Console.WriteLine($"Erro ao inserir cliente duplicado: {ex.Message}");
////}   


////_context.Database.EnsureDeleted();
////_context.Database.EnsureCreated();

////var clientesAtivos = _context.Clientes.ToList();
////clientesAtivos.ForEach(c => Console.WriteLine($"Id: {c.Id} | Nome: {c.Nome} | Email: {c.Email}"));

//////Ignorando o filtro global
////var todosClientes = _context.Clientes.IgnoreQueryFilters().ToList();
////todosClientes.ForEach(c => Console.WriteLine($"Id: {c.Id} | Nome: {c.Nome} | Email: {c.Email}"));

////// Split Queries - Divide uma consulta complexa em várias consultas menores para melhorar a performance e evitar problemas de memória. Diminui as redundâncias e melhora a eficiência.
////var result = _context.Funcionarios
////    .AsNoTracking()
////    .Include(f => f.Departamento)
////    .Include(f => f.FuncionarioProjetos)
////        .ThenInclude(fp => fp.Projeto)
////    //.AsSplitQuery() //Habilita o Split Query e diminui as repetições
////    .ToList();
////result.ForEach(f =>
////{
////    Console.WriteLine($"Funcionário: {f.Nome} | Departamento: {f.Departamento?.Nome}");
////    foreach (var fp in f.FuncionarioProjetos)
////    {
////        Console.WriteLine($"\tProjeto: {fp.Projeto?.Nome}");
////    }
////});


////FromSqlInterpolated: Esse método utiliza interpolação de strings e automaticamente
////parametriza as consultas, protegendo contra injeções de SQL. Ele é a abordagem
////recomendada para construir consultas dinâmicas no EF Core quando há
////necessidade de usar SQL diretamente.

////_context.Database.EnsureDeleted();
////_context.Database.EnsureCreated();


////var novoProduto = new Produto
////{
////    Nome = "Produto Exemplo",
////    Preco = 99.90m
////};
////Console.WriteLine("Estado inicial:" + _context.Entry(novoProduto).State);

////_context.Produtos.Add(novoProduto);
////Console.WriteLine("Após adicionar:" + _context.Entry(novoProduto).State);

////_context.SaveChanges();
////Console.WriteLine("Após salvar:" + _context.Entry(novoProduto).State);

////novoProduto.Preco = 79.90m;
////Console.WriteLine("Após modificar:" + _context.Entry(novoProduto).State);

////_context.SaveChanges();
////Console.WriteLine("Após salvar modificação:" + _context.Entry(novoProduto).State);

////_context.Produtos.Remove(novoProduto);
////Console.WriteLine("Após remover:" + _context.Entry(novoProduto).State);

////_context.SaveChanges();
////Console.WriteLine("Após salvar remoção:" + _context.Entry(novoProduto).State);


////DbContext não permanece ativo por muito tempo, deve ser instanciado e descartado rapidamente
////No exemplo acima se eu ficasse criando e descartando o contexto, o estado da entidade sempre seria Detached, eu teria que setar o estado manualmente: _context.Entry(novoProduto).State = EntityState.Modified; para atualizar o produto
////DBSet representa uma coleção de todas as entidades no contexto, ou que podem ser consultadas a partir do banco de dados, de um determinado tipo. Cada DbSet permite criar, ler, atualizar e excluir operações para a entidade especificada.
////DbContext rastreia as mudanças feitas nas entidades carregadas no contexto, permitindo que o EF Core saiba quais entidades foram adicionadas, modificadas ou removidas, e assim gerar as instruções SQL apropriadas ao chamar SaveChanges().
//// context.Funcionarios.Add ou context.Add (funcionario) - Marca a entidade como Added
////Output inserted faz parte do SQL gerado pelo EF Core para retornar o valor da chave primária gerada automaticamente (como uma coluna de identidade) após a inserção de um novo registro no banco de dados. Isso é útil para obter o valor da chave primária imediatamente após a inserção, sem a necessidade de uma consulta adicional.
//// O método SaveChanges() retorna um int que indica o número de entidades que foram afetadas no banco de dados (inseridas, atualizadas ou deletadas)., 0 se não houver mudanças para salvar e -1 se ocorrer um erro durante a operação de salvamento e também > 0 se tudo ocorrer bem e a quantidade de entidades afetadas for maior que zero.

////Formas de objeter um objeto: Find, FirstOrDefault, SingleOrDefault (lança exceção se encontrar mais de um), LastOrDefault (pode ser ineficiente sem ordenação), Single (lança exceção se não encontrar ou encontrar mais de um), First (lança exceção se não encontrar), Last (lança exceção se não encontrar, pode ser ineficiente sem ordenação)

//// Objeto buscado sem tracking
////var funcionario = context.Funcionarios
////    .AsNoTracking()
////    .FirstOrDefault(f => f.Id == 1);

////funcionario.Nome = "Novo Nome";

////// Não funciona → nada é salvo
////context.SaveChanges();

////Remoção direta usando Only Key (sem buscar o objeto no banco primeiro) é mais eficiente

////O método attach é usado para informar ao DbContext que uma entidade existente deve ser rastreada, mas sem marcar a entidade como modificada. Isso é útil quando você tem uma entidade que já existe no banco de dados e deseja atualizá-la sem fazer uma consulta adicional para buscá-la primeiro. Ao usar attach, o estado da entidade é definido como Unchanged, indicando que a entidade não foi modificada desde que foi anexada ao contexto. Se você fizer alterações na entidade após anexá-la, precisará marcar explicitamente o estado como Modified para que o EF Core saiba que deve atualizar essa entidade no banco de dados ao chamar SaveChanges(). E tbm não add, update ou remove ao dar um saveChanges().

////Objetos obtidos sem ser pelo contexto do EF Core (ex: via API) são considerados Detached ou desconectados.

////var funcionarioDesconectado = new Funcionario
////{
////    Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"), // Id existente no banco de dados
////    Nome = "Nome Atualizado",
////    Cargo = "Cargo Atualizado",
////    Salario = 5500.00m,
////    DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-1)),
////    DepartamentoId = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538") // Id existente no banco de dados
////};

////Atualizando um objeto desconectado: 
////_context.Funcionarios.Update(funcionarioDesconectado); //Marca todo o objeto como modificado
////_context.SaveChanges();
////Ou usando attach
////_context.Funcionarios.Attach(funcionarioDesconectado);
////_context.Entry(funcionarioDesconectado).State = EntityState.Modified;
////_context.Entry(funcionarioDesconectado).Property(f => f.Nome).IsModified = true; //Marca apenas a propriedade Nome como modificada
////Útil para evitar atualizações acidentais de outras propriedades
////Para objetos grandes (ex: tabelas com 50+ colunas, ou muitas atualizações concorrentes), o Attach + IsModified pode trazer ganhos perceptíveis.
////O maior benefício não é performance bruta, mas segurança contra update acidental: você garante que só o campo alterado vai para o banco.
////_context.SaveChanges();

////Operações grandes: AddRange, UpdateRange, RemoveRange
////Agora, se forem muitos objetos (bulk operations), o EF Core não é a melhor ferramenta, use ferramentas específicas como EFCore.BulkExtensions ou Dapper para operações em massa.

////Uma alternativa para o updateRange é usar o ExecuteUpdate, que faz a atualização diretamente no banco sem carregar os objetos para a memória
////O updateRange é bom quando as entidades não estão rastreadas, porém ele gera sql para cada entidade (O remove range também) , já o ExecuteUpdate gera um único sql para todas as entidades que atendem ao filtro
////Usando attach em lote:
////var funcionariosParaAtualizar = new List<Funcionario>
////{
////    new Funcionario
////    {
////        Id = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
////        Nome = "Nome Atualizado 1",
////        Cargo = "Cargo Atualizado 1",
////        Salario = 6000.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
////    },
////    new Funcionario
////    {
////        Id = Guid.Parse("e290f1ee-6c54-4b01-90e6-d701748f0852"),
////        Nome = "Nome Atualizado 2",
////        Cargo = "Cargo Atualizado 2",
////        Salario = 6500.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
////    }
////};

////_context.Funcionarios.AttachRange(funcionariosParaAtualizar);
////foreach (var func in funcionariosParaAtualizar)
////{
////    _context.Entry(func).Property(f => f.Nome).IsModified = true;
////    _context.Entry(func).Property(f => f.Cargo).IsModified = true;
////}
////_context.SaveChanges();
////🔹 Em resumo

////AddRange: só precisa marcar todas como Added → gera INSERTs em lote, simples.

////UpdateRange/RemoveRange: precisam olhar chave primária e/ou propriedades modificadas de cada entidade → acabam virando “um update/delete por entidade

////As melhores abordagens seria o ExecuteUpdate/ExecuteDelete (quando possível) ou usar ferramentas específicas para operações em massa (bulk operations) como EFCore.BulkExtensions ou Dapper.
////Esses métodos não são rastreados pelo DbContext, ou seja, o estado das entidades não é monitorado. Isso pode ser vantajoso para operações em massa, pois reduz a sobrecarga de rastreamento de mudanças e melhora a performance.
////Eles não precisa do SaveChanges() para aplicar as mudanças, pois executam diretamente no banco de dados.
////Esses métodos não suportam navegação de propriedades relacionadas, ou seja, não é possível atualizar ou deletar entidades relacionadas em uma única chamada. Cada operação deve ser feita separadamente.
////_context.Funcionarios
////    .Where(f => f.Salario < 5000)
////    .ExecuteUpdate(f => f.SetProperty(func => func.Salario, func => func.Salario + 500)); //Aumenta 500 no salário de todos os funcionários com salário menor que 5000
//////ExecuteDelete não use se ouver eventos de remoção (como cascata ou lógica de negócio), pois eles não serão disparados. E se precisar de validação ou lógica de negócio, use o RemoveRange após buscar os objetos.
////_context.Funcionarios
////    .Where(f => f.Salario < 4000)
////    .ExecuteDelete(); //Deleta todos os funcionários com salário menor que 4000
////Oo ExecuteUpdate não atualiza as propriedades de navegação, apenas as propriedades escalares diretas da entidade alvo. Se precisar atualizar propriedades de navegação, deve carregar as entidades e atualizá-las manualmente.
////_context.Database.EnsureDeleted();

////Scaffolding - Gerar o modelo a partir do banco de dados existente
////Scaffold-DbContext "Data Source=name;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context AppDbContext

////Alternativas para aplicar migração em Produção
//// --idempotent --output migrations-prod.sql
////1- Validação do script (pré-produção): Gere o script SQL da migração usando o comando dotnet ef migrations script e revise o script para garantir que ele esteja correto e não cause perda de dados. Depois, aplique o script manualmente no banco de dados de produção.
////2 - Faça uma pull request e backups
////3 - Pós Execução: valide a integridade dos dados (smoke tests)


////Método FromSqlRaw: Esse método permite executar consultas SQL brutas diretamente no banco de dados. Ele é útil quando você precisa executar consultas complexas que não podem ser facilmente expressas usando LINQ ou quando você deseja aproveitar recursos específicos do banco de dados que não são suportados pelo EF Core. No entanto, ao usar FromSqlRaw, você deve ter cuidado para evitar injeções de SQL, pois ele não parametriza automaticamente as consultas. Certifique-se de usar parâmetros para qualquer entrada do usuário para proteger contra ataques de injeção de SQL.

////var departamentoId = 0;
////var funcionarios = _context.Funcionarios
////    .FromSqlRaw("SELECT * FROM Funcionarios WHERE DepartamentoId = {0}", departamentoId)
////    .Include(f => f.Departamento)
////    .ToList();
////funcionarios.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Departamento: {f.Departamento?.Nome}"));

////Método FromSql: Esse método é semelhante ao FromSqlRaw, mas ele utiliza interpolação de strings e automaticamente parametriza as consultas, protegendo contra injeções de SQL. Ele é a abordagem recomendada para construir consultas dinâmicas no EF Core quando há necessidade de usar SQL diretamente.
////var funcionarios2 = _context.Funcionarios
////    //A mudança é apenas na interpolação da string
////    .FromSql($"SELECT * FROM Funcionarios WHERE DepartamentoId = {departamentoId}") //Para versões mais antigas do EF Core use FromSqlInterpolated
////    .Include(f => f.Departamento)
////    .ToList();
////funcionarios2.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Departamento: {f.Departamento?.Nome}"));

////SqlQuery: Esse método é usado para executar consultas SQL brutas que retornam tipos que não são entidades rastreadas pelo DbContext. Ele é útil quando você deseja executar consultas que retornam tipos anônimos ou tipos definidos pelo usuário que não estão mapeados como entidades no modelo do EF Core. Ao usar SqlQuery, você deve garantir que o tipo retornado corresponda à estrutura dos dados retornados pela consulta SQL. Além disso, assim como com FromSqlRaw, você deve tomar cuidado para evitar injeções de SQL, utilizando parâmetros para qualquer entrada do usuário. Ele não suporta carregamento de propriedades de navegação, pois não retorna entidades rastreadas pelo contexto.



////Diferença entre Join e Inner Join: Ambos são usados para combinar registros de duas ou mais tabelas com base em uma condição relacionada. A diferença principal é que o Join (ou Left Join) retorna todos os registros da tabela à esquerda, mesmo que não haja correspondência na tabela à direita, preenchendo com NULL onde não houver correspondência. Já o Inner Join retorna apenas os registros que têm correspondência em ambas as tabelas, excluindo aqueles que não possuem correspondência.


////public class FuncionarioSalarioDTO
////{
////    public string? Nome { get; set; }
////    public decimal Salario { get; set; }
////    public string Cargo { get; set; }
////    public string Departamento { get; set; }
////}

////var funcionarios3 = _context.Database.SqlQuery<FuncionarioSalarioDTO>($@"SELECT f.Nome, f.Salario, f.Cargo, d.Nome AS Departamento FROM Funcionarios f INNER JOIN Departamentos d ON f.DepartamentoId = d.Id ORDER BY f.Salario DESC").ToList();
////funcionarios3.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Salário: {f.Salario} | Cargo: {f.Cargo} | Departamento: {f.Departamento}"));


////Se o tipo retornado for um primitivo, a consulta precisará conter o VALUE
////var totalSalario = await _context.Database.SqlQuery<decimal>($@"SELECT SUM(Salario) AS VALUE FROM Funcionarios where DepartamentoId = {departamentoId}").FirstOrDefaultAsync(); //Esse método é async pq pode ser uma consulta longa
////Console.WriteLine(totalSalario);
////Muito bom em procedimentos armazenados ou views;

////Stored Procedures (Procedimentos Armazenados) são conjuntos de comandos SQL pré-compilados e armazenados no banco de dados. Eles podem ser executados para realizar operações específicas, como consultas, inserções, atualizações ou exclusões de dados. Os Stored Procedures são úteis para encapsular lógica de negócios complexa, melhorar a performance ao reduzir o tráfego entre a aplicação e o banco de dados, e aumentar a segurança ao controlar o acesso aos dados.
////No SQL Server, eles estão dentro da pasta Programmability > Stored Procedures
////Comandos exec <nome_procedimento> @parametro1 = valor1, @parametro2 = valor2...;
////exec ObterFuncionariosPorDepartamento @DepartamentoId = 1;
////No dbeaver fica na pasta Procedures
////exec JcmSoftDatabase.sys.sp_help 'Funcionarios'
////exec JcmSoftDatabase.sys.sp_tables
////Use prefixos como usp_, use o bloco begin end e evite lógica complexa dentro do procedimento, prefira chamar outras procedures ou funções
////CREATE PROCEDURE usp_ListarFuncionariosPorDepartamento
////	@DepartamentoId int
////AS
////BEGIN
////	SELECT Nome, Cargo, Salario FROM Funcionarios WHERE DepartamentoId = @DepartamentoId
////END
////USE[JcmSoftDatabase]
////Exec usp_ListarFuncionariosPorDepartamento 2

////while (departamentoId != -1)
////{
////    Console.WriteLine("Digite o Id do departamento para listar os funcionários (ou -1 para sair): ");
////    departamentoId = int.Parse(Console.ReadLine()!);
////    if (departamentoId == -1) break;
////    //É interessante usar await, pois pode ser uma consulta longa
////    var funcionarios4 = await _context.Database.SqlQuery<FuncionarioSalarioDTO>($@"EXEC usp_ListarFuncionariosPorDepartamento @DepartamentoId = {departamentoId}").ToListAsync();
////    funcionarios4.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: {f.Salario}"));
////    Console.WriteLine();
////}
////public record FuncionarioSalarioDTO(string Nome, string Cargo, decimal Salario);


////Alterando uma Stored Procedure
////ALTER PROCEDURE usp_ListarFuncionariosPorDepartamento
////	@DepartamentoId int
////AS
////BEGIN
////	SELECT FuncionarioId, Nome, Cargo, Salario, DataContratacao, DepartamentoId FROM Funcionarios WHERE DepartamentoId = @DepartamentoId
////END

////--CREATE PROCEDURE usp_FuncionariosContratadosPorPeriodo 
////--	@DataInicio DATE,
////--	@DataFim DATE
////--AS
////--BEGIN
////--	SELECT 
////--		f.Id, f.Nome, f.Cargo,
////--		f.Salario, f.DataContratacao, f.DepartamentoId
////--	FROM Funcionarios f
////--	WHERE f.DataContratacao 
////--	BETWEEN @DataInicio AND @DataFim
////--	ORDER BY f.DataContratacao 
////--END
////--EXEC sp_rename 'usp_FUncionariosContratadosPorPeriodo', 'usp_FuncionariosContratadosPorPeriodo'
////--exec usp_FuncionariosContratadosPorPeriodo
////--@DataInicio = '2023-01-01', @DataFim = '2023-12-31';

////--drop procedure usp_FuncionariosContratadosPorPeriodo;


////Usando SqlParameter para evitar injeção de SQL
////var funcionarios5 = await _context.Funcionarios.FromSqlRaw(
////    "EXEC usp_ListarFuncionariosPorDepartamento @DepartamentoId", new SqlParameter("@DepartamentoId", 2)
////    ).ToListAsync();


////Renomeando uma Stored Procedure
////EXEC sp_rename 'usp_ListarFuncionariosPorDepartamento', 'usp_ObterFuncionariosPorDepartamento' //Sem dbo


////Criando via migrations:
////Crie e teste no DBeaver. Depois apague com o drop procedure e por fim copie e cole na migration
////Ao criar a procedure via migration não precisa mais usar o exec, apenas o nome da procedure, pois o EF Core já entende que é uma procedure
////var parametros = new[]
////{
////new SqlParameter("@DataInicio", new DateTime(2023, 1, 1)),
////new SqlParameter("@DataFim", new DateTime(2023, 12, 31))
////};
////var funcionarios6 = await _context.Funcionarios.FromSqlRaw("usp_FuncionariosContratadosPorPeriodo @DataInicio, @DataFim", parametros).ToListAsync();
////funcionarios6.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo} | Data Contratação: {f.DataContratacao}"));

////using var _context = new AppDbContext();

////Uma view é uma tabela virtual baseada no resultado de uma consulta SQL. Ela pode combinar dados de uma ou mais tabelas e apresentar esses dados como se fossem uma única tabela. As views são úteis para simplificar consultas complexas, encapsular lógica de negócios e melhorar a segurança ao restringir o acesso direto às tabelas subjacentes.
////É como se fosse um filtro ou uma janela para os dados, ela não ocupa espaço extra.

////Servem para simplificar consultas complexas, encapsular lógica de negócios, melhorar a segurança e fornecer uma camada de abstração entre a aplicação e o banco de dados.
////Em alguns casos podem melhorar a performance, especialmente quando usadas com índices, mas não substituem otimizações de consultas e índices nas tabelas base.

////View x Stored Procedure:
////View: Representa uma tabela virtual baseada em uma consulta SQL. Ela pode ser usada em consultas SELECT como se fosse uma tabela real, mas não pode aceitar parâmetros. As views são úteis para simplificar consultas complexas e fornecer uma camada de abstração.
////Stored Procedure: É um conjunto de comandos SQL pré-compilados que podem aceitar parâmetros e realizar operações complexas, incluindo consultas, inserções, atualizações e exclusões. As stored procedures são úteis para encapsular lógica de negócios e melhorar a performance ao reduzir o tráfego entre a aplicação e o banco de dados.
////View não tem lógica condicional ou loopings, mas stored procedures podem ter.

////Create view view_FunciSlario as select Nome, Salario from Funcionarios 
////Para fazer uma view atualizavel ela deve ser baseada em uma única tabela, incluir todas as colunas NOT NULL, não usar agregações, joins, subconsultas, distinct, group by, having, union, funções de janela ou colunas calculadas.
////Para deletar a view: drop view view_FunciSlario

////create view view_funcinariosDepartamentos as
////select
////	f.Id as FuncionarioId, d.Id as DepartamentoId ,
////    f.Nome as NomeFuncionario,
////    d.Nome as NomeDepartamento,
////    d.Descricao as DescricaoDepartamento,
////    f.Cargo, f.Salario, f.DataContratacao
////from 
////	Funcionarios f
////Inner join
////	Departamentos d on f.DepartamentoId = d.Id;

////select* from view_funcinariosDepartamentos;

////drop view view_funcinariosDepartamentos;

////Criando a view via migration, mesmo esquema de procedure
////A diferença é q eu posso mapear a view como uma entidade no EF Core

////var result = await _context.FuncionarioDepartamentoViews.OrderBy(f => f.Salario).ToListAsync(); //Posso usar também o FromSql e o FromSqlRaw
////result.ForEach(f => Console.WriteLine($"Nome: {f.NomeFuncionario} | Departamento: {f.NomeDepartamento} | Cargo: {f.Cargo} | Salário: {f.Salario}"));

////Da para chamar sem mapeamento também:
////É bom quando não quer poluir o domínio com muitas entidades
////var funcionarios7 = await _context.Database.SqlQuery<FuncionarioDepartamentoDTO>($@"SELECT * FROM view_funcinariosDepartamentos ORDER BY Salario").ToListAsync();
////public record FuncionarioDepartamentoDTO
////{
////    public Guid FuncionarioId { get; set; }
////    public Guid DepartamentoId { get; set; }
////    public string NomeFuncionario { get; set; }
////    public string NomeDepartamento { get; set; }
////    public string DescricaoDepartamento { get; set; }
////    public string Cargo { get; set; }
////    public decimal Salario { get; set; }
////    public DateOnly DataContratacao { get; set; }
////}

////Não é recomendado mapear a view para uma entidade: 
////-Views são somentes leituras e não suportam operações de escrita (insert, update, delete).
////Mistura responsabilidades, a view é só projeção de dados, não deve ter lógica de negócio.
////Fere princípios de design como SRP (Single Responsibility Principle).
////Complica manutenção e evolução do modelo de domínio.

////Funções escalares são funções que retornam um único valor (ex: int, string, decimal) e podem ser usadas em consultas SQL, cláusulas WHERE, SELECT, ORDER BY, etc. Elas são úteis para cálculos simples, formatações ou transformações de dados.
////Ficam dentro da pasta Procedures no Dbeaver
////São apenas leitura, não podem modificar dados no banco.
////Exem: Calcular Quantos anos de serviço
////CREATE FUNCTION dbo.CalcularAnosDeServico (@DataContratacao DATE)
////RETURNS INT
////AS 
////BEGIN
////	RETURN DATEDIFF(YEAR, @DataContratacao, GETDATE())
////END

////var funcionarios8 = await _context.Funcionarios
////    .AsNoTracking()
////    .Select(f => new
////    {
////        f.Nome,
////        f.Cargo,
////        f.Salario,
////        AnosDeServico = FuncoesSQL.CalcularAnosDeServico(f.DataContratacao)//Para funções escalares uso o SqlQuery
////    })
////    .OrderByDescending(f => f.AnosDeServico)
////    .ToListAsync();
////funcionarios8.ForEach(f => Console.WriteLine($"Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: {f.Salario} | Anos de Serviço: {f.AnosDeServico}"));

////Parecido com funções escalares, também temos as funções de tabela que retornam um conjunto de resultados (tabela) e podem ser usadas em consultas SQL como se fossem tabelas reais. Elas são úteis para encapsular consultas complexas que retornam múltiplas linhas e colunas.
////CREATE FUNCTION dbo.ProjetosAtivosApos (@dataInicio Date)
////RETURNS TABLE
////AS 
////RETURN (
////	SELECT Id, Nome, Descricao, Orcamento, DataInicio, DataAtualizacao, DataFim, Status, ClienteId 
////	FROM Projetos 
////	Where DataInicio > @dataInicio
////		And Status in (10, 20) -- Iniciado e EmAndamento
////)
////SELECT * from ProjetosAtivosApos('2023-01-01');

////IQueryable representa uma consulta que pode ser executada contra uma fonte de dados, como um banco de dados. Ele permite construir consultas de forma dinâmica e adiar a execução até que os dados sejam realmente necessários. IQueryable é usado principalmente para consultas LINQ que serão traduzidas para SQL e executadas no banco de dados.
////var projetosAtivos = await _context.ProjetosAtivosApos(new DateTime(2023, 1, 1)).OrderBy(p => p.DataInicio).ToListAsync();
////projetosAtivos.ForEach(p => Console.WriteLine($"Nome: {p.Nome} | Data Início: {p.DataInicio} | Status: {p.Status}"));

////Funções Escalares X Funções de Tabela
////Funções Escalares: Retornam um único valor (ex: int, string, decimal). Usadas para cálculos simples, formatações ou transformações de dados. Ex: Calcular idade, formatar strings.
////Funções de Tabela: Retornam um conjunto de resultados (tabela). Usadas para encapsular consultas complexas que retornam múltiplas linhas e colunas. Ex: Obter todos os projetos ativos após uma data específica.
////Representação no C#: Funções Escalares são chamadas diretamente em consultas LINQ, enquanto Funções de Tabela são mapeadas como DbSet ou métodos que retornam IQueryable.
////Corpo do método: Funções Escalares tem o throw new NotImplementedException();, enquanto Funções de Tabela => FromExpression(() => ...).
////Quem pode retornar um tipo anônimo? Funções de Tabela podem retornar tipos anônimos, Funções Escalares não podem.
////Recomendação: Use Funções Escalares para operações simples que retornam um único valor. Use Funções de Tabela para consultas complexas que retornam múltiplas linhas e colunas. Ou substituir views por funções de tabela quando precisar de parâmetros.

////Sequências são objetos de banco de dados que geram uma sequência numérica única e ordenada. Elas são usadas principalmente para gerar valores para chaves primárias ou outras colunas que requerem valores únicos. As sequências são independentes das tabelas, o que significa que podem ser compartilhadas entre várias tabelas ou usadas para outros propósitos além de chaves primárias.
////São Transacionais, ou seja, se uma transação falhar, o valor gerado pela sequência não será revertido. Isso pode resultar em lacunas na sequência de valores.


////Computed Columns (Colunas Computadas) são colunas em uma tabela de banco de dados cujo valor é derivado de uma expressão ou cálculo baseado em outras colunas da mesma tabela. Elas são úteis para armazenar resultados de cálculos que precisam ser frequentemente acessados, sem a necessidade de recalcular o valor toda vez que a coluna é consultada. As colunas computadas podem ser persistentes (armazenadas fisicamente no banco de dados) ou não persistentes (calculadas dinamicamente quando consultadas).
////Persistentes são indicadas quando se quer melhor desempenho e não quando o desempenho não for crítico e o espaço em disco for uma preocupação.


////var projetos = await _context.Projetos
////    .AsNoTracking()
////    .OrderBy(p => p.DataInicio)
////    .ToListAsync();

////projetos.ForEach(p => Console.WriteLine($"Nome: {p.Nome} | Data Início: {p.DataInicio} | Data Fim: {p.DataFim} | Status: {p.Status} | Duração (dias): {p.DuracaoEmDias}"));

////As Transações são work flow que envolvem uma ou mais operações de banco de dados que devem ser executadas como uma única unidade de trabalho. Elas garantem que todas as operações dentro da transação sejam concluídas com sucesso ou, em caso de falha, revertidas para o estado anterior, mantendo a integridade dos dados.
////Transações são usadas para garantir que um conjunto de operações de banco de dados sejam executadas de forma atômica, ou seja, todas as operações são concluídas com sucesso ou nenhuma delas é aplicada. Isso é crucial para manter a integridade dos dados, especialmente em cenários onde múltiplas operações dependem umas das outras. Se uma operação falhar, a transação pode ser revertida (rollback), garantindo que o banco de dados permaneça em um estado consistente
////Se uma falhar, todas falham. Ele lança um rollback automático

////Tipos de Transações:
////Implícitas: O EF Core gerencia automaticamente as transações para operações individuais de SaveChanges(). Cada chamada a SaveChanges() é envolvida em uma transação implícita.
////O EFCOre só cria transação se houver mais de uma operação de escrita (insert, update, delete) no SaveChanges()

////Transações Explícitas: O desenvolvedor controla o início, commit ou rollback
////Isso é útil quando múltiplas operações de banco de dados precisam ser agrupadas em uma única transação, ou quando se deseja ter controle total sobre o escopo da transação.
////Lidamos com multiplos bancos de dados
////Comandos no EFCore:
//// IDBContextTransaction BeginTransaction(); // Inicia uma nova transação
//// void Commit // Confirma
//// void Rollback // Reverte
//// Dispose // Libera recursos

////using var transaction = await _context.Database.BeginTransactionAsync();
////try
////{
////    var novoDepartamento = new Departamento
////    {
////        Nome = "Departamento de TI",
////        Descricao = "Responsável por toda a infraestrutura tecnológica da empresa",
////        DataCriacao = DateTime.Now
////    };
////    _context.Departamentos.Add(novoDepartamento);
////    await _context.SaveChangesAsync();
////    var novoFuncionario = new Funcionario
////    {
////        Nome = "João Silva",
////        Cargo = "Desenvolvedor",
////        Salario = 6000.00m,
////        DataContratacao = DateOnly.FromDateTime(DateTime.Now),
////        DepartamentoId = novoDepartamento.Id
////    };
////    _context.Funcionarios.Add(novoFuncionario);
////    await _context.SaveChangesAsync();

////    // Simulando um erro para testar o rollback
////    //int x = 0;
////    //int y = 1 / x;

////    await transaction.CommitAsync();
////    Console.WriteLine("Transação concluída com sucesso.");
////}
////catch (Exception ex)
////{
////    await transaction.RollbackAsync();
////    Console.WriteLine($"Erro na transação: {ex.Message}");
////}


////Conflitos de concorrência:
////Exemplo: Dois usuários tentam atualizar o mesmo registro ao mesmo tempo. O primeiro usuário salva suas alterações, e quando o segundo usuário tenta salvar, ele recebe um erro de conflito de concorrência.
////Last in wins: A última alteração salva sobrescreve as alterações anteriores sem aviso. Isso pode levar à perda de dados se não for gerenciado corretamente.


////var funcId = 1;

//////User A carrega o funcionário
////var _contextA = new AppDbContext();
////var funcionarioA = await _contextA.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcId);

//////User B carrega o mesmo funcionário
////var _contextB = new AppDbContext();
////var funcionarioB = await _contextB.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcId);

//////User A atualiza o salário e salva
////funcionarioA.Salario += 500;
////await _contextA.SaveChangesAsync();

//////User B atualiza o salário e tenta salvar
////funcionarioB.Salario += 1300;

//////Tratando
////try
////{
////    await _contextB.SaveChangesAsync();

////}
////catch (DbUpdateConcurrencyException ex)
////{
////    Console.WriteLine("Conflito de concorrência detectado. Atualizando os dados...");
////    //Obtém os valores atuais do banco
////    foreach (var entry in ex.Entries)
////    {
////        if (entry.Entity is Funcionario)
////        {
////            var originalValues = entry.OriginalValues; //Valores originais quando o user B carregou o objeto
////            var proposedValues = entry.CurrentValues; //Valores que o user B tentou salvar
////            var databaseValues = await entry.GetDatabaseValuesAsync(); //Valores atuais do banco
////            Console.WriteLine($"Valores Originais: Salário = {originalValues["Salario"]}");
////            Console.WriteLine($"Valores Propostos: Salário = {proposedValues["Salario"]}");
////            Console.WriteLine($"Valores no Banco: Salário = {databaseValues["Salario"]}");

////            //Estratégias de resolução:
////            //-Abortar a operação (já feito com a exceção)
////            //-Sobrescrever os dados do banco com os valores propostos (Last in wins)
////            //-Fazer merge manual
////            //-Recarregar os dados no banco


////            //A mais segura é não continuar e avisar o usuário
////        }
////    }
////}


//////Salário Final será o de B:
////var _finalContext = new AppDbContext();
////var funcionarioFinal = await _finalContext.Funcionarios.FirstOrDefaultAsync(f => f.Id == funcId);
////Console.WriteLine($"Salário final do funcionário {funcionarioFinal.Nome}: {funcionarioFinal.Salario}");


////Tratando concorrência:
////Por Campo: (otimista) via propriedade 
////Data Annotations: [ConcurrencyCheck] ou IsCurrencyToken() via Fluent API (Ele adicionaria um And no Where: exp: .Where(f => f.Id == funcId && f.UltimaAtualizacao == valorOriginal)
////Por Tabela (otimista) via token de concurrência
//// - Otimista: Assume que conflitos são raros e permite
//// - Pessimista: Bloqueia o registro para evitar conflitos (ex: SELECT ... FOR UPDATE no SQL) Dar lock no momento de leitura até dar um saveChanges(). Pode causar deadlocks e reduzir a concorrência.
//// -- Timestamp (obsoleto no SQL Server, use rowversion): Coluna especial que armazena um valor binário único que é atualizado automaticamente toda vez que a linha é modificada. No EF Core, mapeie a propriedade com [Timestamp] ou IsRowVersion() via Fluent API. O EF Core verifica o valor do rowversion durante o SaveChanges() para detectar conflitos.
//// -- RowVersion: Similar ao Timestamp, mas é o nome mais moderno e recomendado. Funciona da mesma forma, armazenando um valor binário que é atualizado automaticamente. Use [Timestamp] ou IsRowVersion() via Fluent API.

////int dpId = 1;
////Departamento dpA;
////Departamento dpB;

////using (var contextA = new AppDbContext())
////{
////    dpA = await contextA.Departamentos.FirstOrDefaultAsync(d => d.Id == dpId);

////}

////using (var contextB = new AppDbContext())
////{
////    dpB = await contextB.Departamentos.FirstOrDefaultAsync(d => d.Id == dpId);
////}

////using (var contextA = new AppDbContext())
////{
////    dpA.Nome = "Novo Nome - A";
////    contextA.Departamentos.Update(dpA);
////    await contextA.SaveChangesAsync();
////    Console.WriteLine("Departamento atualizado por A");
////}

////using (var contextB = new AppDbContext())
////{
////    dpB.Nome = "Novo Nome - B";
////    contextB.Departamentos.Update(dpB);
////    try
////    {
////        await contextB.SaveChangesAsync();
////        Console.WriteLine("Departamento atualizado por B");
////    }
////    catch (DbUpdateConcurrencyException ex)
////    {
////        Console.WriteLine("Conflito de concorrência detectado para o departamento. Atualizando os dados...");
////        foreach (var entry in ex.Entries)
////        {
////            if (entry.Entity is Departamento)
////            {
////                var originalValues = entry.OriginalValues;
////                var proposedValues = entry.CurrentValues;
////                var databaseValues = await entry.GetDatabaseValuesAsync();
////                entry.OriginalValues.SetValues(databaseValues); //Atualiza os valores originais na memória com os do banco, assim sincroniza as entidades
////                Console.WriteLine("Dados recarregados. Por favor, revise as alterações antes de salvar novamente.");
////            }
////        }
////    }
////}


////Concorrência Pessimista:
////Durante a leitura, o registro é bloqueado para outras transações até que a transação atual seja concluída (commit ou rollback).
////Possíveis problemas: timeout ou deadlock
////O banco precisa suportar lock
////UpdLock = bloqueia para update, XLock = bloqueia para leitura e escrita, HoldLock = mantém o lock até o final da transação

//int clienteId = 1;

//async Task UsuarioA()
//{
//    using var contextA = new AppDbContext();
//    contextA.Database.SetCommandTimeout(30); 
//    using var transactionA = await contextA.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);
//    try
//    {
//        var allClientes = await contextA.Clientes.ToListAsync();
//        var clienteA = await contextA.Clientes.FromSqlRaw("SELECT * FROM Clientes WITH (UPDLOCK, HOLDLOCK) WHERE Id = {0}", clienteId).FirstOrDefaultAsync();
//        Console.WriteLine($"Usuário A carregou o cliente: {clienteA.Nome}");
//        //Simula um tempo de edição
//        await Task.Delay(10000);
//        clienteA.Nome = "Cliente Atualizado por A";
//        await contextA.SaveChangesAsync();
//        await transactionA.CommitAsync();
//        Console.WriteLine("Usuário A salvou as alterações.");
//    }
//    catch (Exception ex)
//    {
//        await transactionA.RollbackAsync();
//        Console.WriteLine($"Erro na transação do Usuário A: {ex.Message}");
//    }
//}

//async Task UsuarioB()
//{
//    using var contextB = new AppDbContext();
//    contextB.Database.SetCommandTimeout(5);
//    using var transactionB = await contextB.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);
//    try
//    {
//        var clienteB = await contextB.Clientes.Where(c => c.Id == clienteId).FirstOrDefaultAsync();
//        Console.WriteLine($"Usuário A carregou o cliente: {clienteB.Nome}");
//        //Simula um tempo de edição
//        await Task.Delay(10000);
//        clienteB.Nome = "Cliente Atualizado por B";
//        await contextB.SaveChangesAsync();
//        await transactionB.CommitAsync();
//        Console.WriteLine("Usuário A salvou as alterações.");
//    }
//    catch (Exception ex)
//    {
//        await transactionB.RollbackAsync();
//        Console.WriteLine($"Erro na transação do Usuário B: {ex.Message}");
//    }
//}

////Serve para simular dois usuários concorrentes
//await Task.WhenAll(UsuarioA(), UsuarioB());


//Falar que algo é idempotente significa que ele sempre retornará o mesmo resultado