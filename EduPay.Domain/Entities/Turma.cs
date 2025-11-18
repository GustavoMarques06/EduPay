namespace EduPay.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Periodo { get; set; }

        public int CursoId { get; set; }
        public Curso curso{ get; set; }


    }
}
