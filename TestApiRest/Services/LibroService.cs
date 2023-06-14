using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Exceptions;
using TestApiRest.Repository;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services.Interfaces;

namespace TestApiRest.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository libroRepository, IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public async Task<List<LibroDTO>> GetAllLibros()
        {
            var libros = await _libroRepository.GetAllLibros();
            return _mapper.Map<List<LibroDTO>>(libros);
        }

        public async Task<LibroDTO> GetLibroById(int id)
        {
            var libro = await _libroRepository.GetLibroById(id);
            return  _mapper.Map<LibroDTO>(libro);
        }

        public async Task<LibroDTO> CreateLibro(LibroDTO nuevolibroDTO)
        {
            var libro = _mapper.Map<Libro>(nuevolibroDTO);
            var nuevo = await _libroRepository.CreateLibro(libro);
            return _mapper.Map<LibroDTO>(nuevo);  
        }

        public async Task UpdateLibro(LibroDTO libroDto,int id)
        {
            var libro = await _libroRepository.GetLibroById(id);
            if (libro.IdLibro != libroDto.IdLibro || libro is null)
                throw new ExceptionMessage("Libro no encontrado");
            libro = _mapper.Map<Libro>(libroDto);
            await _libroRepository.UpdateLibro(libro);
        }

        public async Task DeleteLibro(int id)
        {
           await _libroRepository.DeleteLibro(id);
        }
    }
}
