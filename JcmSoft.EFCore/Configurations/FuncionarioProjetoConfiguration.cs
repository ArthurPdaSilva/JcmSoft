using JcmSoft.Domain.Entities;
using JcmSoft.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class FuncionarioProjetoConfiguration : IEntityTypeConfiguration<FuncionarioProjeto>
    {
        public void Configure(EntityTypeBuilder<FuncionarioProjeto> entity)
        {
            entity.HasKey(e => new { e.FuncionarioId, e.ProjetoId });

            entity.HasData(
                // Projeto A  em aprovacao
                new FuncionarioProjeto { FuncionarioId = 16, ProjetoId = 1, HorasTrabalhadas = 15 },
                new FuncionarioProjeto { FuncionarioId = 24, ProjetoId = 1, HorasTrabalhadas = 15 },

                // Projeto B  em revisao
                new FuncionarioProjeto { FuncionarioId = 18, ProjetoId = 2, HorasTrabalhadas = 20 },
                new FuncionarioProjeto { FuncionarioId = 22, ProjetoId = 2, HorasTrabalhadas = 25 },

                // Projeto C  iniciado
                new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 3, HorasTrabalhadas = 30 },
                new FuncionarioProjeto { FuncionarioId = 29, ProjetoId = 3, HorasTrabalhadas = 40 },
                new FuncionarioProjeto { FuncionarioId = 28, ProjetoId = 3, HorasTrabalhadas = 28 },

                // Projeto D  iniciado
                new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 4, HorasTrabalhadas = 18 },
                new FuncionarioProjeto { FuncionarioId = 25, ProjetoId = 4, HorasTrabalhadas = 22 },
                new FuncionarioProjeto { FuncionarioId = 32, ProjetoId = 4, HorasTrabalhadas = 15 },

                // Projeto E em andamento
                new FuncionarioProjeto { FuncionarioId = 21, ProjetoId = 5, HorasTrabalhadas = 30 },
                new FuncionarioProjeto { FuncionarioId = 20, ProjetoId = 5, HorasTrabalhadas = 27 },
                new FuncionarioProjeto { FuncionarioId = 33, ProjetoId = 5, HorasTrabalhadas = 42 },
                new FuncionarioProjeto { FuncionarioId = 34, ProjetoId = 5, HorasTrabalhadas = 40 },
                new FuncionarioProjeto { FuncionarioId = 35, ProjetoId = 5, HorasTrabalhadas = 38 },
                new FuncionarioProjeto { FuncionarioId = 36, ProjetoId = 5, HorasTrabalhadas = 42 },
                new FuncionarioProjeto { FuncionarioId = 38, ProjetoId = 5, HorasTrabalhadas = 20 },

                // Projeto F  cancelado
                new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 6, HorasTrabalhadas = 5 },
                new FuncionarioProjeto { FuncionarioId = 22, ProjetoId = 6, HorasTrabalhadas = 10 },

                // Projeto G em andamento
                new FuncionarioProjeto { FuncionarioId = 19, ProjetoId = 7, HorasTrabalhadas = 48 },
                new FuncionarioProjeto { FuncionarioId = 24, ProjetoId = 7, HorasTrabalhadas = 44 },
                new FuncionarioProjeto { FuncionarioId = 17, ProjetoId = 7, HorasTrabalhadas = 52 },
                new FuncionarioProjeto { FuncionarioId = 35, ProjetoId = 7, HorasTrabalhadas = 40 },
                new FuncionarioProjeto { FuncionarioId = 36, ProjetoId = 7, HorasTrabalhadas = 38 },
                new FuncionarioProjeto { FuncionarioId = 37, ProjetoId = 7, HorasTrabalhadas = 30 },
                new FuncionarioProjeto { FuncionarioId = 27, ProjetoId = 7, HorasTrabalhadas = 44 },
                new FuncionarioProjeto { FuncionarioId = 40, ProjetoId = 7, HorasTrabalhadas = 42 }
            );
        }
    }
}
