using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Orcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime DataAtualizacao { get; set; } 
        public StatusProjeto Status { get; set; }

        //public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
