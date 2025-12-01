namespace EduPay.Domain.Entities
{
    public class CursoOnline : Curso
    {
        public int Modulo { get; set; }
        public DateOnly DataLancamento { get; set; }
        public string Plataforma { get; set; }
    }
}
