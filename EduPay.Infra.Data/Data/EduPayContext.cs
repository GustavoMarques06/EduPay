using EduPay.Models;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Data
{
    public class EduPayContext : DbContext
    {
        public EduPayContext(DbContextOptions<EduPayContext> options) : base(options) { }

        public DbSet<AlunoDTO> Aluno { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Curso> Curso { get; set; }   
    }
}
