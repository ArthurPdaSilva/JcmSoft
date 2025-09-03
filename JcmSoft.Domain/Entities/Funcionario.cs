namespace JcmSoft.Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cargo { get; set; }
        //[Column(TypeName = "decimal(10,2)")]
        public required decimal Salario { get; set; }
        public DateOnly DataContratacao { get; set; }

        public int DepartamentoId { get; set; }
        public virtual Departamento? Departamento { get; set; }
        public virtual FuncionarioDetalhe? FuncionarioDetalhe { get; set; }
        //public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
        public virtual ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
    }
}
