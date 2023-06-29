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
        public List<LibroDTO> GetAllLibros()
        {
            return service.GetAllLibros();
        }

        [HttpGet("{id:int}")]
        public LibroDTO GetLibroById(int id)
        {
            return service.GetLibroById(id);      
        }
        [HttpPost]
        public LibroDTO CreateLibro(LibroDTO bookDTO)
        {
            return service.CreateLibro(bookDTO);
        }
        [HttpDelete("{id:int}")]
        public LibroDTO DeleteLibro(int id)
        {
            return service.DeleteLibro(id);
        }

        [HttpPut("{id:int}")] //api/libros/1
        public LibroDTO UpdateLibro([FromBody] LibroDTO book)
        {
            return service.UpdateLibro(book);                                      
        }
    }
}