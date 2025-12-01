using System.Text.Json.Serialization;


namespace EduPay.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string RA { get; set; }

        public DateOnly Data_nascimento { get; set; }

        public int Id_matricula { get; set; }

        //Referencia de Navegação para Matricula
        [JsonIgnore]
        public Matricula? Matricula { get; set; }

        [JsonIgnore]
        public List<Pagamento>? Pagamentos { get; set; }
    }
}
