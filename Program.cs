
using EduPay.Application.Interface;
using EduPay.Application.Service;
using EduPay.Infrastructure.Data;
using EduPay.Infrastructure.Interface;
using EduPay.Infrastructure.Repositories;
using EduPay.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduPay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<EduPayContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddScoped(typeof(IEduPayGenericRepository<>), typeof(EduPayGenericRepository<>));
            
            //Escopos para Curso.
            builder.Services.AddScoped<CursoService>();
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<ICursoRepository, CursoRepository>();

            //Escopos para Turma.
            builder.Services.AddScoped<TurmaService>();
            builder.Services.AddScoped<ITurmaService, TurmaService>();
            builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();

            //Escopos para Matricula
            builder.Services.AddScoped<MatriculaService>();
            builder.Services.AddScoped<IMatriculaService, MatriculaService>();
            builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
