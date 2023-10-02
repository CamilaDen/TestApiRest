using Microsoft.AspNetCore.Mvc;
using TestApiRest.DTO_s;
using TestApiRest.Services.Interfaces;


namespace TestApiRest.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsersControllers : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersControllers(IUsersService usersService)
        {
            _userService = usersService;
        }

        // GET: api/Users
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Lista de UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet]
        public List<UserDTO> GetAllUsers()
        {          
            return _userService.GetAllUsers();           
        }

        // GET: api/Users/{id}
        /// <summary>
        /// Obtiene un usuario.
        /// </summary>
        /// <param name="id">Es el id del usuario.</param>
        /// <returns>UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpGet("{id}")]
        public UserDTO GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST: api/Users
        /// <summary>
        /// Agrega un usuario.
        /// </summary>
        /// <param name="userDTO">Es el objeto que contiene los parametros.</param>
        /// <returns>UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPost]
        public ActionResult<UserDTO> CreateUser(UserDTO userDTO)
        {
            return _userService.CreateUser(userDTO);
        }

        // PUT: api/Users/{id}
        /// <summary>
        /// Modifica un usuario. 
        /// </summary>
        /// <param name="userDTO">Es el objeto que contiene los parametros.</param>
        /// <returns> UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpPut("{id}")]
        public UserDTO UpdateUser(UserDTO userDTO)
        {
             return _userService.UpdateUser(userDTO);      
        }

        // DELETE: api/Users/{id}
        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="id">Es el id del usuario.</param>
        /// <returns>UserDTO</returns>
        /// <response code="200">La operación fue exitosa</response>
        /// <response code="500">Internal server error</response>
        /// <response code="400">Mal ingreso de datos</response>
        [HttpDelete("{id}")]
        public ActionResult<UserDTO> DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
    }
}

