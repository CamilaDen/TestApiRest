using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TestApiRest.DTO_s;
using TestApiRest.Services;
using TestApiRest.Services.Interfaces;

namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService service;

        public LibrosController(ILibroService service)
        {
            this.service = service;
        }

        [HttpGet]   
        public async Task<ActionResult<List<LibroDTO>>> GetAllLibros()
        {
            var listaLibros = await service.GetAllLibros();

            if (listaLibros == null)
                return NotFound();

            return Ok(listaLibros);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> GetLibroById(int id)
        {
            var book = await service.GetLibroById(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult> CreateLibro(LibroDTO bookDTO)
        {
            var nuevoLibro = await service.CreateLibro(bookDTO);
            return StatusCode(201, nuevoLibro);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            var libro = await service.GetLibroById(id);
            if (libro is null)
            {
                return NotFound();
            }
            await service.DeleteLibro(id);
            return Ok();
        }

        [HttpPut("{id:int}")] //api/libros/1
        public async Task<ActionResult> UpdateLibro([FromBody]LibroDTO book, int id)
        {
            var libro = await service.GetLibroById(id);
            if (libro is null)
                return NotFound("El id no coincide con ningun libro");

            if (libro.IdLibro == book.IdLibro)
            {
                await service.UpdateLibro(book, id);
                return Ok();
            }
            else
            {
                return BadRequest("El id no coincide con el del libro");
            }
        }
    }
}
