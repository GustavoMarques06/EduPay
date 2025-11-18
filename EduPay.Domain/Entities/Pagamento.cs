namespace EduPay.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public Guid CodigoTransacao { get; set; } = Guid.NewGuid();
        public double Valor { get; set; }
        public DateOnly DataPagamento { get; set; }


        public int AlunoId { get; set; }
        public AlunoDTO alunos{ get; set; }

        public int MatriculaId { get; set; }
        public Matricula matricula{ get; set; }
    }
}
