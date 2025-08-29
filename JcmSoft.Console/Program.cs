using JcmSoft.EFCore.Context;

using (AppDbContext context = new())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados.... \n");
    context.Database.EnsureCreated();

    Console.WriteLine("Criando um departamento \n");
    CriarDepartamento(context);
    Console.WriteLine("Departamento criado \n");
}

Console.ReadKey();

void CriarDepartamento(AppDbContext context)
{
    context.Departamentos.Add(new()
    {
        Nome = "Departamento de Vendas",
        Descricao = "Responsável pelo setor de vendas"
    });
    context.SaveChanges();
}
