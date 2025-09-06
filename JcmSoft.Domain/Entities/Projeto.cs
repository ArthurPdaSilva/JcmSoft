using JcmSoft.Domain.Entities.Enums;

namespace JcmSoft.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required decimal Orcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime DataAtualizacao { get; set; } 
        public StatusProjeto Status { get; set; }

        //public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        public virtual ICollection<FuncionarioProjeto> FuncionarioProjetos { get; set; } = new List<FuncionarioProjeto>();
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        //Valor para Sequencial (int, long ou decimal)
        public int NumeroOrdemServico { get; set; }
        //O private set é usado para garantir que a propriedade só possa ser modificada dentro da própria classe, promovendo encapsulamento e controle sobre como o valor é alterado. 
        public int DuracaoEmDias { get; private set; }
    }
}
