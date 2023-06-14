using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{ 
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAllUsuario();
        Task<UsuarioDTO> GetUsuarioById(int id);
        Task<UsuarioDTO> CreateUsuario(UsuarioDTO usuario);
        Task UpdateUsuario(int id, UsuarioDTO usuario);
        Task DeleteUsuario(int id);
    }
    
}
