namespace JcmSoft.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }

        public ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
    }
}
