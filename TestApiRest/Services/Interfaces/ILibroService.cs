using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface ILibroService
    {
        List<LibroDTO> GetAllLibros();
        LibroDTO GetLibroById(int id);
        LibroDTO CreateLibro(LibroDTO libroCreate);
        LibroDTO UpdateLibro(LibroDTO libroDTO);
        LibroDTO DeleteLibro(int id);

    }
}
