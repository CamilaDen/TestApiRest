using System.Runtime.InteropServices;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<LibroDTO>> GetAllLibros();
        Task<LibroDTO> GetLibroById(int id);
        Task<LibroDTO> CreateLibro(LibroDTO libroDto);
        Task<LibroDTO> UpdateLibro(LibroDTO libroDto);
        Task<LibroDTO> DeleteLibro(int id);
    }
}
