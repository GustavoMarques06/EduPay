namespace EduPay.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Status{ get; set; }
        public DateOnly DataMatricula { get; set; }

        public int TurmaId { get; set; }
        public Turma turma { get; set; }
    }
}
