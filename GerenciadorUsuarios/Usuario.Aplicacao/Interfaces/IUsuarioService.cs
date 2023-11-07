using Usuario.DTO.DTO;

namespace Usuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDTO Criar(UsuarioDTO UsuarioDTO);
        List<UsuarioDTO> ObterTodos();
        UsuarioDTO Obter(int UsuarioId);
        bool Deletar(int UsuarioId);
        bool Atualizar(UsuarioDTO Usuario);
    }
}
