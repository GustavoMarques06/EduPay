using System.Security.Cryptography.Pkcs;

namespace EduPay.Domain.Entities
{
    public class CursoPresencial : Curso
    {
        public string Instituicao { get; set; }
        public string Sala { get; set; }
    }
}
