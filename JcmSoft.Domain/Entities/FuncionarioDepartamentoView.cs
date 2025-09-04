namespace JcmSoft.Domain.Entities
{
    public class FuncionarioDepartamentoView
    {
        public int FuncionarioId { get; set; }
        public int DepartamentoId { get; set; }
        public required string NomeFuncionario { get; set; }
        public required string NomeDepartamento { get; set; }
        public required string DescricaoDepartamento { get; set; }
        public required string Cargo { get; set; }
        public required decimal Salario { get; set; }
        public required DateOnly DataContratacao { get; set; }
    }
}
