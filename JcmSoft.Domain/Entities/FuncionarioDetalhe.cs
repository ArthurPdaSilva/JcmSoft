using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities
{
    public class FuncionarioDetalhe
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "O campo Nome é obrigatório")]
        //[MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public required string Celular { get; set; }
        public string? EnderecoResidencial { get; set; }
        public required string Foto { get; set; }
        public required string Nacionalidade { get; set; }
        public required string CPF { get; set; }

        public required Genero Genero { get; set; }
        public required Escolaridade Escolaridade { get; set; }
        public required EstadoCivil EstadoCivil { get; set; }

        public DateTime DataNascimento { get; set; }
        public int FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
    }
}
