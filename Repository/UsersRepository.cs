using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;
using Utils.Exceptions;

namespace TestApiRest.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.IdUser == id);
            if(user == null)
            {
                throw new KeyNotFoundException("El usuario ingresado no fue encontrado.");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            bool userExist = await _dbContext.Users.AnyAsync(x => x.DocumentNumber == userDto.DocumentNumber);
            if (userExist)
                throw new BadRequestException("Ya existe un usuario con el mismo DocumentNumber.");
            
            if ((int)userDto.TypeOfDocument > (int)Enum.GetValues(typeof(TypeOfDocument)).Cast<TypeOfDocument>().Max() 
                || (int)userDto.TypeOfDocument < (int)Enum.GetValues(typeof(TypeOfDocument)).Cast<TypeOfDocument>().Min())
            {
                throw new BadRequestException("No existe el TypeOfDocument ingresado.");
            }
            
            var newUser = _mapper.Map<User>(userDto);

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<UserDTO>(newUser);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDto)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.IdUser == userDto.IdUser);
            if (user == null)
                throw new KeyNotFoundException("Usuario no encontrado.");

            var updatedUser = _mapper.Map<User>(userDto);
            _dbContext.Update(updatedUser);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(updatedUser);
        }
        
        public async Task<UserDTO> DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                throw new KeyNotFoundException("No se encontró el usuario.");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }
    }
}
