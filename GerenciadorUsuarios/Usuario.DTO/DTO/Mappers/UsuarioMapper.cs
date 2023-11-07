using AutoMapper;
using Usuario.Domain.Entities;

namespace Usuario.DTO.DTO.Mappers
{
    public class UsuarioMapper
    {
        private static readonly IMapper _mapper;

        static UsuarioMapper()
        {
            var configuracao = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuarios, UsuarioDTO>();
                cfg.CreateMap<UsuarioDTO, Usuarios>();
            });

            _mapper = configuracao.CreateMapper();
        }

        public static List<UsuarioDTO> ListaUsuariosParaRespostaUsuario(IEnumerable<Usuarios> usuarios)
        {
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public static UsuarioDTO UsuarioParaUsuarioDTO(Usuarios usuario)
        {
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public static Usuarios UsuarioDTOParaUsuario(UsuarioDTO usuarioDTO)
        {
            return _mapper.Map<Usuarios>(usuarioDTO);
        }
    }
}
