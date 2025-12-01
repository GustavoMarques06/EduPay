namespace EduPay.DTO
{
    public class CursoUpdateDto
    {
        //public int Id { get; private set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public string CursoTipo { get; set; }

        //Campos Exclusivos de Curso Online:
        public int? Modulo { get; set; }
        public DateOnly? DataLancamento { get; set; }
        public string? Plataforma { get; set; }

        //Campos Exclusivos de Curso Presencial:
        public string? Instituicao { get; set; }
        public string? Sala { get; set; }
    }
}
