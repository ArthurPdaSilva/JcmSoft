namespace JcmSoft.Domain.Entities
{
    public class FuncionarioProjeto
    {
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; } = null!;
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; } = null!;
        public int HorasTrabalhadas { get; set; }
    }
}
