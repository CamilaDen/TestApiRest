using System.Runtime.InteropServices;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
    }
}
