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
            //Fluent API: Ele sobrescreve as configurações feitas por Data Annotations
            //É indicado quando você não quer poluir suas classes de domínio com atributos do data annotations
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).HasMaxLength(200);
            });
            //base.OnModelCreating(modelBuilder);
        }
    }
}
