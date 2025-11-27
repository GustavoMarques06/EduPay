namespace EduPay.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }

        public string Cod_transacao { get; set; }

        public double? Valor { get; set; }

        public DateOnly Data_pagamento { get; set; }

        //Chave Estrangeira para Aluno
        public int Id_aluno { get; set; }
        public Aluno Aluno { get; set; }

        //Chave Estrangeira para Matricula
        public int Id_matricula { get; set; }
        public Matricula Matricula { get; set; }



    }
}
