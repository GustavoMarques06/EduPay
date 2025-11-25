using EduPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Data
{
    public class EduPayContext : DbContext
    {
        public EduPayContext(DbContextOptions<EduPayContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasMany(c => c.turmas)
                .WithOne(t => t.Curso)
                .HasForeignKey(t => t.Id_curso)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Matriculas)
                .WithOne(m => m.Turma)
                .HasForeignKey(m => m.Id_turma)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Matricula>()
                .HasMany(m => m.Alunos)
                .WithOne(a => a.Matricula)
                .HasForeignKey(a => a.Id_matricula)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
