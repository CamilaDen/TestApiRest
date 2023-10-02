using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<UserDTO> DeleteUser(int id);
    }
}
