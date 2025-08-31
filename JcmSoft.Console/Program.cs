using JcmSoft.EFCore.Context;

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

using (AppDbContext context = new())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados...");
    context.Database.EnsureCreated();
    Console.WriteLine("Banco de dados criado com sucesso!");

}