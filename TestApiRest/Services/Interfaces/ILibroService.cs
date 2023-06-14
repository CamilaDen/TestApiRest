using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface ILibroService
    {
        Task<List<LibroDTO>> GetAllLibros();
        Task<LibroDTO> GetLibroById(int id);
        Task<LibroDTO> CreateLibro(LibroDTO libroCreate);
        Task UpdateLibro(LibroDTO libroDTO,int id);
        Task DeleteLibro(int id);

    }
}
