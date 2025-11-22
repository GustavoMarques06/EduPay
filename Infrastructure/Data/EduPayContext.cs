using EduPay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Infrastructure.Data
{
    public class EduPayContext : DbContext
    {
        public EduPayContext(DbContextOptions<EduPayContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
    }
}
