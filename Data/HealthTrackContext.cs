using Microsoft.EntityFrameworkCore;
using HealthTrack.Models;

namespace HealthTrack.Data
{
    public class HealthTrackContext : DbContext
    {
        public HealthTrackContext(DbContextOptions<HealthTrackContext> options) : base(options)
        {
        }

        // DbSets para as tabelas
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a tabela Medicos
            modelBuilder.Entity<Medico>()
                .ToTable("Medicos")
                .HasKey(m => m.Id);

            // Configuração para a tabela Pacientes
            modelBuilder.Entity<Paciente>()
                .ToTable("Pacientes")
                .HasKey(p => p.Id);

            // Configuração para a tabela Consultas e os relacionamentos
            modelBuilder.Entity<Consulta>()
                .ToTable("Consultas")
                .HasKey(c => c.Id);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mapeamento explícito para ignorar criação de tabelas existentes
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
            modelBuilder.Entity<Consulta>().ToTable("Consultas");

            base.OnModelCreating(modelBuilder);
        }
    }
}