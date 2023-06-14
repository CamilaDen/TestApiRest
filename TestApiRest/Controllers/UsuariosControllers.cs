using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Services;
using TestApiRest.Services.Interfaces;


namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosControllers : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosControllers(IUsuarioService usuariosService)
        {
            _usuarioService = usuariosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> GetAllUsuarios()
        {
            try
            {
                var listaUsuarios = await _usuarioService.GetAllUsuario();
                return Ok(listaUsuarios);

            }
            catch (ExceptionMessage ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);

            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> CreateUsuario(UsuarioDTO usuarioDTO)
        {
            var nuevoUsuario = await _usuarioService.CreateUsuario(usuarioDTO);
            return StatusCode(201, nuevoUsuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id,[FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                await _usuarioService.UpdateUsuario(id, usuarioDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}

