using JcmSoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JcmSoft.EFCore.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("string de conexão");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
