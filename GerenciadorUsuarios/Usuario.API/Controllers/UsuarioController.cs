using Microsoft.AspNetCore.Mvc;
using Usuario.Application.Interfaces;
using Usuario.DTO.DTO;

namespace UsuariosRegistration.API.Usuarios.Application
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var resultado = _usuarioService.Criar(usuario);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<UsuarioDTO>> ObterTodosUsuarios()
        {
            try
            {
                var resultado = _usuarioService.ObterTodos();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> ObterUsuario(int id)
        {
            try
            {
                var resultado = _usuarioService.Obter(id);
                if (resultado == null)
                    return NotFound();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeletarUsuario(int id)
        {
            try
            {
                var resultado = _usuarioService.Deletar(id);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<bool> AtualizarUsuario([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var resultado = _usuarioService.Atualizar(usuario);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
