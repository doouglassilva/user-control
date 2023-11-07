using Microsoft.AspNetCore.Mvc;
using Usuario.Application.Interfaces;
using Usuario.DTO.DTO;

namespace UsuariosRegistration.API.Usuarios.Application
{
    [Route("usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> Criar([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var resultado = usuarioService.Criar(usuario);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<UsuarioDTO>> ObterTodos()
        {
            try
            {
                var resultado = usuarioService.ObterTodos();

                if (resultado == null || resultado.Count == 0)
                    return NotFound();

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{UsuarioId}")]
        public ActionResult<UsuarioDTO> Obter(int UsuarioId)
        {
            try
            {
                var resultado = usuarioService.Obter(UsuarioId);

                if (resultado == null)
                    return NotFound();

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{UsuarioId}")]
        public ActionResult<bool> Deletar(int UsuarioId)
        {
            try
            {
                var resultado = usuarioService.Deletar(UsuarioId);

                if (!resultado)
                    return NotFound();

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<bool> Atualizar([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var resultado = usuarioService.Atualizar(usuario);

                if (!resultado)
                    return NotFound();

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
