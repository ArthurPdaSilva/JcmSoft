namespace JcmSoft.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required decimal Preco { get; set; }

    }
}
