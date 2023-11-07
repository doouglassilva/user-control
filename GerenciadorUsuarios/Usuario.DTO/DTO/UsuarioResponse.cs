using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.DTO.DTO
{
    public class UsuarioResponse
    {
        public UsuarioResponse()
        {
            Usuarios = new List<UsuarioDTO>();
        }

        public List<UsuarioDTO> Usuarios { get; set; }
    }
}
