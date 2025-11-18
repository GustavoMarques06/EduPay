namespace EduPay.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int CursoId { get; set; }
        public Curso curso{ get; set; }
    }
}
