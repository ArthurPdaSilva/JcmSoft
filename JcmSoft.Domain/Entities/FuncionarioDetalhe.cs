using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities
{
    public class FuncionarioDetalhe
    {
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "O campo Nome é obrigatório")]
        //[MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public required string Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Foto { get; set; }
        public string? Nacionalidade { get; set; }
        public string? CPF { get; set; }

        public Genero Genero { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public EstadoCivil EstadoCivil { get; set; }

        public DateTime DataNascimento { get; set; }
        public Guid FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
    }
}
