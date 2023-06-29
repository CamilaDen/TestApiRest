using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Repository.Interfaces;

namespace TestApiRest.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public LibroRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext= dbContext;
            _mapper = mapper;
        }

        public async Task<List<LibroDTO>> GetAllLibros()
        {
            var libros = await _dbContext.Libros.ToListAsync();
            return _mapper.Map<List<LibroDTO>>(libros);                  
        }
        public async Task<LibroDTO> GetLibroById(int id)
        {
            var book = await _dbContext.Libros.AsNoTracking().FirstOrDefaultAsync(x => x.IdLibro == id);
            return _mapper.Map<LibroDTO>(book);
        }
        public async Task<LibroDTO> CreateLibro(LibroDTO libro)
        {
            var nuevoLibro = _mapper.Map<Libro>(libro);
            _dbContext.Libros.Add(nuevoLibro);
            await _dbContext.SaveChangesAsync();
            return await GetLibroById(libro.IdLibro);
        }

        public async Task<LibroDTO> UpdateLibro(LibroDTO libroDto)
        {
            var libro = GetLibroById(libroDto.IdLibro); //busco el mismo libro que quiero actualizar.
            if (libro is null)
                throw new ExceptionMessage("Libro no encontrado");

            var libroActualizado = _mapper.Map<Libro>(libroDto);
            _dbContext.Update(libroActualizado);
            await _dbContext.SaveChangesAsync();
            return await GetLibroById(libroActualizado.IdLibro);
        }

        public async Task<LibroDTO> DeleteLibro(int id)
        {
            var libro = await _dbContext.Libros.FindAsync(id);
            if (libro == null)
                throw new KeyNotFoundException("No se encontró el accesorio.");

            _dbContext.Libros.Remove(libro);
            await _dbContext.SaveChangesAsync();
                 
            return _mapper.Map<LibroDTO>(libro);
        }

    }
}
