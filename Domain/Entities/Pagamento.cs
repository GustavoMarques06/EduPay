using System.Text.Json.Serialization;



namespace EduPay.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; private set; }

        public Guid? Cod_transacao { get; private set; } = Guid.NewGuid();

        public double Valor { get; set; }

        public DateOnly Data_pagamento { get; set; }

        //Chave Estrangeira para Aluno
        public int Id_aluno { get; set; }

        [JsonIgnore]
        public Aluno? Aluno { get; set; }

        //Chave Estrangeira para Matricula
        public int Id_matricula { get; set; }

        [JsonIgnore]
        public Matricula? Matricula { get; set; }


        
    }
}
