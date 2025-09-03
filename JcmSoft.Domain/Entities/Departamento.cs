namespace JcmSoft.Domain.Entities
{
    public class Departamento
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required DateTime DataCriacao { get; set; }
        //public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
    }
}
