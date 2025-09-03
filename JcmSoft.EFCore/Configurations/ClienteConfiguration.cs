using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JcmSoft.EFCore.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.HasIndex(e => e.Nome);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Telefone).HasMaxLength(15);
            entity.HasQueryFilter(f => f.Ativo);

            entity.HasData(
               new Cliente { Id = 1, Nome = "Grupo ABroad SA", Email = "abroad@email.com", Telefone = "55-11 9980-0099" },
               new Cliente { Id = 2, Nome = "Construtora ABC", Email = "abcconstru@email.com", Telefone = "55-31 8957-1022" },
               new Cliente { Id = 3, Nome = "EduFuture Corp.", Email = "edufuture@email.com", Telefone = "55-11 8750-4422" },
               new Cliente { Id = 4, Nome = "Tech Innovators Ltda", Email = "innovators@email.com", Telefone = "55-11 9950-9622" },
               new Cliente { Id = 5, Nome = "Health Solutions Inc.", Email = "healtsolutions@email.com", Telefone = "55-21 9852-9655" }
            );
        }
    }
}
