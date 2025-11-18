using EduPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPay.Application.Mappings
{
    public class AlunoDTO
    {
        public static AlunoDTO ConvertToDTO(Aluno aluno)
        {
            return new AlunoDTO
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                RA = aluno.RA,
                Email = aluno.Email,
                DataNascimento = aluno.DataNascimento,
                MatriculaId = aluno.MatriculaId,
                matriculas = aluno.matriculas
            };
        }
    }
}
