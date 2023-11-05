using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Enums;

namespace UserControl.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Education Escolaridade { get; set; }
    }
}
