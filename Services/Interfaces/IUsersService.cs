using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface IUsersService
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateUser(UserDTO user);
        UserDTO DeleteUser(int id);
    }
    
}
