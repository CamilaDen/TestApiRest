using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;
using TestApiRest.Services.Interfaces;
using Utils.CustomValidator;

namespace TestApiRest.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers().Result;
        }

        public UserDTO GetUserById(int id)
        {
            return _userRepository.GetUserById(id).Result;
        }

        public UserDTO CreateUser(UserDTO usuarioDTO)
        {
            CustomValidator<UserDTO>.DTOValidator(usuarioDTO);
            return _userRepository.CreateUser(usuarioDTO).Result;
        }

        public UserDTO UpdateUser(UserDTO usuarioDTO)
        {
            CustomValidator<UserDTO>.DTOValidator(usuarioDTO);
            return _userRepository.UpdateUser(usuarioDTO).Result;
        }

        public UserDTO DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id).Result;
        }
    }
}
