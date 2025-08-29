using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JcmSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("jcmsoft");

            //Fluent API: Ele sobrescreve as configurações feitas por Data Annotations
            //É indicado quando você não quer poluir suas classes de domínio com atributos do data annotations
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100);
                //Forçando um tipo: .HasColumnType("varchar(200)");
                entity.Property(e => e.Descricao).HasMaxLength(200);
                //entity.Property(e => e.DataCriacao).HasDefaultValueSql("GETDATE()"); Se nenhum valor for passado, o SQL Server atribui a data atual

                //Adicionando dados iniciais (Seed Data)
                entity.HasData(new Departamento
                {
                    Id = Guid.NewGuid(),
                    Nome = "Departamento de Farmácia",
                    Descricao = "Responsável pelo setor de farmácia"
                });
            });
            //base.OnModelCreating(modelBuilder);

            //Varchar caracteres não especiais e Nvarchar para caracteres especiais
        }
    }
}
