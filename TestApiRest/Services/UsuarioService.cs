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
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _repository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> GetAllUsuario()
        {
            var usuarios = await _repository.GetAllUsuarios();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }

        public async Task<UsuarioDTO> GetUsuarioById(int id)
        {
            var usuarioById = await _repository.GetUsuarioById(id);
            return _mapper.Map<UsuarioDTO>(usuarioById);
        }

        public async Task<UsuarioDTO> CreateUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var nuevoUsuarioDTO = await _repository.CreateUsuario(usuario);
            return _mapper.Map<UsuarioDTO>(nuevoUsuarioDTO);

        }

        public async Task UpdateUsuario(int id, UsuarioDTO usuarioDTO)
        {
            var usuario = await _repository.GetUsuarioById(id);

            if (usuario is null)
                throw new ExceptionMessage("Usuario no encontrado");

            usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _repository.UpdateUsuario(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
           

            await _repository.DeleteUsuario(id);
        }
    }
}
