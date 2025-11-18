using System.ComponentModel.DataAnnotations;

namespace EduPay.Models
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Email { get; set; }
        public DateOnly DataNascimento { get; set; }

        public int MatriculaId { get; set; }
        public Matricula matriculas{ get; set; }
    }


}
