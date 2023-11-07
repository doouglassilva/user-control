using System;
using Usuario.Domain.Enums;

namespace Usuario.Domain.Entities
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual EnumEscolaridade Escolaridade { get; set; }
        
    }
}
