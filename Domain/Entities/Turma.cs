using System.Text.Json.Serialization;

namespace EduPay.Domain.Entities
{
    public class Turma
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Periodo { get; set; }

        
        public int Id_curso { get; set; } //Chave Estrangeira
        [JsonIgnore]
        public Curso? Curso { get; set; } // Referencia de Navegação

        [JsonIgnore]
        public List<Matricula>? Matriculas { get; set; } //Collection

        //public Curso id_curso {get; set; }

    }
}
