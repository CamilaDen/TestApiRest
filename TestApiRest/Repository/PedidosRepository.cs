using Microsoft.EntityFrameworkCore;
using TestApiRest.Domain.Entities;
using TestApiRest.Repository.Interfaces;

namespace TestApiRest.Repository
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PedidosRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }

        public async Task<Pedido> GetPedidoById(int id)
        {
            return await _dbContext.Pedidos.FindAsync(id);
        }

        public async Task<Pedido> CreatePedido(Pedido pedido)
        {
            _dbContext.Pedidos.Add(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task UpdatePedido(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePedido(int id)
        {
            var pedido = await _dbContext.Pedidos.FindAsync(id);
            _dbContext.Pedidos.Remove(pedido);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddDetailPedido(int idPedido, DetallePedido detallePedido)
        {
            var pedido = await _dbContext.Pedidos.FindAsync(idPedido);
            pedido.ListaDetallePedidos.Add(detallePedido);
            await _dbContext.SaveChangesAsync();
        }
    }
}
