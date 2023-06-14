using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;

namespace TestApiRest.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LibroRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<Libro>> GetAllLibros()
        {
            return await _dbContext.Libros.ToListAsync();
            
        }
        public async Task<Libro> GetLibroById(int id)
        {
            return await _dbContext.Libros.AsNoTracking().FirstOrDefaultAsync(x => x.IdLibro == id);
        }
        public async Task<Libro> CreateLibro(Libro libro)
        {
            _dbContext.Libros.Add(libro);
            await _dbContext.SaveChangesAsync();
            return libro;
        }

        public async Task UpdateLibro(Libro libro)
        {
            _dbContext.Update(libro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteLibro(int id)
        {
            var libro = await _dbContext.Libros.FindAsync(id);
            if (libro != null)
            {
                _dbContext.Libros.Remove(libro);
                await _dbContext.SaveChangesAsync();
            }               
        }

    }
}
