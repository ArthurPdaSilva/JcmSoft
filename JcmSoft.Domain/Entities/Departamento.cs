namespace JcmSoft.Domain.Entities
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
