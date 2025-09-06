namespace JcmSoft.Domain.Entities
{
    public class DepartamentoDTO
    {
        public int? Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
    }
}
