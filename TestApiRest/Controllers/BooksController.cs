using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Services;
using TestApiRest.Services.Interfaces;
using TestApiRest.Utils;
using Utils.CSVFileHandler;

namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/Books
        /// <summary>
        /// Obtiene todos los libros.
        /// </summary>
        /// <returns>Lista de BookDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet]
        public List<BookDTO> GetAllBooks()
        {
            return _booksService.GetAllBooks();
        }

        // GET: api/Books/{id}
        /// <summary>
        /// Obtiene un libro.
        /// </summary>
        /// <param name="id">Es el id del libro.</param>
        /// <returns>BookDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet("{id:int}")]
        public BookDTO GetBookById(int id)
        {
            return _booksService.GetBookById(id);      
        }

        // POST: api/Books
        /// <summary>
        /// Agrega un libro.
        /// </summary>
        /// <param name="bookDTO">Es el objeto que contiene los parametros.</param>
        /// <returns>BookDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPost]
        public BookDTO CreateBook(BookDTO bookDTO)
        {
            return _booksService.CreateBook(bookDTO);
        }

        // PUT: api/Books/{id}
        /// <summary>
        /// Modifica un libro. 
        /// </summary>
        /// <param name="bookDTO">Es el objeto que contiene los parametros.</param>
        /// <returns>BookDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPut("{id:int}")] 
        public BookDTO UpdateBook([FromBody] BookDTO bookDTO)
        {
            return _booksService.UpdateBook(bookDTO);                                      
        }

        // DELETE: api/Books/{id}
        /// <summary>
        /// Elimina un libro.
        /// </summary>
        /// <param name="id">Es el id del libro.</param>
        /// <returns>BookDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpDelete("{id:int}")]
        public ActionResult<BookDTO> DeleteBook(int id)
        {
            return _booksService.DeleteBook(id);
        }

        // POST:api/books/upload
        /// <summary>
        /// Carga un archivo csv.
        /// </summary>
        /// <param name="file">Es un archivo local del usuario.</param>
        /// <returns></returns>
        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public List<BookDTO> UploadCsv(IFormFile file)
        {
            return _booksService.ReadAndSaveBooksFromCsv(file);
        }

    }
}