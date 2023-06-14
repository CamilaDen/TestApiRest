using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;
using TestApiRest.Repository.Interfaces;

namespace TestApiRest.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _dbContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
