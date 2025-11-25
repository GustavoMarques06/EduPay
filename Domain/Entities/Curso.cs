using System.Text.Json.Serialization;

namespace EduPay.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        [JsonIgnore]
        public List<Turma>? turmas { get; set; }//Collection navigation propriety
    }
}
