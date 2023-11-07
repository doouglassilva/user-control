using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Domain.Entities;

namespace Usuario.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios Criar(Usuarios Usuarios);
        ICollection<Usuarios> ObterTodos();
        Usuarios Obter(int UsuarioId);
        bool Atualizar(Usuarios Usuario);
        bool Deletar(int UsuarioId);
        bool JaExisteUsuarioComEmail(string email);
    }
}
