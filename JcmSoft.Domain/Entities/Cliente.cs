namespace JcmSoft.Domain.Entities
{
    //O modificador partial permite que a classe seja dividida em múltiplos arquivos. E é útil quando a classe é gerada automaticamente por ferramentas, permitindo que os desenvolvedores adicionem funcionalidades sem modificar o arquivo gerado.
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; } = new List<Projeto>();
    }
}
