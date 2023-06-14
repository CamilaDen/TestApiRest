using System.Runtime.InteropServices;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> GetAllLibros();
        Task<Libro> GetLibroById(int id);
        Task<Libro> CreateLibro(Libro libro);
        Task UpdateLibro(Libro libro);
        Task DeleteLibro(int id);
    }
}
