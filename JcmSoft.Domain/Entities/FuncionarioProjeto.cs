namespace JcmSoft.Domain.Entities
{
    public class FuncionarioProjeto
    {
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; } = null!;
        public Guid ProjetoId { get; set; }
        public Projeto Projeto { get; set; } = null!;
        public int HorasTrabalhadas { get; set; }
    }
}
