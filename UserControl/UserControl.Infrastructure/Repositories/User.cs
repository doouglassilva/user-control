using System;
using UserControl.Domain.Enums;
using UserControl.Domain.Interfaces;

namespace UserControl.Infrastructure.Persistence
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Education Escolaridade { get; set; }
    }
}
