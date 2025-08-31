namespace JcmSoft.Domain.Entities
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Cargo { get; set; }
        //[Column(TypeName = "decimal(10,2)")]
        public required decimal Salario { get; set; }
        public required DateOnly DataContratacao { get; set; }

        public Guid DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public FuncionarioDetalhe? FuncionarioDetalhe { get; set; }
        //public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
        public ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
    }
}
