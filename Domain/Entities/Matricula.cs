using System.Text.Json.Serialization;


namespace EduPay.Domain.Entities
{
    public class Matricula
    {
        public int Id { get; set; }

        public bool status { get; set; }

        public DateOnly data_matricula { get; set; }
        
        //Chave Estrangeira de Turma
        public int Id_turma { get; set; }

        //Referência de Navegação para Turma
        public Turma? Turma { get; set; }

        //Coleção de Alunos
        [JsonIgnore]
        public List<Aluno>? Alunos { get; set; }
    }
}
