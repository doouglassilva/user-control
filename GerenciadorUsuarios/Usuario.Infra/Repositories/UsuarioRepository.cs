using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Entities;
using Usuario.Domain.Interfaces;
using Usuario.Infrastructure.Context;

namespace Usuario.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuarios Criar(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public ICollection<Usuarios> ObterTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuarios Obter(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
        }

        public bool Atualizar(Usuarios usuario)
        {
            var existingUser = _context.Usuarios.Local.FirstOrDefault(u => u.Id == usuario.Id);

            if (existingUser != null)
            {
                AtualizarEntidadeExistente(existingUser, usuario);
            }
            else
            {
                _context.Entry(usuario).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return true;
        }

        public bool Deletar(int usuarioId)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool JaExisteUsuarioComEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }

        private void AtualizarEntidadeExistente(Usuarios existingUser, Usuarios newUser)
        {
            _context.Entry(existingUser).CurrentValues.SetValues(newUser);
        }
    }
}
