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
        
        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;           
        }

        public List<LibroDTO> GetAllLibros()
        {
            return _libroRepository.GetAllLibros().Result;           
        }

        public LibroDTO GetLibroById(int id)
        {
            return _libroRepository.GetLibroById(id).Result;  
        }

        public LibroDTO CreateLibro(LibroDTO libroDto)
        {
            return _libroRepository.CreateLibro(libroDto).Result;
        }

        public LibroDTO UpdateLibro(LibroDTO libroDto)
        {                            
            return _libroRepository.UpdateLibro(libroDto).Result;
        }

        public  LibroDTO DeleteLibro(int id)
        {
           return _libroRepository.DeleteLibro(id).Result;
        }
    }
}
