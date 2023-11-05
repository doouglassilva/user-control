using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControl.Domain.Enums;

namespace UserControl.Domain.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
        string Email { get; set; }
        DateTime DataNascimento { get; set; }
        Education Escolaridade { get; set; }
    }
}
