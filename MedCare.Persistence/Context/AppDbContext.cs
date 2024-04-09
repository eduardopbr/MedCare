using MedCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedCare.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=32259570@info;Database=MedCareBase", b => b.MigrationsAssembly("MedCareAPI"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
    }
}
